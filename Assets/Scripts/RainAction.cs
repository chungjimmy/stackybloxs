using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainAction : MonoBehaviour {

	public static bool rainSLow;
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Effect(){
//		rainSLow = true;
		player.transform.GetChild(0).gameObject.SetActive(true);
		gameObject.SetActive(false);
	}
}
