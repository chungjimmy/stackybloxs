using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script is responsible for handling the automatic movement of the player
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// the actual speed the game object is moving at
    /// </summary>
    public float speed = 2f;

    /// <summary>
    /// the magnitude of the speed
    /// </summary>
    public float absoluteSpeed = 2f;

    /// <summary>
    /// the maximum speed the game object will reach
    /// </summary>
    public float maxSpeed = 16f;

    /// <summary>
    /// used to stop the player from moving after tapping
    /// </summary>
    public bool isStopped = false;

    /// <summary>
    /// the right border of the game screen
    /// </summary>
    public GameObject rightBound;

    /// <summary>
    /// the left border of the game screen
    /// </summary>
    public GameObject leftBound;

	/// <summary>
	/// this object's sprite renderer
	/// </summary>
	private SpriteRenderer renderer;

	/// <summary>
	/// the image of the bluePlayer
	/// </summary>
	public Sprite bluePlayer;

	/// <summary>
	/// the image of the greenPlayer
	/// </summary>
	public Sprite greenPlayer;

	/// <summary>
	/// the image of the orangePlayer
	/// </summary>
	public Sprite orangePlayer;

	/// <summary>
	/// the image of the purplePlayer
	/// </summary>
	public Sprite purplePlayer;

	/// <summary>
	/// the image of the redPlayer
	/// </summary>
	public Sprite redPlayer;

	/// <summary>
	/// the image of the yellowPlayer
	/// </summary>
	public Sprite yellowPlayer;

	/// <summary>
	/// The item player.
	/// </summary>
	public Sprite itemPlayer;

	/// <summary>
	/// the image of player dropping a block
	/// </summary>
	public Sprite cloudPlayerDrop;

	/// <summary>
	/// this variable holds the number to a color,
	/// can be access anywhere
	/// </summary>
	public static int COLOR;

    // Use this for initialization
    /// <summary>
    /// increase the game object's speed in 10 seconds, and every 10 seconds after
    /// </summary>
    void Start()
    {
		renderer = GetComponent<SpriteRenderer>();
		COLOR = Random.Range(0, 7);
		switch (COLOR)
		{
			case 0:
				renderer.sprite = bluePlayer;
				break;
			case 1:
				renderer.sprite = greenPlayer;
				break;
			case 2:
				renderer.sprite = orangePlayer;
				break;
			case 3:
				renderer.sprite = purplePlayer;
				break;
			case 4:
				renderer.sprite = redPlayer;
				break;
			case 5:
				renderer.sprite = yellowPlayer;
				break;
			case 6:
				renderer.sprite = itemPlayer;
				break;
		}
    }

    // Update is called once per frame
    /// <summary>
    /// game object moves right until it reaches or passes the right border, then speed is reversed
    /// game object moves left until it reaches or passes the left border, then speed is reversed
    /// </summary>
    void Update()
    {
        if (transform.position.x >= rightBound.transform.position.x - 1.5f)
        {
            speed = -absoluteSpeed;
        }
        else if (transform.position.x <= leftBound.transform.position.x + 1.5f)
        {
            speed = absoluteSpeed;
        }

        if (!isStopped)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

    /// <summary>
    /// increases the magnitude of the speed by 1 unit if it
    /// is less than or equal to the maximum speed
    /// </summary>
    public void increaseSpeed()
    {
		if (speed <= maxSpeed){
            absoluteSpeed += 0.5f;
        }
    }

    /// <summary>
    /// stop player movement for s seconds.
	/// also changes player sprite depending on situation
    /// </summary>
    /// <param name="s">time in seconds</param>
    /// <returns></returns>
    public IEnumerator stopPlayer(float s)
    {
        isStopped = true;
		renderer.sprite = cloudPlayerDrop;
        yield return new WaitForSeconds(s);
		if(WindAction.windStop == false){
        	isStopped = false;
		}

		COLOR = Random.Range(0, 7);
		switch (COLOR)
		{
			case 0:
				renderer.sprite = bluePlayer;
				break;
			case 1:
				renderer.sprite = greenPlayer;
				break;
			case 2:
				renderer.sprite = orangePlayer;
				break;
			case 3:
				renderer.sprite = purplePlayer;
				break;
			case 4:
				renderer.sprite = redPlayer;
				break;
			case 5:
				renderer.sprite = yellowPlayer;
				break;
			case 6:
				renderer.sprite = itemPlayer;
				break;
		}

    }
}
