using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoXDuration : MonoBehaviour {
	private float delay;
	public float duration = 6f;
	// Use this for initialization
	void Start () {
		delay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		delay += Time.deltaTime;
		if(delay < duration){
			BlockBehavior.TWOX = true;
		}
		else{
			delay = 0f;
			BlockBehavior.TWOX = false;
			this.gameObject.SetActive(false);
		}
	}
}
