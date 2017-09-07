package edu.fontbonne.cis.individualproject;

import android.bluetooth.BluetoothAdapter;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.AsyncTask;
import android.preference.PreferenceManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;


public class StudentView extends AppCompatActivity {
    Button btn_register;
    EditText et_name;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_student_view);

        getSupportActionBar().setBackgroundDrawable(
                new ColorDrawable(Color.parseColor("#800080")));
        setTitle("Fontbonne Attendance");

        btn_register = (Button) findViewById(R.id.btn_register);
        et_name = (EditText) findViewById(R.id.et_name);

        btn_register.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                SharedPreferences SavedAnswers = PreferenceManager.getDefaultSharedPreferences(getApplicationContext());
                SharedPreferences.Editor editor = SavedAnswers.edit();

                if(SavedAnswers.getBoolean("Registered",false)){
                    Toast.makeText(getApplicationContext(),"This device has already registered!",Toast.LENGTH_LONG).show();
                    return;
                }

                WebView w = new WebView(getApplicationContext());
                BluetoothAdapter bt = BluetoothAdapter.getDefaultAdapter();
                String add = bt.getAddress();
                w.loadUrl("http://54.245.179.137/register.php?name="+et_name.getText().toString() +"&device="+add);
                Log.d("Test",add + ","+ bt.getName());
                editor.putBoolean("Registered", true);
                editor.commit();
                finish();
            }
        });
    }
}
