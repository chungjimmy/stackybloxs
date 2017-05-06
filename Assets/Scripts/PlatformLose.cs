using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLose : MonoBehaviour {
	private Collider2D collider;
	private GameObject block;
	public GameObject manager;
	public static int BLOCKCOUNTER;
	// Use this for initialization
	void Start () {
		BLOCKCOUNTER = 0;
		collider = GetComponent<BoxCollider2D>();
		manager = GameObject.FindGameObjectWithTag("Manager");
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Block"){
			BLOCKCOUNTER++;
		}
	}

	// Update is called once per frame
	void Update () {
		if (BLOCKCOUNTER > 1) {
			BLOCKCOUNTER = 0;
			manager.gameObject.GetComponent<GameEnd> ().End();
		}
	}
}
