﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionHome : MonoBehaviour {

	public GameObject home;

	public float delay;

	// Use this for initialization
	void Start () {
		SaveFile.saveScore.Save();
		SaveFile.saveScore.load();
		delay = 0f;
		Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
	}

	// Update is called once per frame
	void Update () {
		delay += Time.deltaTime;
		if(delay > 1.3f){
			home.SetActive(true);
		}
	}
}
