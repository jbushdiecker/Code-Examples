package edu.fontbonne.cis.individualproject;

import android.app.IntentService;
import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.os.ResultReceiver;
import android.util.Log;

import org.apache.commons.net.ftp.FTP;
import org.apache.commons.net.ftp.FTPClient;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.ProtocolException;
import java.net.URL;

public class ftpService extends IntentService {
    FTPClient MyClient = null;
    public ftpService() {
        super("ftpService");
    }
    @Override
    protected void onHandleIntent(Intent intent) {
        ResultReceiver r = intent.getParcelableExtra("receivertag");

        HttpURLConnection urlConnection = null;

        URL url = null;
        try {
            url = new URL("http://54.245.179.137/test.php");
        } catch (MalformedURLException e) {
            e.printStackTrace();
        }

        try {
            urlConnection = (HttpURLConnection) url.openConnection();
        } catch (IOException e) {
            e.printStackTrace();
        }

        try {
            urlConnection.setRequestMethod("GET");
        } catch (ProtocolException e) {
            e.printStackTrace();
        }
        urlConnection.setReadTimeout(10000 /* milliseconds */);
        urlConnection.setConnectTimeout(15000 /* milliseconds */);

        urlConnection.setDoOutput(true);

        try {
            urlConnection.connect();
        } catch (IOException e) {
            e.printStackTrace();
        }

        BufferedReader br= null;
        try {
            br = new BufferedReader(new InputStreamReader(url.openStream()));
        } catch (IOException e) {
            e.printStackTrace();
        }

        char[] buffer = new char[1024];

        String jsonString = new String();

        StringBuilder sb = new StringBuilder();
        String line;
        try {
            while ((line = br.readLine()) != null) {
                sb.append(line+"\n");
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        try {
            br.close();
        } catch (IOException e) {
            e.printStackTrace();
        }

        jsonString = sb.toString();
        Bundle myBundle = new Bundle();
        try {
            JSONArray jArray = new JSONArray(jsonString);
            myBundle.putInt("count",jArray.length());
            for (int i=0; i < jArray.length(); i++)
            {

                JSONObject oneObject = jArray.getJSONObject(i);
                // Pulling items from the array
                String oneObjectsItem = oneObject.getString("name");
                String oneObjectsItem2 = oneObject.getString("device");
                Log.d("Test",oneObjectsItem + ","+oneObjectsItem2);
                myBundle.putString("user" + i,oneObjectsItem +","+oneObjectsItem2);
            }

        } catch (JSONException e) {
            e.printStackTrace();
        }

        r.send(0,myBundle);
    }
}
