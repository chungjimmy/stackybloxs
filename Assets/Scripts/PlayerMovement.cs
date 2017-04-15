using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;
	float speed;
	float counter;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		counter = 1;
                speed = 1;
		Vector2 move = new Vector2 (speed*1, 0);
		rb.velocity = (move);
	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector2 move = new Vector2 (speed*1, 0);
		rb.velocity = (move);
	}
	void OnCollisionEnter2D(){
		counter++;
		if (counter % 5 == 0) {
			speed = speed * -1.5f;
		} else {
			speed = -speed;
		}

	}
}
