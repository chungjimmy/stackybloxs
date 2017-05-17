using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPlay : MonoBehaviour {

	public GameObject player;

	public GameObject platform;

	public GameObject loseLine;

	public GameObject background1;

	public GameObject itemBox;

	public GameObject score;

	public GameObject logo;

	public GameObject manager;

	public float delay;

	// Use this for initialization
	void Start () {
		delay = 0f;
		Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
	}
	
	// Update is called once per frame
	void Update () {
		delay += Time.deltaTime;
		if(delay > 1f){
			logo.SetActive(false);
			manager.gameObject.GetComponent<Tutorial>().enabled = true;
			player.SetActive(true);
			platform.SetActive(true);
			loseLine.SetActive(true);
			background1.SetActive(true);
			itemBox.SetActive(true);
			score.SetActive(true);
		}
	}
}
