package droid.application.bob.grouupproject;

import android.content.ContentValues;                           // utility content value for entering values to data base
import android.content.Context;                                 // utility for context
import android.database.Cursor;                                 // utility for cursor
import android.database.sqlite.SQLiteDatabase;                  // utility for database
import android.database.sqlite.SQLiteOpenHelper;                // utility for database helper
import android.widget.Toast;                                    // utility for toast
import java.util.ArrayList;                                     // utility for array list

class DBHandler extends SQLiteOpenHelper {
    private static final int DATABASE_VERSION = 1;              // database version
    private static final String DATABASE_NAME = "messenger";   // database name
    private static final String TABLE_ADDRESS = "message";      // table address
    private static final String KEY_ID = "id";                  // column id
    private static final String KEY_CONTACT = "user";            // column user
    private static final String KEY_MESSAGES = "messages";        // column web site
    private static final String KEY_NUMBER = "number";            // column number
    private Context context;                                    // holds context for application

    /**
     * constructor for DBHandler
     * @param context application context
     */
    DBHandler(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);  // super class constructor
        this.context = context;                                 // set context
    }

    /**
     *  creates table if needed
     * @param db database handler is managing
     */
    @Override
    public void onCreate(SQLiteDatabase db) {
        // string holds commands to create table
        String create_address_table = "CREATE TABLE " + TABLE_ADDRESS + "(" +
                KEY_ID + " INTEGER PRIMARY KEY, " + KEY_CONTACT + " TEXT, " +
                KEY_MESSAGES + " TEXT, " + KEY_NUMBER + " TEXT)";
        db.execSQL(create_address_table);                       // create table
    }

    /**
     * upgrades database if the version number is higher than existing
     * @param db database handler is managing
     * @param oldVersion existing version integer
     * @param newVersion current version integer
     */
    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        // drop older table if exists
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_ADDRESS);
        onCreate(db);                                           // create new database
    }

    /**
     * add row to database table
     * @param message value to add to database table
     */
    void addMessage(String message, String user, String number){
        String query = "SELECT * FROM " + TABLE_ADDRESS;        // query command to get values
        SQLiteDatabase db = this.getWritableDatabase();         // open data base
        Cursor cursor = db.rawQuery(query, null);               // run query
        // get values from cursor
        if (cursor.moveToFirst()){
            do{

            }while(cursor.moveToNext());
        }
        cursor.close();                                         // close cursor
        ContentValues values = new ContentValues();             // new content values
        values.put(KEY_CONTACT, user);                          // add values to content
        values.put(KEY_MESSAGES, message);                      // add values to content
        values.put(KEY_NUMBER, number);                         // add values to content
        db.insert(TABLE_ADDRESS, null, values);    // insert values to database
        db.close();                                             // close data base
    }

    String getLastUser(){
        String temp = "";
        String query = "SELECT * FROM " + TABLE_ADDRESS;        // query command to get values
        SQLiteDatabase db = this.getWritableDatabase();         // open data base
        Cursor cursor = db.rawQuery(query, null);               // run query
        // get values from cursor
        if (cursor.moveToLast()){
            temp = cursor.getString(1);
        }
        cursor.close();                                         // close cursor
        db.close();                                             // close data base
        return temp;
    }

    /**
     * add all sites int array list
     * @param siteList array list to hold database values
     */
    void getUserMess(String user, ArrayList<String> siteList) {
        String query = "SELECT * FROM " + TABLE_ADDRESS;        // query command to get values
        SQLiteDatabase db = this.getWritableDatabase();         // open data base
        Cursor cursor = db.rawQuery(query, null);               // run query
        // get values from cursor
        if (cursor.moveToFirst()){
            do{
                if(cursor.getString(1).equals(user))
                siteList.add(cursor.getString(2));              // add values to array list
            }while(cursor.moveToNext());
        }
        cursor.close();                                         // close cursor
        db.close();                                             // close database
    }

    /**
     * deletes a row from database table
     * @param user input of row id to delete
     */
    void deleteUser(String user){
        // block initialized sites from being deleted
        SQLiteDatabase db = this.getWritableDatabase();     // open database
        db.delete(TABLE_ADDRESS, KEY_CONTACT + "=?",
                new String[]{String.valueOf(user)});          // delete website row
        db.close();                                         // close database
    }

    String getNumber(String user){
        String tmp = "";
        String query = "SELECT * FROM " + TABLE_ADDRESS;        // query command to get values
        SQLiteDatabase db = this.getWritableDatabase();         // open data base
        Cursor cursor = db.rawQuery(query, null);               // run query
        // get values from cursor
        if (cursor.moveToFirst()){
            do{
                if(cursor.getString(1).equals(user))
                    tmp = (cursor.getString(3));
            }while(cursor.moveToNext());
        }
        cursor.close();                                         // close cursor
        db.close();                                             // close database
        return tmp;
    }

    /**
     * returns count of rows in databse
     * @return Integer number of items in database
     */
    int getCount(){
        String query = "SELECT * FROM " + TABLE_ADDRESS;        // query command to get values
        SQLiteDatabase db = this.getReadableDatabase();         // open database
        Cursor cursor = db.rawQuery(query, null);               // run query
        // get values from cursor
        try{
            cursor.moveToFirst();
            cursor.close();                                     // close cursor
            db.close();                                         // close database
        }
        catch(Exception e){
            return 0;                                           // if database empty return 0
        }
        return cursor.getCount();                               // return number of entries in database
    }

    /**
     *  gets value of website row in database
     * @param user String website name
     * @return  Integer row number
     */
    int getSiteID(String user){
        // query command to get row number of website from database
        String query = "SELECT * FROM " + TABLE_ADDRESS + " WHERE " + KEY_CONTACT + "='" + user + "'";
        SQLiteDatabase db = this.getWritableDatabase();         // open database
        Cursor cursor = db.rawQuery(query, null);               // run query
        int a = 0;                                              // initialize integer value for row number
        // get values from cursor
        if(cursor.moveToFirst()){
            a = Integer.parseInt(cursor.getString(0));          // set row number
        }
        cursor.close();                                         // close cursor
        db.close();                                             // close database
        return a;                                               // return row number
    }
}
