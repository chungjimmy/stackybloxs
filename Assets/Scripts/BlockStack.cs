using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStack : MonoBehaviour {
	/// <summary>
	/// stack to store platform and block in
	/// use to keep track of which block is on top
	/// </summary>
	public GameObject[] STACK;

	/// <summary>
	/// counter for stack gameobject array
	/// points to next space in array
	/// </summary>
	private static int COUNTER;

	/// <summary>
	/// The platform.
	/// </summary>
	public GameObject platform;

	// Use this for initialization
	void Start () {
		STACK = new GameObject[8];
		STACK[0] = platform;
		COUNTER = 1;
		for(int i = 1; i < 8; i++){
			STACK[i] = null;
		}
	}

	/// <summary>
	/// Pushs the block.
	/// </summary>
	/// <param name="block">Block.</param>
	public void PushBlock(GameObject block){
		STACK[COUNTER] = block;
		COUNTER ++;
	}

	/// <summary>
	/// Pops two block when perfect/great drop
	/// </summary>
	public void PopTwoBlocks(){
		if(COUNTER > 2){
			COUNTER--;
			STACK[COUNTER] = null;
			COUNTER--;
			STACK[COUNTER] = null;
		}
	}

	public GameObject PeekBlock(){
		return STACK[COUNTER - 2];
	}

	public void ClearAllBlock(){
		for(int i = 1; i < 8; i++){
			STACK[i] = null;
		}
		COUNTER = 1;
	}
}
