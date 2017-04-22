using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour {
    /// <summary>
    /// initialize current score
    /// </summary>
	public static int currentScore = 0;

    /// <summary>
    /// game scene CurrentScore text object
    /// </summary>
	public Text cScore;

    /// <summary>
    /// current score that can be accessed anywhere
    /// </summary>
	public static CurrentScore _cScore;

    /// <summary>
    /// all CurrentScore will be assign to same script
    /// </summary>
	void Awake(){
		_cScore = this;
	}
	
	// Update is called once per frame
    /// <summary>
    /// update current score
    /// </summary>
	void Update () {
		cScore.text = currentScore.ToString();
	}
}
