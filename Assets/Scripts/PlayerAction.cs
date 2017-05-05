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

	private Vector3 blockPos;

//	private SpriteRenderer renderer;

//	public Sprite cloudPlayerDrop;
	// Use this for initialization
	void Start () {
//		renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
    /// <summary>
    /// create a block by tapping, only after the cooldown time has passed
    /// increment speed and stop the player for 0.5s after tapping
    /// </summary>
	void Update () {
        if (nextFire <= Time.time)
        {
            if (Input.GetMouseButtonDown(0))
            {
//				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//				RaycastHit2D hit;
//				if(Physics2D.Raycast(ray, out hit)){
//					if(hit.transform.name == "ItemBox"){
//						Debug.Log("hi hi hi");
//					}

				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
				if(hit.collider != null){
					if(hit.transform.tag == "Item"){
						ItemSpawner.ACTIVEITEM = true;
					}
					else{
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
        }
    }

    /// <summary>
    /// instantiates a block at this game object's position
    /// and sets the next time the user can create another block
    /// </summary>
    private void createBlock()
    {
		blockPos = new Vector3(transform.position.x, transform.position.y - .63f, transform.position.z);
		Instantiate(block, blockPos, Quaternion.identity);
        nextFire = Time.time + fireRate;
    }
}
