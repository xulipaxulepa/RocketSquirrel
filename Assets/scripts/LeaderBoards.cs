using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SceneManagement;

public class LeaderBoards : MonoBehaviour {

    private GameObject ldrButton;
    // Use this for initialization
    void Start () {
        ldrButton = GameObject.Find("Leaderboard");
        //  ADD THIS CODE BETWEEN THESE COMMENTS

        // Create client configuration
        PlayGamesClientConfiguration config = new
            PlayGamesClientConfiguration.Builder()
            .Build();

        // Enable debugging output (recommended)
        PlayGamesPlatform.DebugLogEnabled = true;

        // Initialize and activate the platform
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        // END THE CODE TO PASTE INTO START

        // PASTE THESE LINES AT THE END OF Start()
        // Try silent sign-in (second parameter is isSilent)
        PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);                
    }

    public void SignIn()
    {
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            // Sign in with Play Game Services, showing the consent dialog
            // by setting the second parameter to isSilent=false.
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        }
        else
        {
            // Sign out of play games
            PlayGamesPlatform.Instance.SignOut();
            
        }
    }

    public void SignInCallback(bool success)
    {
        if (success)
        {
            Debug.Log("(Rocket Squirrel) Signed in!");

            
        }
        else
        {
            Debug.Log("(Rocket Squirrel) Sign-in failed...");

            
        }
    }

    public void ShowLeaderboards()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIk76nsLwfEAIQAQ");
        }
        else
        {
            Debug.Log("Cannot show leaderboard: not authenticated");
        }
    }

    public void SubmitScore(int score)
    {
        // Submit leaderboard scores, if authenticated
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            // Note: make sure to add 'using GooglePlayGames'
            PlayGamesPlatform.Instance.ReportScore(score,
                GPGSIds.leaderboard_walnuts_caught_in_the_run,
                (bool success) =>
                {
                    Debug.Log("(Rocket Squirrel) Leaderboard update success: " + success);
                });
        }
    }

    // Update is called once per frame
    void Update () {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            ldrButton.SetActive(Social.localUser.authenticated);
        }
    }
}
