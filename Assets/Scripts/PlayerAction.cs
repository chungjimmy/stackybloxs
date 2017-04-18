using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script is responsible for creating a block when the user taps
/// </summary>
public class PlayerAction : MonoBehaviour {

    /// <summary>
    /// the block to be created on a tap
    /// </summary>
    public GameObject block;

    /// <summary>
    /// the cooldown in between taps to create blocks
    /// </summary>
    public float fireRate = 1.0f;

    /// <summary>
    /// the time when the user can create another block
    /// </summary>
    private float nextFire = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    /// <summary>
    /// create a block by tapping, only after the cooldown time has passed
    /// </summary>
	void Update () {
        if (nextFire <= Time.time)
        {
            if (Input.touchCount > 0)
            {
                createBlock();
            }

            if (Input.GetMouseButtonDown(0))
            {
                createBlock();
            }
        }
    }

    /// <summary>
    /// instantiates a block at this game object's position
    /// and sets the next time the user can create another block
    /// </summary>
    private void createBlock()
    {
        Instantiate(block, transform.position, Quaternion.identity);
        nextFire = Time.time + fireRate;
    }
}
