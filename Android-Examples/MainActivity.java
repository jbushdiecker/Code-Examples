package droid.application.bob.grouupproject;

import android.Manifest;
import android.app.Activity;

import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.net.ConnectivityManager;
import android.net.Uri;
import android.provider.MediaStore;
import android.support.v4.app.ActivityCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.TextUtils;
import android.util.Base64;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.Toast;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {
    private static final int REQUEST_EXTERNAL_STORAGE = 1;
    private static String[] PERMISSIONS_STORAGE = {
            Manifest.permission.READ_EXTERNAL_STORAGE,
            Manifest.permission.WRITE_EXTERNAL_STORAGE
    };
    private static final int PICK_FROM_GALLARY = 2;                         // id for photo selection
    protected static final int SELECT_CONTACT = 1;                          // id for contact selection
    protected SharedPreferences data;                                       // shared preference for message log
    protected ArrayList<String> messages;                                   // messages sent and received user
    protected Adapter adapter;                                              // array adapter for messages
    protected DBHandler db;                                                 // database to get
    protected EditText contact;                                             // list of sent received messages
    protected Uri outPutfileUri;                                            // uri for image
    protected EditText mess;                                                // location of message
    protected ListView list;                                                // image display
    protected ImageButton pickImage;                                        // image selection button
    protected Button send;                                                  // send button
    protected String sender = "Bob";                                                // recipient/sender
    protected String number = "16367951802";                                 // sender/recipient number
    protected String path;                                                  // image path
    protected String message;                                               // message
    protected boolean cancel = false;                                       // check boolean
    // protected Receiver receiver;                                            // local receiver


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        pickImage = (ImageButton) findViewById(R.id.img_but);               // select image button
        send = (Button) findViewById(R.id.send_but);                        // send message button
        list = (ListView) findViewById(R.id.list);                          // array list to display messages
        mess = (EditText) findViewById(R.id.mess_in);                       // message window
        contact = (EditText) findViewById(R.id.contact);                    // sender receiver
        messages = new ArrayList<>();                                       // array list declaration
        db = new DBHandler(this);                                    // get database handler instance
        if(db.getCount() != 0){                                             // if database is empty initialize database
            sender = db.getLastUser();                                      // get last user
            Log.d("DB", "sender: " + sender);
            Log.d("DB", "count: " + db.getCount());
            db.getUserMess(sender, messages);                               // get last user messages
            Log.d("DB", "number of messages: " + messages.size());
            number = db.getNumber(sender);                                  // get user number
            if(sender.equals("")){
                sender = number;
            }
            contact.setText(sender);
            Log.d("DB", "number: " + number);
            setAdapter();                                                   // set message list view adapter
        }
    }

    protected void onStart(){
        super.onStart();
        pickImage.setOnClickListener(new View.OnClickListener() {           // listener to pick image
            @Override
            public void onClick(View v) {
                PictureSelection();                                         // method for picture selection
            }
        });
        send.setOnClickListener(new View.OnClickListener() {                // listener to send message
            @Override
            public void onClick(View v) {
                if(outPutfileUri.getPath().equals("")) {                    // if no image is selected
                    cancel = true;                                          // set boolean true
                    // inform user that an image must be selected
                    Toast.makeText(getApplicationContext(), "Image must be selected", Toast.LENGTH_LONG).show();
                    return;                                                 // exit method
                }
                if(TextUtils.isEmpty(mess.getText().toString())) {           // if no message has been entered
                    cancel = true;                                           // set boolean true
                    mess.setError("Message cannot be Blank.");              // set error to inform user need message
                    return;                                                 // exit method
                }
                message = "u" + mess.getText().toString();                        // set message from edit text
                db.addMessage(message, sender, number);
                Log.d("DB", "count: " + db.getCount());
                if(adapter == null){
                    Log.d("ADAPTER TEST", "set adapter");
                    messages.add(message);
                    setAdapter();
                }else{
                    adapter.add(message);                                  // add message to user mes list
                    Log.d("ADAPTER TEST", "add to adapter");
                }
                sendMessage();                                              //Send an mms message with the embedded cover file
            }
        });
       contact.setOnClickListener(new View.OnClickListener() {              // listener for edit text contact
           @Override
           public void onClick(View v) {
               // go to contact activity to select contact
               startActivityForResult(new Intent(getApplicationContext(), Contacts.class), SELECT_CONTACT);
           }
       });
     /*  receiver = new Receiver();                                                                   // receiver declaration
        IntentFilter intent = new IntentFilter(Intent.ACTION_SEND);                                 // intent filter
        registerReceiver(receiver, intent);       */                                                  // register receiver
    }
    protected  void onResume(){
        super.onResume();
    }

    protected void onPause(){
        super.onPause();
    }

    protected void onStop(){
        super.onStop();
        // unregisterReceiver(receiver);                                                               // unregister receiver
    }

    protected void onDestroy(){
        super.onDestroy();
    }







    /*
     * !!!!!!!!!!!!!!!!!!!!!!!!!!!! Utility Methods !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
     */
    protected void setAdapter(){
        Log.d("ADAPTER TEST", "enter set adapter");
        adapter = new Adapter(this, sender, messages);                                       // array adapter for messages
        list.setAdapter(adapter);                                                                   // set adapter to list
    }

    private static byte[] readContentIntoByteArray(File file) {
        FileInputStream fileInputStream;
        byte[] bFile = new byte[(int) file.length()];
        try
        {
            //convert file into array of bytes
            fileInputStream = new FileInputStream(file);
            fileInputStream.read(bFile);                                                            //todo this is not saving do we need it
            fileInputStream.close();
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
        return bFile;
    }

    private static void copyFile(String inputFile, String outputFile) {
        InputStream in;
        OutputStream out;
        try {
            in = new FileInputStream(inputFile);
            out = new FileOutputStream(outputFile);

            byte[] buffer = new byte[1024];
            int read;
            while ((read = in.read(buffer)) != -1) {
                out.write(buffer, 0, read);
            }
            in.close();

            // write the output file (You have now copied the file)
            out.flush();
            out.close();

        }  catch (FileNotFoundException fnfe1) {
            Log.e("tag", fnfe1.getMessage());
        }
        catch (Exception e) {
            Log.e("tag", e.getMessage());
        }

    }

    private static void deleteAFile(String inputPath) {
        try {
            // delete the original file
            new File(inputPath).delete();               // todo delete log says permissions denied ? what permissions do we need
        }
        catch (Exception e) {
            Log.e("tag", e.getMessage());
        }
    }
    /*
     * !!!!!!!!!!!!!!!! This Section Contains Main Functions  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
     */

    /** This method prepares an intent with the image attached and allows the user to
     * send it as they see fit.
     *
     * */
    public void sendMessage(){
        copyFile(path,path+".bak"); //Make a backup so we don't permanently mod the original
        byte[] encodedMessages = Base64.encode(message.getBytes(),Base64.DEFAULT); //Endcode the message in base64

        try {
            FileOutputStream output = new FileOutputStream(path, true); //Open the file and append the encoded messages
            output.write(encodedMessages);
            output.close();
        } catch (Exception e) {
            Log.d("ENCODE", "exception on encode message");
        }

        Intent send = new Intent(Intent.ACTION_SEND);
        send.putExtra("address", number);
        Log.d("SEND MESSAGE", "address: " + number);
        send.putExtra(Intent.EXTRA_STREAM ,outPutfileUri);
        send.putExtra(Intent.EXTRA_ORIGINATING_URI ,outPutfileUri);
        send.putExtra("exit_on_sent", true);
        send.setType("image/png");
        startActivity(send);
        mess.setText("");
        deleteAFile(path); //Delete the modified file
        copyFile(path+".bak",path); //Restore from the backup
        deleteAFile(path+".bak"); //Delete the backup
    }

    /**This method allows the user to pick an image to use as the cover file
     *
     */
    public void PictureSelection(){
        Intent photoPickerIntent = new Intent(Intent.ACTION_PICK);
        photoPickerIntent.setType("image/*");
        startActivityForResult(photoPickerIntent, PICK_FROM_GALLARY);
    }

    /**
     * This Method is called when an activity returns. Here we are using it to get the result
     * of the picture selection, and call the method to send the photo
     * @param requestCode - request code id
     * @param resultCode - result code id
     * @param data - data from intent
     */
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        switch (requestCode) {
            case PICK_FROM_GALLARY: //The activity that returned was the picture selection
                if (resultCode == Activity.RESULT_OK) {
                    //pick image from gallery
                    outPutfileUri = data.getData();
                    Log.d("ON RESULT", data.getDataString());
                    String[] filePathColumn = { MediaStore.Images.Media.DATA };
                    Cursor cursor = getContentResolver().query(outPutfileUri, filePathColumn, null, null, null);
                    // Move to first row
                    assert cursor != null;
                    cursor.moveToFirst();
                    int columnIndex = cursor.getColumnIndex(filePathColumn[0]);
                    path = cursor.getString(columnIndex); //This is the file path of the image that was selected
                    cursor.close();
                }
                break;
            case SELECT_CONTACT: // contact activity return
                if(resultCode == Activity.RESULT_OK){
                    number = data.getStringExtra("number");
                    sender = data.getStringExtra("name");
                    if(sender.equals("")){
                        contact.setText(sender);
                    }else{
                        contact.setText(number);
                    }
                }
                break;
        }
    }
}
