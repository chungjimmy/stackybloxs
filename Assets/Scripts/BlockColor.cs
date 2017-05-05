using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script is responsible for randomizing the color of spawned blocks
/// </summary>
public class BlockColor : MonoBehaviour {

    /// <summary>
    /// this object's sprite renderer
    /// </summary>
    private SpriteRenderer renderer;

    /// <summary>
    /// the image of the blue block
    /// </summary>
    public Sprite blueBlock;

    /// <summary>
    /// the image of the green block
    /// </summary>
    public Sprite greenBlock;

    /// <summary>
    /// the image of the orange block
    /// </summary>
    public Sprite orangeBlock;

    /// <summary>
    /// the image of the purple block
    /// </summary>
    public Sprite purpleBlock;

    /// <summary>
    /// the image of the red block
    /// </summary>
    public Sprite redBlock;

    /// <summary>
    /// the image of the yellow block
    /// </summary>
    public Sprite yellowBlock;

	/// <summary>
	/// The color of the this block
	/// </summary>
	public int thisBlockColor;

    // Use this for initialization
    /// <summary>
    /// get sprite renderer component and set its sprite to a random colored block
    /// </summary>
    void Start () {
        renderer = GetComponent<SpriteRenderer>();
		randomizeColor(PlayerMovement.COLOR);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// sets the sprite to be a random colored block
    /// </summary>
	private void randomizeColor(int colorNum)
    {
		
        switch (colorNum)
        {
            case 0:
                renderer.sprite = blueBlock;
				thisBlockColor = 0;
                break;
            case 1:
                renderer.sprite = greenBlock;
				thisBlockColor = 1;
                break;
            case 2:
                renderer.sprite = orangeBlock;
				thisBlockColor = 2;
                break;
            case 3:
                renderer.sprite = purpleBlock;
				thisBlockColor = 3;
                break;
            case 4:
                renderer.sprite = redBlock;
				thisBlockColor = 4;
                break;
			case 5:
                renderer.sprite = yellowBlock;
				thisBlockColor = 5;
                break;
        }
    }
}
