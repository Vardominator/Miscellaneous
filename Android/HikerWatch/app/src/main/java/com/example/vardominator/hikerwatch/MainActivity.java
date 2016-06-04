package com.example.vardominator.hikerwatch;

import android.Manifest;
import android.app.Activity;
import android.content.Context;
import android.content.pm.PackageManager;
import android.location.Address;
import android.location.Criteria;
import android.location.Geocoder;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.widget.TextView;


import org.w3c.dom.Text;

import java.io.IOException;
import java.util.List;
import java.util.Locale;


/*
This simple application demonstrates the ability to extract different kinds of information regard
the location of the user: latitude, longitude, altitude, bearing, etc.

I learned a few important things regarding changing themes in activity_main.xml :
1. Make sure to select "Empty Activity" when starting a project
2. Make sure to pay attention to what class the MainActivity class is inheriting.
    To open the doors to all available themes makes sure MainActivity extends Activity and not
    something else.
 */


public class MainActivity extends Activity implements LocationListener {


    LocationManager locationManager;
    String provider;


    final private int PERMISSION_ADDED_REQUEST_CODE = 18235;
    private int fineLocationPermissionCheck;
    private int coarseLocationPermissionCheck;

    private Double lat;
    private Double lon;


    TextView latTV;
    TextView lonTV;

    Location location;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        latTV = (TextView) findViewById(R.id.latitudeTextView);
        lonTV = (TextView) findViewById(R.id.longitudeTextView);


        locationManager = (LocationManager) getSystemService(Context.LOCATION_SERVICE);

        provider = locationManager.getBestProvider(new Criteria(), false);


        fineLocationPermissionCheck = ContextCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION);
        coarseLocationPermissionCheck = ContextCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION);



        if (fineLocationPermissionCheck != PackageManager.PERMISSION_GRANTED && coarseLocationPermissionCheck != PackageManager.PERMISSION_GRANTED) {
            requestPermissions(new String[]{Manifest.permission.ACCESS_COARSE_LOCATION, Manifest.permission.ACCESS_FINE_LOCATION},
                    PERMISSION_ADDED_REQUEST_CODE);


            return;
            // TODO: Consider calling
            //    ActivityCompat#requestPermissions
            // here to request the missing permissions, and then overriding
            //   public void onRequestPermissionsResult(int requestCode, String[] permissions,
            //                                          int[] grantResults)
            // to handle the case where the user grants the permission. See the documentation
            // for ActivityCompat#requestPermissions for more details.

        }
        location = locationManager.getLastKnownLocation(provider);

    }





    @Override
    protected void onResume() {
        super.onResume();

        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            // TODO: Consider calling
            //    ActivityCompat#requestPermissions
            // here to request the missing permissions, and then overriding
            //   public void onRequestPermissionsResult(int requestCode, String[] permissions,
            //                                          int[] grantResults)
            // to handle the case where the user grants the permission. See the documentation
            // for ActivityCompat#requestPermissions for more details.
            return;
        }
        locationManager.requestLocationUpdates(provider, 400, 1, this);

    }

    @Override
    protected void onPause() {
        super.onPause();

        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            // TODO: Consider calling
            //    ActivityCompat#requestPermissions
            // here to request the missing permissions, and then overriding
            //   public void onRequestPermissionsResult(int requestCode, String[] permissions,
            //                                          int[] grantResults)
            // to handle the case where the user grants the permission. See the documentation
            // for ActivityCompat#requestPermissions for more details.
            return;
        }
        locationManager.removeUpdates(this);

    }

    @Override
    public void onLocationChanged(Location location) {


        lat = location.getLatitude();
        lon = location.getLongitude();
        Double alt = location.getAltitude();
        Float bearing = location.getBearing();
        Float speed = location.getSpeed();
        Float accuracy = location.getAccuracy();


        Geocoder geocoder = new Geocoder(getApplicationContext(), Locale.getDefault());

        try {
            List<Address> listAddresses = geocoder.getFromLocation(lat, lon, 1);


            if (listAddresses != null && listAddresses.size() > 0) {

                Log.i("Place info: ", listAddresses.toString());

            }

        } catch (IOException e) {
            e.printStackTrace();
        }


        latTV.setText("Latitude: " + lat.toString());
        lonTV.setText("Longitude: " + lon.toString());

        Log.i("Location update: ", String.valueOf(lat) + ", " + String.valueOf(lon));
        Log.i("Altitude: " , String.valueOf(alt));
        Log.i("Bearing: " , String.valueOf(bearing));
        Log.i("Speed: ", String.valueOf(speed));
        Log.i("Accuracy: ", String.valueOf(accuracy));


    }

    @Override
    public void onStatusChanged(String provider, int status, Bundle extras) {

    }

    @Override
    public void onProviderEnabled(String provider) {

    }

    @Override
    public void onProviderDisabled(String provider) {

    }
}
