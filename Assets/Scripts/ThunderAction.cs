using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderAction : MonoBehaviour {

	private GameObject[] blocks;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Effect(){
		blocks = GameObject.FindGameObjectsWithTag("Block");
		foreach (GameObject block in blocks){
			Destroy(block.gameObject);
		}
		gameObject.SetActive(false);
	}
}
