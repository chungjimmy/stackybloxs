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
    public float fireRate = 1.2f;

    /// <summary>
    /// the time when the user can create another block
    /// </summary>
    private float nextFire = 0f;

	private Vector3 blockPos;

	private GameObject manager;

//	private SpriteRenderer renderer;

//	public Sprite cloudPlayerDrop;
	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag("Manager");
	}
	
	// Update is called once per frame
    /// <summary>
    /// create a block by tapping, only after the cooldown time has passed
    /// increment speed and stop the player for 0.5s after tapping
    /// </summary>
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (nextFire <= Time.time)
            {
				if(hit.collider != null){
					if(hit.transform.tag != "Item"){
						GetComponent<PlayerMovement>().increaseSpeed();
						StartCoroutine(GetComponent<PlayerMovement>().stopPlayer(0.5f));
						//				renderer.sprite = cloudPlayerDrop;
						createBlock();
					}
				}
				else{
					GetComponent<PlayerMovement>().increaseSpeed();
					StartCoroutine(GetComponent<PlayerMovement>().stopPlayer(0.5f));
					//				renderer.sprite = cloudPlayerDrop;
					createBlock();
				}

            }
			//check to see if player tap itembox
			if(hit.collider != null){
				if(hit.transform.tag == "Item"){
					ItemSpawner.ACTIVEITEM = true;
				}
			}
        }
    }

    /// <summary>
    /// instantiates a block at this game object's position
    /// and sets the next time the user can create another block
    /// </summary>
    private void createBlock()
    {
		blockPos = new Vector3(transform.position.x, transform.position.y - .63f, transform.position.z);
		GameObject blocky = (GameObject)Instantiate(block, blockPos, Quaternion.identity);
		manager.gameObject.GetComponent<BlockStack>().PushBlock(blocky);
        nextFire = Time.time + fireRate;
    }
}
