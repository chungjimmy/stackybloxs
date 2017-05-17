using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script is responsible for block behavior when interacting with other game objects
/// </summary>
public class BlockBehavior : MonoBehaviour {

	/// <summary>
	/// an array of the existing blocks in the scene
	/// </summary>
	//private GameObject[] blocks;

	/// <summary>
	/// this game object's collider
	/// </summary>
	private Collider2D collider;

	/// <summary>
	/// the distance (between two blocks) required for the player to achieve a 'perfect'
	/// </summary>
	public float perfect_distance = .1f;

	/// <summary>
	/// the distance (between two blocks) required for the player to achieve a 'great'
	/// </summary>
	public float great_distance = .3f;

	/// <summary>
	/// the distance (between two blocks) required for the player to achieve an 'ok'
	/// </summary>
	public float ok_distance = .5f;

	public float notOk_distance = .7f;

	/// <summary>
	/// Manager gameobject, use to access ManageCoroutines Script
	/// </summary>
	private GameObject manager;

	/// <summary>
	/// The platform
	/// </summary>
	private GameObject platform;

	/// <summary>
	/// boolean to see if greatText need to be displayed, default false
	/// </summary>
	public static bool displayPerfect;

	/// <summary>
	/// boolean to see if greatText need to be displayed, default false
	/// </summary>
	public static bool displayGreat;

	/// <summary>
	/// let manager know when to display combo text
	/// </summary>
	public static bool displayCombo;

	/// <summary>
	/// let manager know when to display particles
	/// </summary>
	public static bool displayParticle;

	/// <summary>
	/// check to see if combo has been reseted alreadywhen block is touching another block/platform
	/// </summary>
	public bool comboReseted;

	public static bool TWOX;
	// Use this for initialization
	/// <summary>
	/// get all current blocks in the scene
	/// get collider component of this game object
	/// </summary>
	void Start () {
		TWOX = false;
		collider = GetComponent<BoxCollider2D>();
		manager = GameObject.FindGameObjectWithTag("Manager");
		platform = GameObject.FindGameObjectWithTag("Platform");
	}

	/// <summary>
	/// hide the block when it falls off the bottom and game ends
	/// game end also if block touches platform twice
	/// </summary>
	/// <param name="other"></param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "Bottom")
		{
			Debug.Log("OVER HERE: bottom");
			Combo.resetCombo();
			manager.GetComponent<GameEnd> ().End ();
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D block){
		try
		{
			if(block.gameObject != manager.gameObject.GetComponent<BlockStack>().PeekBlock()){
				Debug.Log("OVER HERE:peek BLOCK");
				Debug.Log(this.gameObject.GetComponent<SpriteRenderer>().sprite);
				Debug.Log( manager.gameObject.GetComponent<BlockStack>().PeekBlock().gameObject.GetComponent<SpriteRenderer>().sprite);
				manager.GetComponent<GameEnd>().End();
			}
			else if(block.gameObject.tag == "Block"){
				float distance = calculateDistance(block.gameObject);
				if (distance <= perfect_distance)
				{   
					manager.GetComponent<ManageCoroutines>().setBlockPos(gameObject.transform);
					displayPerfect = true;
					comboReseted = false;
					Combo.combo++;
					//Debug.Log(Combo.combo);
					displayCombo = true;
					//mystery block action
					if(this.gameObject.GetComponent<BlockColor>().thisBlockColor == 6
						|| block.gameObject.GetComponent<BlockColor>().thisBlockColor == 6){
						manager.GetComponent<ItemSpawner>().ItemSpawn();
					}
					//increase score
					if(!TWOX){
						CurrentScore.currentScore = CurrentScore.currentScore + (Combo.combo * 2);
					}
					else{
						CurrentScore.currentScore = (CurrentScore.currentScore + (Combo.combo * 2) * 2);
					}
					//display particle effect
					displayParticle = true;

					manager.gameObject.GetComponent<BlockStack>().PopTwoBlocks();

					Destroy(this.gameObject);
					Destroy(block.gameObject);
				}
				else if (distance <= great_distance)
				{                        
					manager.GetComponent<ManageCoroutines>().setBlockPos(gameObject.transform);
					displayGreat = true;
					comboReseted = false;
					Combo.combo++;
					//Debug.Log(Combo.combo);
					displayCombo = true;
					//mystery block action
					if(this.gameObject.GetComponent<BlockColor>().thisBlockColor == 6
						|| block.gameObject.GetComponent<BlockColor>().thisBlockColor == 6){
						manager.GetComponent<ItemSpawner>().ItemSpawn();
					}
					if(!TWOX){
						CurrentScore.currentScore = CurrentScore.currentScore + (Combo.combo * 1);
					}
					else{
						CurrentScore.currentScore = (CurrentScore.currentScore + (Combo.combo * 1) * 2);
					}

					//display particle effect
					displayParticle = true;

					manager.gameObject.GetComponent<BlockStack>().PopTwoBlocks();

					Destroy(this.gameObject);
					Destroy(block.gameObject);
				}
				else if (distance <= ok_distance){
					if(!(comboReseted)){
						Combo.resetCombo();
						comboReseted = true;
						//Debug.Log(Combo.combo);
					} 

				}
				else if (distance > notOk_distance){
					Debug.Log("OVER HERE:not OK");
					this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
					Debug.Log(distance + " > " + notOk_distance);
					manager.GetComponent<GameEnd>().End();
				}
			}
			else if(block.gameObject.tag == "Platform"){
				float platformDistance = calculateDistance(block.gameObject);
				Debug.Log(platformDistance);
				if(platformDistance > 1.4f){
					this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
					Debug.Log(platformDistance + " > " + "1.4");
					Debug.Log("OVER HERE:platform no no");
					manager.GetComponent<GameEnd>().End();
				}
				if(!(comboReseted)){
					Combo.resetCombo();
					comboReseted = true;
				}
			}
		}
		catch { }
		//destroy this script after collission to avoid collission twice
		Destroy(this);
	}

	/// <summary>
	/// calculates the distance between this game object's position and block's position
	/// using the x dist of the object's position 
	/// </summary>
	/// <param name="block">the other game object</param>
	/// <returns>distance between this game object and block</returns>
	private float calculateDistance(GameObject block)
	{
		float x_dist = Mathf.Abs(transform.position.x - block.gameObject.transform.position.x);
		return x_dist;
	}
}
