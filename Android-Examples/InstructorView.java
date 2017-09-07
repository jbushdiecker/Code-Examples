package edu.fontbonne.cis.individualproject;

import android.Manifest;
import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import org.json.JSONArray;
import org.json.JSONObject;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import android.support.v4.app.ActivityCompat;

import java.util.HashMap;

public class InstructorView extends AppCompatActivity {
    HashMap<String,String> users = new HashMap<String, String>();
    TextView tv;
    Button btn_report;
    Button btn_scan;
    final int REQUEST_ENABLE_BT =1;
    BluetoothAdapter btAdapter;
    boolean done = false;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_instructor_view);

        getSupportActionBar().setBackgroundDrawable(
                new ColorDrawable(Color.parseColor("#800080")));
        setTitle("Fontbonne Attendance");

        tv = (TextView) findViewById(R.id.tv);
        btn_report = (Button) findViewById(R.id.btn_report);
        btn_report.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Intent.ACTION_SEND);
                intent.putExtra(Intent.EXTRA_EMAIL, "jacksonbushdiecker@gmail.com");
                intent.putExtra(Intent.EXTRA_SUBJECT, "Attendance Report");
                intent.putExtra(Intent.EXTRA_TEXT, tv.getText().toString());
                intent.setType("message/rfc822");
                startActivity(Intent.createChooser(intent, "Select Email Sending App :"));
            }
        });
        btn_scan = (Button) findViewById(R.id.btn_scan);
        btn_scan.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                btAdapter.startDiscovery();
                Log.d("Test", "Scanning");
            }
        });
        myTask m = new myTask();
        m.execute();
        while (!done){

        }
        myBroadcastReceiver mReceiver = new myBroadcastReceiver();
        IntentFilter filter = new IntentFilter();
        filter.addAction(BluetoothDevice.ACTION_FOUND);
        filter.addAction(BluetoothAdapter.ACTION_DISCOVERY_FINISHED);
        this.registerReceiver(mReceiver,filter);

        btAdapter = BluetoothAdapter.getDefaultAdapter();
        if (btAdapter == null) {
            // Device does not support Bluetooth
        }

        Intent discoverableIntent =
                new Intent(BluetoothAdapter.ACTION_REQUEST_DISCOVERABLE);
        discoverableIntent.putExtra(BluetoothAdapter.EXTRA_DISCOVERABLE_DURATION, 0);
        startActivity(discoverableIntent);

        int MY_PERMISSIONS_REQUEST_ACCESS_COARSE_LOCATION = 3;
        ActivityCompat.requestPermissions(this,
                new String[]{Manifest.permission.ACCESS_COARSE_LOCATION},
                MY_PERMISSIONS_REQUEST_ACCESS_COARSE_LOCATION);

        btAdapter.startDiscovery();

    }
    private class myTask extends AsyncTask{

        @Override
        protected Object doInBackground(Object[] params) {
            try {
                HttpURLConnection urlConnection = null;

                URL url = new URL("http://54.245.179.137/test.php");
                urlConnection = (HttpURLConnection) url.openConnection();

                urlConnection.setRequestMethod("GET");

                urlConnection.setReadTimeout(10000 /* milliseconds */);
                urlConnection.setConnectTimeout(15000 /* milliseconds */);

                urlConnection.setDoOutput(true);

                urlConnection.connect();

                BufferedReader br = null;

                br = new BufferedReader(new InputStreamReader(url.openStream()));

                char[] buffer = new char[1024];

                String jsonString = new String();

                StringBuilder sb = new StringBuilder();
                String line;

                while ((line = br.readLine()) != null) {
                    sb.append(line + "\n");
                }

                br.close();

                jsonString = sb.toString();

                JSONArray jArray = new JSONArray(jsonString);

                for (int i = 0; i < jArray.length(); i++) {
                    JSONObject oneObject = jArray.getJSONObject(i);
                    // Pulling items from the array
                    String oneObjectsItem = oneObject.getString("name");
                    String oneObjectsItem2 = oneObject.getString("device");

                    users.put(oneObjectsItem2,oneObjectsItem);
                }
            }catch (Exception e) {
                e.printStackTrace();
            }
            Log.d("Test","Done");
            done = true;
            return null;
        }
    }
    // Create a BroadcastReceiver for ACTION_FOUND.
    public class myBroadcastReceiver extends BroadcastReceiver {
        public void onReceive(Context context, Intent intent) {
            String action = intent.getAction();
            if (BluetoothDevice.ACTION_FOUND.equals(action)) {
                // Discovery has found a device. Get the BluetoothDevice
                // object and its info from the Intent.
                BluetoothDevice device = intent.getParcelableExtra(BluetoothDevice.EXTRA_DEVICE);
                String deviceAddress = device.getAddress();

                Log.d("Test",deviceAddress +"," + device.getName());
                if (users.containsKey(deviceAddress)){
                    if(!tv.getText().toString().contains(users.get(deviceAddress))){
                        tv.append(users.get(deviceAddress) + "\n");
                    }
                }
            }
        }
    }

    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        switch (requestCode) {
            case REQUEST_ENABLE_BT:

                if (resultCode == Activity.RESULT_OK) {


                }
                break;
        }
    }

    protected void onDestroy() {
        super.onDestroy();
        // Don't forget to unregister the ACTION_FOUND receiver.

    }
}
