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
    public float maxSpeed = 20f;

    /// <summary>
    /// the right border of the game screen
    /// </summary>
    public GameObject rightBound;

    /// <summary>
    /// the left border of the game screen
    /// </summary>
    public GameObject leftBound;

    // Use this for initialization
    /// <summary>
    /// increase the game object's speed in 10 seconds, and every 10 seconds after
    /// </summary>
    void Start()
    {
        InvokeRepeating("increaseSpeed", 10f, 10f);
    }

    // Update is called once per frame
    /// <summary>
    /// game object moves right until it reaches or passes the right border, then speed is reversed
    /// game object moves left until it reaches or passes the left border, then speed is reversed
    /// </summary>
    void Update()
    {
        if (transform.position.x >= rightBound.transform.position.x)
        {
            speed = -absoluteSpeed;
        }
        else if (transform.position.x <= leftBound.transform.position.x)
        {
            speed = absoluteSpeed;
        }

        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }

    /// <summary>
    /// increases the magnitude of the speed by 1 unit if it
    /// is less than or equal to the maximum speed
    /// </summary>
    private void increaseSpeed()
    {
        if (speed <= maxSpeed)
        {
            absoluteSpeed += 1f;
        }
    }
}
