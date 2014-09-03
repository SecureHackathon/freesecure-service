package geekulcha.hack.freesecure;

import org.json.JSONArray;
import org.json.JSONObject;

import android.app.Activity;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;

public class MainActivity extends ActionBarActivity implements
    NavigationDrawerFragment.NavigationDrawerCallbacks {

  /**
   * Fragment managing the behaviors, interactions and presentation of the
   * navigation drawer.
   */
  private NavigationDrawerFragment mNavigationDrawerFragment;

  /**
   * Used to store the last screen title. For use in {@link #restoreActionBar()}
   * .
   */
  private CharSequence mTitle;
  static RequestQueue queue;

  @Override
  protected void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.activity_main);
    mNavigationDrawerFragment = (NavigationDrawerFragment) getSupportFragmentManager()
        .findFragmentById(R.id.navigation_drawer);
    mTitle = getTitle();
    queue = Volley.newRequestQueue(this);

    // Set up the drawer.
    mNavigationDrawerFragment.setUp(R.id.navigation_drawer,
        (DrawerLayout) findViewById(R.id.drawer_layout));
  }

  @Override
  public void onNavigationDrawerItemSelected(int position) {
    // update the main content by replacing fragments
    FragmentManager fragmentManager = getSupportFragmentManager();
    fragmentManager.beginTransaction()
        .replace(R.id.container, PlaceholderFragment.newInstance(position + 1))
        .commit();
  }

  public void onSectionAttached(int number) {
    switch (number) {
    case 0:
      mTitle = getString(R.string.title_section1);
      break;
    case 1:
      mTitle = getString(R.string.title_section2);
      break;
    }
  }

  public void restoreActionBar() {
    ActionBar actionBar = getSupportActionBar();
    actionBar.setNavigationMode(ActionBar.NAVIGATION_MODE_STANDARD);
    actionBar.setDisplayShowTitleEnabled(true);
    actionBar.setTitle(mTitle);
  }

  @Override
  public boolean onCreateOptionsMenu(Menu menu) {
    if (!mNavigationDrawerFragment.isDrawerOpen()) {
      // Only show items in the action bar relevant to this screen
      // if the drawer is not showing. Otherwise, let the drawer
      // decide what to show in the action bar.
      getMenuInflater().inflate(R.menu.main, menu);
      restoreActionBar();
      return true;
    }
    return super.onCreateOptionsMenu(menu);
  }

  @Override
  public boolean onOptionsItemSelected(MenuItem item) {
    // Handle action bar item clicks here. The action bar will
    // automatically handle clicks on the Home/Up button, so long
    // as you specify a parent activity in AndroidManifest.xml.
    int id = item.getItemId();
    if (id == R.id.action_settings) {
      return true;
    }
    return super.onOptionsItemSelected(item);
  }

  /**
   * A placeholder fragment containing a simple view.
   */
  public static class PlaceholderFragment extends Fragment implements
      OnClickListener {
    /**
     * The fragment argument representing the section number for this fragment.
     */
    private static final String ARG_SECTION_NUMBER = "section_number";
    View rootView;
    Button Getter;
    Button Gets;
    TextView Getting;
    int section;

    /**
     * Returns a new instance of this fragment for the given section number.
     */
    public static PlaceholderFragment newInstance(int sectionNumber) {
      PlaceholderFragment fragment = new PlaceholderFragment();
      Bundle args = new Bundle();
      args.putInt(ARG_SECTION_NUMBER, sectionNumber);
      fragment.setArguments(args);
      return fragment;
    }

    public PlaceholderFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
        Bundle savedInstanceState) {
      rootView = inflater.inflate(R.layout.fragment_main, container, false);
      section = getArguments().getInt("ARG_SECTION_NUMBER");
      
      TextView textView = (TextView) rootView.findViewById(R.id.section_label);
      textView.setText(Integer.toString(getArguments().getInt(
          ARG_SECTION_NUMBER)));
      
      Getting = (TextView) rootView.findViewById(R.id.txtGet);
      Getter = (Button) rootView.findViewById(R.id.btnGet);
      Gets = (Button) rootView.findViewById(R.id.btnGetCam);
      
      Getter.setOnClickListener(this);
      Gets.setOnClickListener(this);

      return rootView;
    }
    @Override
    public void onAttach(Activity activity) {
      super.onAttach(activity);
      ((MainActivity) activity).onSectionAttached(getArguments().getInt(
          ARG_SECTION_NUMBER));
    }

    @Override
    public void onClick(View v) {
      // TODO Auto-generated method stub
      Getting.setText(String.valueOf(section));
      switch (v.getId()) {
      case R.id.btnGet:
        // call the
        final String url = "https://freesecure.apphb.com/api/image/";// lnk

        // prepare the Request
        JsonArrayRequest getRequest = new JsonArrayRequest(url,
            new Response.Listener<JSONArray>() {

              @Override
              public void onResponse(JSONArray response) {
                // TODO Auto-generated method stub
                JSONObject Values = new JSONObject();
                Log.d("Response Image >>>>>>>>>", response.toString());
                for (int i = 0; i < response.length(); i++) {
                  try {
                    Values = response.getJSONObject(i);
                    String url = Values.getString("Url");
                    Log.d("Lebo", url);
                  } catch (Exception ex) {
                    Log.d("Lebo Response Image >>>>>>>", ex.getMessage());
                  }
                }
                
              }
            }, new Response.ErrorListener() {
              @Override
              public void onErrorResponse(VolleyError error) {
                Log.d("Error.Response", error.getMessage());
              }
            });
        // add it to the RequestQueue
        queue.add(getRequest);
        break;

      case R.id.btnGetCam:
        // call the
        final String url1 = "http://freesecure.apphb.com/api/camera/";// lnk

        // prepare the Request
        JsonArrayRequest getRequest1 = new JsonArrayRequest(url1,
            new Response.Listener<JSONArray>() {

              @Override
              public void onResponse(JSONArray response) {
                // TODO Auto-generated method stub
                Log.d("Response Camera >>>>>>>>>>>", response.toString());
              }
            }, new Response.ErrorListener() {
              @Override
              public void onErrorResponse(VolleyError error) {
                Log.d("Error.Response", error.getMessage());
              }
            });
        // add it to the RequestQueue
        queue.add(getRequest1);
        break;

      }
    }
  }
}