using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDuration : MonoBehaviour {
	public GameObject player;
	private float delay;
	public float duration = 8f;
	// Use this for initialization
	void Start () {
		delay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		delay+= Time.deltaTime;
		if(delay < duration){
			player.GetComponent<PlayerMovement>().isStoppedByWind = true;
		}
		else{
			delay = 0f;
			player.GetComponent<PlayerMovement>().isStoppedByWind = false;
			this.gameObject.SetActive(false);
		}
	}
}
