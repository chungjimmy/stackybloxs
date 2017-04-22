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
    public float perfect_distance = 1f;

    /// <summary>
    /// the distance (between two blocks) required for the player to achieve a 'great'
    /// </summary>
    public float great_distance = 1.05f;

    /// <summary>
    /// the distance (between two blocks) required for the player to achieve an 'ok'
    /// </summary>
    public float ok_distance = 1.1f;

    /// <summary>
    /// hide the block when it falls off the bottom
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Bottom")
        {
            Destroy(this.gameObject);
          //  this.gameObject.SetActive(false);
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
	}
	
	// Update is called once per frame
    /// <summary>
    /// calculate distance between blocks
    /// if perfect, great, or ok, hide blocks
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
                        Debug.Log("Perfect " + distance);
                        ///this.gameObject.SetActive(false);
                        //block.gameObject.SetActive(false);
                        CurrentScore.currentScore += 2;
                        Destroy(this.gameObject);
                        Destroy(block.gameObject);
                        
                        
                    }
                    else if (distance <= great_distance)
                    {
                        Debug.Log("Great " + distance);
                        // this.gameObject.SetActive(false);
                        //block.gameObject.SetActive(false);
                        CurrentScore.currentScore++;
                        Destroy(this.gameObject);
                        Destroy(block.gameObject);
                        
                    }
                    else if (distance <= ok_distance)
                    {
                        Debug.Log("OK " + distance);
                    }
                }
            }
        }
        catch { }
	}

    /// <summary>
    /// calculates the distance between this game object's position and block's position
    /// using the pythagorean theorem
    /// </summary>
    /// <param name="block">the other game object</param>
    /// <returns>distance between this game object and block</returns>
    private float calculateDistance(GameObject block)
    {
        float x_dist = Mathf.Abs(transform.position.x - block.gameObject.transform.position.x);
        float y_dist = Mathf.Abs(transform.position.y - block.gameObject.transform.position.y);
        return Mathf.Sqrt(Mathf.Pow(x_dist, 2) + Mathf.Pow(y_dist, 2));
    }
}
