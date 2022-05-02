package com.example.socialmediascrapper;

import android.app.ProgressDialog;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.util.Log;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import com.squareup.picasso.Picasso;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class SocialMediaClass extends AppCompatActivity {

    private String url1 = "https://social-back.azurewebsites.net/twitter/shanselman";
    private String url2 = "https://social-back.azurewebsites.net/twitter/shanselman";
    private String url3 = "https://social-back.azurewebsites.net/twitter/shanselman";
    //Twitter Data :
    ImageView profImage;
    TextView tname;
    TextView tav;
    TextView tweb;
    TextView tbio;
    TextView tfoll;
    TextView tfing;
    TextView tjoi;
    TextView tdob;

    //Git Hub data
    TextView gbio;
    TextView glocationl;

    //Insta data
    TextView Ifing;
    TextView Ifoll;
    TextView IsPrivate;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.media_activity);
        profImage = (ImageView)  findViewById(R.id.profimage) ;
        tname = (TextView) findViewById(R.id.tname);
        tav = (TextView) findViewById(R.id.tav);
        tweb = (TextView) findViewById(R.id.tweb);
        tbio = (TextView) findViewById(R.id.tbio);
        tfoll = (TextView) findViewById(R.id.tfoll);
        tfing = (TextView) findViewById(R.id.tfing);
        tjoi = (TextView) findViewById(R.id.tjoi);
        tdob = (TextView) findViewById(R.id.dob);

        //Git Hub
        gbio =(TextView) findViewById(R.id.gbio);
        glocationl =(TextView) findViewById(R.id.glocation);
        //Twitter data
        Ifing = (TextView) findViewById(R.id.ifol);
        Ifoll = (TextView) findViewById(R.id.ifing);
        IsPrivate = (TextView) findViewById(R.id.iprivate);


        ProgressDialog progressBar = new ProgressDialog(this);
        progressBar.setCancelable(true);//you can cancel it by pressing back button
        progressBar.setMessage("File downloading ...");
        progressBar.setProgressStyle(ProgressDialog.STYLE_HORIZONTAL);
        progressBar.setProgress(0);//initially progress is 0
        progressBar.setMax(100);//sets the maximum value 100
        progressBar.show();//displays the progress bar

        ExecutorService executor = Executors.newSingleThreadExecutor();
        Handler handler = new Handler(Looper.getMainLooper());

        executor.execute(new Runnable() {
            @Override
            public void run() {

                String result = "";
                try {
                    URL url;
                    HttpURLConnection urlConnection = null;
                    try {
                        url = new URL(url1);
                        //open a URL coonnection

                        urlConnection = (HttpURLConnection) url.openConnection();

                        InputStream in = urlConnection.getInputStream();

                        InputStreamReader isw = new InputStreamReader(in);

                        int data = isw.read();

                        while (data != -1) {
                            result += (char) data;
                            data = isw.read();

                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                    } finally {
                        if (urlConnection != null) {
                            urlConnection.disconnect();
                        }
                    }

                } catch (Exception e) {
                    e.printStackTrace();
                }
                String finalResult = result;
                handler.post(new Runnable() {
                    @Override
                    public void run() {
                        //UI here
                        try {
                            JSONObject object = new JSONObject(finalResult);
                            String name = object.getString("full_name");
                            tname.append(name);
                            String account_verified = object.getString("account_verified");
                            tav.append(account_verified);
                            String banner = object.getString("banner");
                            Picasso.get()
                                    .load(banner)
                                    .into(profImage);
                            String bio = object.getString("bio");
                            tbio.append(bio);
                            String birth_date = object.getString("birth_date");
                            tdob.append(birth_date);
                            String followers = object.getString("followers");
                            tfoll.append(followers);
                            String following = object.getString("following");
                            tfing.append(following);
                            String joined_date = object.getString("joined_date");
                            tjoi.append(joined_date);
                            String website = object.getString("website");
                            tweb.append(website);

                            progressBar.setProgress(25);

                        } catch (JSONException e) {
                            e.printStackTrace();
                        }

                        Log.d("URL1 Result",""+ finalResult);
                    }
                });
            }
        });

        progressBar.setProgress(25);
        ExecutorService executorGit = Executors.newSingleThreadExecutor();
        Handler handlergit = new Handler(Looper.getMainLooper());

        executorGit.execute(new Runnable() {
            @Override
            public void run() {

                String result = "";
                try {
                    URL url;
                    HttpURLConnection urlConnection = null;
                    try {
                        url = new URL(url2);
                        //open a URL coonnection

                        urlConnection = (HttpURLConnection) url.openConnection();

                        InputStream in = urlConnection.getInputStream();

                        InputStreamReader isw = new InputStreamReader(in);

                        int data = isw.read();

                        while (data != -1) {
                            result += (char) data;
                            data = isw.read();

                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                    } finally {
                        if (urlConnection != null) {
                            urlConnection.disconnect();
                        }
                    }

                } catch (Exception e) {
                    e.printStackTrace();
                }
                String finalResult = result;
                handlergit.post(new Runnable() {
                    @Override
                    public void run() {
                        //UI here
                        try {
                            JSONObject object = new JSONObject(finalResult);
                            String gitBio = object.getString("bio");
                            gbio.append(gitBio);
                            String followers = object.getString("followers");
                            tfoll.append(followers);
                            String following = object.getString("following");
                            tfing.append(following);
                            String gitLocation = object.getString("location");
                            glocationl.append(gitLocation);

                        } catch (JSONException e) {
                            e.printStackTrace();
                        }

                        Log.d("URL1 Result",""+ finalResult);
                    }
                });
            }
        });
        progressBar.setProgress(50);


        ExecutorService executorInsta = Executors.newSingleThreadExecutor();
        Handler handlerInsta = new Handler(Looper.getMainLooper());

        executorInsta.execute(new Runnable() {
            @Override
            public void run() {

                String result = "";
                try {
                    URL url;
                    HttpURLConnection urlConnection = null;
                    try {
                        url = new URL(url3);
                        //open a URL coonnection

                        urlConnection = (HttpURLConnection) url.openConnection();

                        InputStream in = urlConnection.getInputStream();

                        InputStreamReader isw = new InputStreamReader(in);

                        int data = isw.read();

                        while (data != -1) {
                            result += (char) data;
                            data = isw.read();

                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                    } finally {
                        if (urlConnection != null) {
                            urlConnection.disconnect();
                        }
                    }

                } catch (Exception e) {
                    e.printStackTrace();
                }
                String finalResult = result;
                handlerInsta.post(new Runnable() {
                    @Override
                    public void run() {
                        //UI here
                        try {
                            JSONObject object = new JSONObject(finalResult);
                            String iFollowers = object.getString("followers");
                            Ifoll.append(iFollowers);
                            String iFollowing = object.getString("following");
                            Ifing.append(iFollowing);
                            String iprivate = object.getString("is_private");
                            IsPrivate.append(iprivate);
                            progressBar.dismiss();
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }

                        Log.d("URL1 Result",""+ finalResult);
                    }
                });
            }
        });
        progressBar.setProgress(100);
        progressBar.dismiss();
    }



}
