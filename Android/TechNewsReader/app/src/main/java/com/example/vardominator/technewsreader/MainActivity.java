package com.example.vardominator.technewsreader;

import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteStatement;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ExecutionException;

public class MainActivity extends AppCompatActivity {




    // integer: article id; string: the url itself
    Map<Integer, String> articleURLs;
    // integer: article id; string: title
    Map<Integer, String> articleTitles;
    // list of article IDs
    ArrayList<Integer> articleIds;


    // SQL
    SQLiteDatabase articlesDB;


    // UI
    ListView articlesListView;
    ArrayAdapter arrayAdapter;
    ArrayList<String> titles;
    ArrayList<String> urls;


    // saved articles
    static ArrayList<String> savedArticles;


    // fetch JSON data from the web
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

                while (data != -1) {

                    char current = (char) data;
                    result += current;

                    data = reader.read();

                }


            } catch (Exception e) {

                e.printStackTrace();

            }

            return result;

        }

    }


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        DownloadTask task = new DownloadTask();
        //ask for internet permission in the manifest


        // instantiate database
        articlesDB = this.openOrCreateDatabase("Articles", MODE_PRIVATE, null);
        // create table in database
        articlesDB.execSQL("CREATE TABLE IF NOT EXISTS articles (id INTEGER PRIMARY KEY, articleId INTEGER, url VARCHAR, title VARCHAR, content VARCHAR)");



        articleURLs = new HashMap<>();
        articleTitles = new HashMap<>();
        articleIds = new ArrayList<>();


        // UI
        titles = new ArrayList<>();
        urls = new ArrayList<>();


        try {

            // list of the latest posts
            String result = task.execute("https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty").get();

            // create a jsonarray of all the latest articles
            JSONArray jsonArray = new JSONArray(result);

            // ensure that no article is stored more than once
            articlesDB.execSQL("DELETE FROM articles");


            // only the 20 latest articles (default: 500)
            for (int i = 0; i < 20; i++) {

                String articleId = jsonArray.getString(i);

                // create a new task for each fetch
                DownloadTask getArticle = new DownloadTask();

                //Log.i("Article id", jsonArray.getString(i));

                // For each id, extract the article itself using this url: https://hacker-news.firebaseio.com/v0/item/[article id].json?print=pretty

                String articleInfo = getArticle.execute("https://hacker-news.firebaseio.com/v0/item/" + articleId + ".json?print=pretty").get();

                JSONObject jsonObject = new JSONObject(articleInfo);

                String title = jsonObject.getString("title");
                String sourceURL = jsonObject.getString("url");

                // add ids to articleids list
                articleIds.add(Integer.valueOf(articleId));
                articleTitles.put(Integer.valueOf(articleId), title);
                articleURLs.put(Integer.valueOf(articleId), sourceURL);
                urls.add(sourceURL);

                // add to database (must handle potential characters that would cause syntax errors in sql)
                // since we don't have control over data, we must use sql statements
                String sqlCommand = "INSERT INTO articles (articleId, url, title) VALUES (?, ?, ? )";

                SQLiteStatement statement = articlesDB.compileStatement(sqlCommand);

                statement.bindString(1, articleId);
                statement.bindString(2, sourceURL);
                statement.bindString(3, title);

                statement.execute();

            }


            // ensure that cursor selects according to id (correct order of posts)
            Cursor c = articlesDB.rawQuery("SELECT * FROM articles ORDER BY  articleId DESC", null);

            int articleIdIndex = c.getColumnIndex("articleId");
            int urlIndex = c.getColumnIndex("url");
            int titleIndex = c.getColumnIndex("title");

            titles.clear();

            c.moveToFirst();

            while (c != null) {


                //update articles title list
                titles.add(c.getString(titleIndex));


                Log.i("ID", Integer.toString(c.getInt(articleIdIndex)));
                Log.i("Url", c.getString(urlIndex));
                Log.i("Title", c.getString(titleIndex));

                c.moveToNext();

            }

        } catch (Exception e) {
            e.printStackTrace();
        }



        // UI
        articlesListView = (ListView) findViewById(R.id.articleListView);
        arrayAdapter = new ArrayAdapter(this, android.R.layout.simple_list_item_1, titles);
        articlesListView.setAdapter(arrayAdapter);


        articlesListView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                Intent i = new Intent(getApplicationContext(), ArticleViewer.class);
                i.putExtra("selectedURL", urls.get(position));
                startActivity(i);

            }
        });


    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.savedarticles) {

            Intent i = new Intent(getApplicationContext(), SavedArticlesActivity.class);
            startActivity(i);

            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
