using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDuration : MonoBehaviour {
	public GameObject player;

	private float delay;
	private float tempSpeed;
	public float duration = 8f;
	// Use this for initialization
	void Start () {
		delay = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		//store current player abs speed
		if(delay == 0){
			tempSpeed = player.GetComponent<PlayerMovement>().absoluteSpeed;
		}

		delay += Time.deltaTime;

		if(delay < duration){
			player.GetComponent<PlayerMovement>().absoluteSpeed = 2f;
		}
		else if(delay > duration + 1f){
			delay = 0f;
			this.gameObject.SetActive(false);
		}
		else{
			player.GetComponent<PlayerMovement>().absoluteSpeed = tempSpeed;
		}
	}
}
