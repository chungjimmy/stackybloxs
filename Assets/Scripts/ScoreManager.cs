using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	/// <summary>
	/// int to store player score
	/// </summary>
	public static int score;

	/// <summary>
	/// text to display score
	/// </summary>
	Text text;

	void Awake () {
		text = GetComponent<Text> ();
		score = 0;
	}

	// Update is called once per frame
	/// <summary>
	/// Display score each frame
	/// check if score is updated from blockBehavior
	/// </summary>
	void Update () {
		text.text = "Score: " + score;
	}
}
