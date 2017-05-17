using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoXAction : MonoBehaviour {

	public GameObject indicator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Effect(){
		indicator.SetActive(true);
		gameObject.SetActive(false);
	}
}
