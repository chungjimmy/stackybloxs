using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {

    public GameObject block;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if the user is touching the screen with any # of fingers
        if (Input.touchCount > 0)
        {
            //get the first touch
            Touch touch = Input.GetTouch(0);

            //instantiate block as soon as the user touched the screen
            if(touch.phase == TouchPhase.Began)
            {
                createBlock();
            }
        }

        //instantiate block on left-click for debugging
        if (Input.GetMouseButtonDown(0))
        {
            createBlock();
        }
    }

    private void createBlock()
    {
        Instantiate(block, transform.position, Quaternion.identity);
    }
}
