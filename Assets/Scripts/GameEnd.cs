using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour {
    /// <summary>
    /// player gameobject, use to disable player when game is over
    /// </summary>
    public GameObject player;

    /// <summary>
    /// gameover text gameobject, use to disable gameover text
    /// </summary>
    public GameObject gameOver;
    /// <summary>
    /// a boolean, use with exit boolean to check if game should be over
    /// </summary>
    private bool enter = false;

    /// <summary>
    /// a boolean, use with enter boolean to check if game should be over
    /// </summary>
    private bool exit = false;

    /// <summary>
    /// a float, use to delay checking between enter and exit of LoseLine
    /// </summary>
    private float delay = 1f;

    /// <summary>
    /// a int, use to to determine the state of the game
    /// when block is in LoseLine but may still not lose
    /// </summary>
    private int scoreTracker = 0;

    /// <summary>
    /// a 2d trigger, see if a block has enter LoseLine
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Block")
        {
            enter = true;
        }
    }

    /// <summary>
    /// a 2d trigger, see if a block has exit LoseLine
    /// It also stores currentscore into scoreTracker
    /// </summary>
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Block")
        {
            scoreTracker = CurrentScore.currentScore;
            exit = true;
        }
    }

    /// <summary>
    /// this update determines if player loses game or not
    /// checks if block passes LoseLine by meeting enter
    /// and exit trigger
    /// scoreTracker determines if player should still be in game
    /// eventhough block never trigger exit,
    /// player should still be in game if block earns player points
    /// </summary>
    void Update() {

        if (enter == true) {
            delay += Time.deltaTime;
            if (delay > 1.3f) {
                if (exit == false && scoreTracker == CurrentScore.currentScore) {
                    player.SetActive(false);
                    gameOver.SetActive(true);
                }
                delay = 1f;
                enter = false;
                exit = false;
            }
        }
    }
}
