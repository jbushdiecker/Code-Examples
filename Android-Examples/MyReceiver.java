package droid.application.bob.grouupproject;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.ContentResolver;
import android.database.Cursor;
import android.net.Uri;
import android.os.Bundle;
import android.provider.ContactsContract;
import android.telephony.SmsMessage;
import android.util.Base64;
import android.util.Log;
import java.io.File;
import java.io.FileInputStream;

public class MyReceiver extends BroadcastReceiver {
    private static final String ACTION_MMS_RECEIVED = "android.provider.Telephony.WAP_PUSH_RECEIVED";
    private static final String MMS_DATA_TYPE = "application/vnd.wap.mms-message";
    private final String DEBUG_TAG = "RECEIVER";
    protected FileInputStream fileInputStream;
    protected DBHandler db;
    protected Context context;
    protected SmsMessage[] msgs;
    protected Bundle bundle;
    protected String name;
    protected String number;
    protected String message = "";
    protected String action;
    protected String type;
    protected String str;
    protected int transactionId;

    public MyReceiver(){}

    @Override
    public void onReceive(Context context, Intent intent) {
        this.context = context;
        action = intent.getAction();
        type = intent.getType();
        msgs = null;
        str = "";

        if (action.equals(ACTION_MMS_RECEIVED) && type.equals(MMS_DATA_TYPE)) {

            bundle = intent.getExtras();
            transactionId = bundle.getInt("transactionId");
            Log.d(DEBUG_TAG, "bundle " + bundle);

            if (bundle != null) {

                byte[] buffer = bundle.getByteArray("data");
                Log.d(DEBUG_TAG, "buffer " + buffer);
                if (buffer != null) {
                    number = new String(buffer);
                    int indx = number.indexOf("/TYPE");
                    if (indx > 0 && (indx - 11) > 0) {
                        int newIndx = indx - 11;
                        number = number.substring(newIndx, indx);
                        indx = number.indexOf("+");
                        if (indx > 0) {
                            number = number.substring(indx);
                            Log.d(DEBUG_TAG, "Mobile Number: " + number);
                        }
                    }
                }

                name = getContactName(context, number);
                if (name == null) {
                    name = number;
                }
                Log.d(DEBUG_TAG, "transactionId " + transactionId);

                int pduType = bundle.getInt("pduType");
                Log.d(DEBUG_TAG, "pduType " + pduType);

                byte[] buffer2 = bundle.getByteArray("header");
                String header = new String(buffer2);
                Log.d(DEBUG_TAG, "header " + header);


                String[] columns;
                String[] values = null;
                String read = "read = 0";

                Cursor curPdu = context.getContentResolver().query(Uri.parse("content://mms"), null, null, null, null);
                assert curPdu != null;
                if (curPdu.moveToNext()) {
                    Log.d(DEBUG_TAG, "cursor");
                    String id = curPdu.getString(curPdu.getColumnIndex("_id"));
                    Cursor curPart = context.getContentResolver().query(Uri.parse("content://mms/" + id + "/part"), null, null, null, null);

                    assert curPart != null;
                    while (curPart.moveToNext()) {
                        columns = curPart.getColumnNames();
                        if (values == null)
                            values = new String[columns.length];

                        for (int i = 0; i < curPart.getColumnCount(); i++) {
                            values[i] = curPart.getString(i);
                            Log.d(DEBUG_TAG, "Values: " + values[i]);
                        }
                        if (values[3].equals("image/jpeg") || values[3].equals("image/bmp") ||
                                values[3].equals("image/gif") || values[3].equals("image/jpg") ||
                                values[3].equals("image/png")) {
                            message = RetrieveMessge(new File(values[12]));
                            Log.d(DEBUG_TAG, "message: " + message);
                        }
                    }
                    curPart.close();
                }
                curPdu.close();
                if(!message.equals("")) {
                    db = new DBHandler(context);
                    db.addMessage(message, name, number);
                    context.startActivity(new Intent(context, MainActivity.class));
                }
            }
        }
    }

    /**This method opens a jpg and looks for data at the end of the file
     *
     * @return A decoded base64 string, or an empty string if there was no encoded message
     */
    public String RetrieveMessge(File file) {

        try {
            byte[] contents = readContentIntoByteArray(file);
            //Start looking at the last 250 bytes. We may want to change this, but looking at the whole array takes way too long
            for(int i=contents.length-250;i<contents.length-1;i++) {
                StringBuilder sb = new StringBuilder();
                sb.append(String.format("%02X ", contents[i])); //Make the bytes into a hex string
                sb.append(String.format("%02X ", contents[i + 1]));

                if (sb.toString().equals("FF D9 ")) { //Look for the end of the file
                    byte[] getBytes = new byte[250];
                    int bcount=0; //Index for the getBytes array
                    for (int j = i + 2; j < contents.length; j++) { //loop through everything after the FF D9
                        getBytes[bcount] = contents[j]; //save the byte
                        bcount++;
                    }
                    byte[] decodedBytes = Base64.decode(getBytes,Base64.DEFAULT); //Get the decoded byte array
                    Log.d(DEBUG_TAG, "return recovered message");
                    return new String(decodedBytes,"UTF-8"); //Get an ASCII string from the decoded bytes
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return "";                                              //No message was found
    }

    /**
     * This method reads the content of the message into a byte array
     * @param file: the file name or file path
     * @return: the byte array
     */
    private byte[] readContentIntoByteArray(File file) {
        byte[] bFile = new byte[(int) file.length()];
        try
        {
            //convert file into array of bytes
            fileInputStream = new FileInputStream(file);
            fileInputStream.read(bFile);
            fileInputStream.close();
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
        return bFile;
    }

    /**
     * This method gets the name of the person sending the message
     * @param context: the context of the receiver
     * @param phoneNumber: of the sender
     * @return: contactName: contact name
     */
    public static String getContactName(Context context, String phoneNumber) {

        //Assign variables
        ContentResolver cr = context.getContentResolver();
        Uri uri = Uri.withAppendedPath(ContactsContract.PhoneLookup.CONTENT_FILTER_URI, Uri.encode(phoneNumber));
        Cursor cursor = cr.query(uri, new String[]{ContactsContract.PhoneLookup.DISPLAY_NAME}, null, null, null);

        //If the cursor is null return null
        if (cursor == null) {
            return null;
        }

        //If the numbers match matches then assign the name to the contact Name variable
        String contactName = null;
        if(cursor.moveToFirst()) {
            contactName = cursor.getString(cursor.getColumnIndex(ContactsContract.PhoneLookup.DISPLAY_NAME));
        }

        //Close the cursor
        if(!cursor.isClosed()) {
            cursor.close();
        }

        //Return the name
        return contactName;
    }
}
