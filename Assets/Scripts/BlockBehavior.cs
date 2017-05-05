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
	private GameObject[] blocks;

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

	/// <summary>
	/// Manager gameobject, use to access ManageCoroutines Script
	/// </summary>
	private GameObject manager;

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
	/// check to see if combo has been reseted alreadywhen block is touching another block/platform
	/// </summary>
	public bool comboReseted;

    /// <summary>
    /// hide the block when it falls off the bottom
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Bottom")
        {
            Combo.resetCombo();
            Destroy(this.gameObject);
        }
    }

	// Use this for initialization
	/// <summary>
	/// get all current blocks in the scene
	/// get collider component of this game object
	/// </summary>
	void Start () {
		blocks = GameObject.FindGameObjectsWithTag("Block");
		collider = GetComponent<BoxCollider2D>();
		manager = GameObject.FindGameObjectWithTag("Manager");

	}

	// Update is called once per frame
	/// <summary>
	/// calculate distance between blocks
	/// if perfect, great, or ok, hide blocks and update score
	/// else the blocks will stack
	/// </summary>
	void Update () {
		try
		{
			foreach (GameObject block in blocks)
			{
				if (collider.IsTouching(block.GetComponent<BoxCollider2D>()))
				{

					float distance = calculateDistance(block);

                    if (distance <= perfect_distance)
                    {   
						manager.GetComponent<ManageCoroutines>().setBlockPos(gameObject.transform);
						displayPerfect = true;
						comboReseted = false;
						Combo.combo++;
						Debug.Log(Combo.combo);
						displayCombo = true;

						if(this.gameObject.GetComponent<BlockColor>().thisBlockColor == 4
							|| block.gameObject.GetComponent<BlockColor>().thisBlockColor == 4){
							//Debug.Log("hi hi hi");
							manager.GetComponent<ItemSpawner>().ItemSpawn();
						}

                        CurrentScore.currentScore = CurrentScore.currentScore + (Combo.combo * 2);
                        Destroy(this.gameObject);
                        Destroy(block.gameObject);
                    }
                    else if (distance <= great_distance)
                    {                        
						manager.GetComponent<ManageCoroutines>().setBlockPos(gameObject.transform);
						displayGreat = true;
						comboReseted = false;
						Combo.combo++;
						Debug.Log(Combo.combo);
						displayCombo = true;

						if(this.gameObject.GetComponent<BlockColor>().thisBlockColor == 4
							|| block.gameObject.GetComponent<BlockColor>().thisBlockColor == 4){
							Debug.Log("hi hi hi");
							manager.GetComponent<ItemSpawner>().ItemSpawn();
						}

                        CurrentScore.currentScore = CurrentScore.currentScore + (Combo.combo * 1);
                        Destroy(this.gameObject);
                        Destroy(block.gameObject);
                    }
                    else if (distance <= ok_distance)
                    {
						if(!(comboReseted)){
                        	Combo.resetCombo();
							comboReseted = true;
							Debug.Log(Combo.combo);
						}

                    }
                }
            }
        }
        catch { }

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
