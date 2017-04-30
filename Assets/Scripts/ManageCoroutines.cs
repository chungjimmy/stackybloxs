using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCoroutines : MonoBehaviour {
	/// <summary>
	/// The great text.
	/// </summary>
	public GameObject greatText;

	/// <summary>
	/// The perfect text.
	/// </summary>
	public GameObject perfectText;

	/// <summary>
	/// The block position.
	/// </summary>
	private Transform blockPos;
	// Use this for initialization

	/// <summary>
	/// initialize blockPos
	/// </summary>
	void Start () {
		blockPos = gameObject.transform;
	}
	
	/// <summary>
	/// check to see if blocks hit perfect or great
	/// </summary>
	void Update () {
		if(BlockBehavior.displayPerfect){
			StartCoroutine(DisplayPerfectText(.2f));
		}

		if(BlockBehavior.displayGreat){
			StartCoroutine(DisplayGreatText(.2f));
		}
	}
	/// <summary>
	/// Display the perfect text.
	/// </summary>
	/// <returns>The perfect text.</returns>
	/// <param name="s">S.</param>
	public IEnumerator DisplayPerfectText(float s)
	{		
		perfectText.transform.position = blockPos.transform.position;
		perfectText.SetActive(true);
		//Debug.Log(WaitForSeconds(s));
		yield return new WaitForSeconds(s);
		BlockBehavior.displayPerfect = false;
		perfectText.SetActive(false);
	}
	/// <summary>
	/// Display the great text.
	/// </summary>
	/// <returns>The great text.</returns>
	/// <param name="s">S.</param>
	public IEnumerator DisplayGreatText(float s)
	{
		greatText.transform.position = blockPos.transform.position;
		greatText.SetActive(true);
		//Debug.Log(WaitForSeconds(s));
		yield return new WaitForSeconds(s);
		BlockBehavior.displayGreat = false;
		greatText.SetActive(false);
	}
	/// <summary>
	/// Sets the block position.
	/// </summary>
	/// <param name="obj">Object.</param>
	public void setBlockPos(Transform obj){
		blockPos.position = obj.position;
	}
}
