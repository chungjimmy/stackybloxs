using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderAction : MonoBehaviour {

	private GameObject[] blocks;

	private GameObject manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag("Manager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Effect(){
		blocks = GameObject.FindGameObjectsWithTag("Block");
		foreach (GameObject block in blocks){
			Destroy(block.gameObject);
		}
		manager.gameObject.GetComponent<BlockStack>().ClearAllBlock();
		gameObject.SetActive(false);
	}
}
