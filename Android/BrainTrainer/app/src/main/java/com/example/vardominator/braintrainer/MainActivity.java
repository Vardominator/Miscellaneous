package com.example.vardominator.braintrainer;

import android.os.Bundle;
import android.os.CountDownTimer;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Button;
import android.widget.GridLayout;
import android.widget.TextView;

import org.w3c.dom.Text;

import java.util.ArrayList;
import java.util.Random;

public class MainActivity extends AppCompatActivity {


    Button startButton;
    ArrayList<Integer> answers = new ArrayList<>();
    TextView resultTextView;
    TextView pointsTextView;
    int locOfCorrectAns;
    int score = 0;
    int numberOfQuestions = 0;

    Button button0;
    Button button1;
    Button button2;
    Button button3;

    TextView sumTextView;
    TextView timerTextView;

    GridLayout gridLayout;

    public void start(View view) {

        generateQuestion();

        score = 0;
        numberOfQuestions = 0;

        timerTextView.setText("30s");
        pointsTextView.setText("0/0");
        resultTextView.setText("");

        startButton.setVisibility(View.INVISIBLE);

        gridLayout.setVisibility(View.VISIBLE);
        pointsTextView.setVisibility(View.VISIBLE);
        sumTextView.setVisibility(View.VISIBLE);
        timerTextView.setVisibility(View.VISIBLE);
        resultTextView.setVisibility(View.VISIBLE);


        new CountDownTimer(30000, 1000) {

            @Override
            public void onTick(long millisUntilFinished) {
                timerTextView.setText(String.valueOf(millisUntilFinished / 1000) + "s");
            }

            @Override
            public void onFinish() {

                timerTextView.setText("0s");
                resultTextView.setText("Score: " + Integer.toString(score)+"/"+Integer.toString(numberOfQuestions));

                gridLayout.setVisibility(View.INVISIBLE);
                pointsTextView.setVisibility(View.INVISIBLE);
                sumTextView.setVisibility(View.INVISIBLE);
                resultTextView.setVisibility(View.VISIBLE);

                startButton.setVisibility(View.VISIBLE);

            }
        }.start();

    }


    public void generateQuestion() {

        int min = 0;
        int max = 20;
        int rand;
        rand = (int)(min + Math.random() * (max - min));


        answers.clear();

        Random rand2 = new Random();

        int a = (int)(min + Math.random() * (max - min));
        int b = (int)(min + Math.random() * (max - min));
        int sum = a + b;
        sumTextView.setText(Integer.toString(a) + " + " + Integer.toString(b));

        locOfCorrectAns = (int)(min + Math.random() * (4 - 0));

        int incorrectAnswer;

        for (int i = 0; i < 4; i++){

            if (i == locOfCorrectAns){
                answers.add(i, a + b);
            }
            else {

                incorrectAnswer = (int)(min + Math.random() * (max - min));

                while (incorrectAnswer == (a + b)) {

                    incorrectAnswer = (int)(min + Math.random() * (max - min));

                }

                answers.add(i,incorrectAnswer);
            }

            Log.i("Random number: ", Integer.toString(answers.get(i)));

        }

        button0.setText(Integer.toString(answers.get(0)));
        button1.setText(Integer.toString(answers.get(1)));
        button2.setText(Integer.toString(answers.get(2)));
        button3.setText(Integer.toString(answers.get(3)));

    }


    public void chooseAnswer(View view) {

        Log.i("Tag", (String) view.getTag());

        if (view.getTag().toString().equals(Integer.toString(locOfCorrectAns))) {

            Log.i("correct", "correct selected");
            score++;
            resultTextView.setText("Correct!");

        } else {

            resultTextView.setText("Wrong!");

        }
        numberOfQuestions++;

        pointsTextView.setText(Integer.toString(score) + "/" + Integer.toString(numberOfQuestions));

        generateQuestion();


    }



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        gridLayout = (GridLayout) findViewById(R.id.gridLayout);

        startButton = (Button)findViewById(R.id.startButton);
        sumTextView = (TextView)findViewById(R.id.sumTextView);

        resultTextView = (TextView) findViewById(R.id.resultTextView);
        pointsTextView = (TextView) findViewById(R.id.pointsTextView);

        button0 = (Button) findViewById(R.id.button0);
        button1 = (Button) findViewById(R.id.button1);
        button2 = (Button) findViewById(R.id.button2);
        button3 = (Button) findViewById(R.id.button3);
        timerTextView = (TextView) findViewById(R.id.timerTextView);

        gridLayout.setVisibility(View.INVISIBLE);
        pointsTextView.setVisibility(View.INVISIBLE);
        sumTextView.setVisibility(View.INVISIBLE);
        timerTextView.setVisibility(View.INVISIBLE);
        resultTextView.setVisibility(View.INVISIBLE);

        startButton.setVisibility(View.VISIBLE);
        //start(startButton);


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
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
