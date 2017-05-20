using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
	//make a highscore variable of HighScore class
	public static HighScore highscore;

	public Text score;

	int highScore;
	//instantiate highscore
	void Awake(){
		highscore = this;
	}
		
	//highscore is determine after game is over
	public void setHighScore(int score){
		highScore = score;
	}
	//use to get highscore when game is over
	public int getHighScore(){
		return highScore;
	}

	void Update(){
		score.text = "" + highScore;
	}
}
