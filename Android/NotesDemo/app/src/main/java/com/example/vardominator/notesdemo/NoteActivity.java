package com.example.vardominator.notesdemo;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.EditText;

public class NoteActivity extends AppCompatActivity {


    EditText title;
    EditText body;

    int listElementIndex;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_note);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);


        title = (EditText) findViewById(R.id.titleText);
        body = (EditText) findViewById(R.id.bodyText);


        Intent i = getIntent();
        String bodyFromList = i.getStringExtra("note");
        body.setText(bodyFromList);

        listElementIndex = i.getIntExtra("list element", -1);


        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {

        // add icons to menu
        getMenuInflater().inflate(R.menu.menu_note, menu);

        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        switch(item.getItemId()) {
            case android.R.id.home:

                finish();
                return true;

            case R.id.savenote:

                String nextNote = String.valueOf(body.getText());

                if ((!nextNote.equals(null) && !nextNote.equals("")) && listElementIndex == -1) {

                    MainActivity.notes.add(nextNote);
                    MainActivity.arrayAdapter.notifyDataSetChanged();

                    //update shared preferences
                    MainActivity.generalSet.addAll(MainActivity.notes);
                    MainActivity.sharedPreferences.edit().putStringSet("saved notes", MainActivity.generalSet).apply();

                    finish();
                    return true;

                }
                else if ((!nextNote.equals(null) && !nextNote.equals("")) && listElementIndex != -1){

                    MainActivity.notes.remove(listElementIndex);
                    MainActivity.notes.add(listElementIndex, nextNote);
                    MainActivity.arrayAdapter.notifyDataSetChanged();

                    //update shared preferences
                    MainActivity.generalSet.addAll(MainActivity.notes);
                    MainActivity.sharedPreferences.edit().putStringSet("saved notes", MainActivity.generalSet).apply();

                    finish();
                    return true;

                }

        }


        return super.onOptionsItemSelected(item);
    }
}
