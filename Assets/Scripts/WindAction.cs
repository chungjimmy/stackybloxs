﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAction : MonoBehaviour {

	GameObject player;

	public static bool windStop;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Effect(){
		windStop = true;
		gameObject.SetActive(false);
	}
}
