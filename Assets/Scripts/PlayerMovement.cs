using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private float counter;
    public GameObject rightBound;
    public GameObject leftBound;
    bool moveRight;
    bool moveLeft;

    // Use this for initialization
    void Start()
    {
        speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= rightBound.transform.position.x)
        {
            speed = -speed;
        }
        else if (transform.position.x <= leftBound.transform.position.x)
        {
            speed = -speed;
        }

        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));


    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Bound")
    //    {
    //        counter++;
    //        if (counter % 5 == 0)
    //        {
    //            speed *= 1.5f;
    //        }
    //        else {
    //            moveRight = !moveRight;
    //        }
    //    }
    //}
}
