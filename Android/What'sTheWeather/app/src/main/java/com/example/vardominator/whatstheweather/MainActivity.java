package com.example.vardominator.whatstheweather;

import android.content.Context;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;

public class MainActivity extends AppCompatActivity {


    Button check;
    EditText cityText;

    TextView weatherData;


    public class DownloadTask extends AsyncTask<String, Void, String> {

        @Override
        protected String doInBackground(String... urls) {

            String result = "";
            URL url;
            HttpURLConnection urlConnection = null;


            try {
                url = new URL(urls[0]);

                urlConnection = (HttpURLConnection) url.openConnection();

                InputStream in = urlConnection.getInputStream();

                InputStreamReader reader = new InputStreamReader(in);

                int data = reader.read();


                while(data != - 1) {
                    char current = (char) data;

                    result += current;

                    data = reader.read();

                }

                return result;

            } catch (MalformedURLException e) {
                e.printStackTrace();
            } catch (IOException e) {
                e.printStackTrace();
            }


            return null;
        }

        @Override
        protected void onPostExecute(String result) {
            super.onPostExecute(result);


            try {
                JSONObject jsonObject = new JSONObject(result);
                String weatherInfo = jsonObject.getString("weather");

                String message = "";

                JSONArray arr = new JSONArray(weatherInfo);


                for (int i = 0; i <arr.length(); i++) {

                    JSONObject jsonPart = arr.getJSONObject(i);

                    Log.i("main", jsonPart.getString("main"));
                    Log.i("description", jsonPart.getString("description"));


                    String main = "";
                    String description = "";

                    main = jsonPart.getString("main");
                    description = jsonPart.getString("description");

                    if(main != "" && description != "") {

                        message += main + ": " + description + "\r\n";

                    }


                }

                if (message != ""){
                    weatherData.setText(message);
                }



            } catch (JSONException e) {
                e.printStackTrace();
            }


        }
    }


    public void checkCity(View view) {

        cityText = (EditText)findViewById(R.id.cityText);

        String citySelection = null;

        try {
            citySelection = String.valueOf(cityText.getText());
        }catch(NullPointerException e){
            Toast.makeText(this, "No city entered", Toast.LENGTH_SHORT).show();
        }


        weatherData = (TextView)findViewById(R.id.weatherData);

        DownloadTask task = new DownloadTask();


        task.execute("http://api.openweathermap.org/data/2.5/weather?q=" + citySelection + ",us&appid=568d65cc111c4c3a95afaff6d4685407");


        // hide keyboard after search
        InputMethodManager mgr = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
        mgr.hideSoftInputFromWindow(cityText.getWindowToken(), 0);

        //Log.i("City selected", citySelection);

    }


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);




        check = (Button)findViewById(R.id.button);

    }
}
