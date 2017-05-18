using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GooglePlayServices : MonoBehaviour {

    /// <summary>
    /// the high score leaderboard ID
    /// </summary>
    private string leaderboard = "CgkI2InWgYYbEAIQAQ";

    // Use this for initialization
    void Awake()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .EnableSavedGames()
            .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// prompts user to log in
    /// </summary>
    public void login()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("login success");
            }
            else
            {
                Debug.Log("login failed");
            }
        });
    }

    /// <summary>
    /// logs out the user
    /// </summary>
    public void logout()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
    }

    /// <summary>
    /// show leaderboard if user is logged in or prompt user to log in if not
    /// </summary>
    public void showLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
            ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboard);
        }
        else
        {
            login();
        }
    }

    /// <summary>
    /// update the user's score on the leaderboard
    /// </summary>
    /// <param name="score">the score to submit to the leaderboard</param>
    public void postToLeaderboard(int score)
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(score, leaderboard, (bool success) =>
            {
                if (success)
                {
                    Debug.Log("post to leaderboard success");
                }
                else
                {
                    Debug.Log("post to leaderboard failed");
                }
            });
        }
    }
}
