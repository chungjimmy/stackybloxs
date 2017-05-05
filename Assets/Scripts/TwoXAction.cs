using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoXAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Effect(){
		Debug.Log("2x");
		gameObject.SetActive(false);
	}
}
