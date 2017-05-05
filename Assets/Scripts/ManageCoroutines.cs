﻿using System.Collections;
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
	/// The player.
	/// </summary>
	public GameObject player;

	/// <summary>
	/// hold current player speed
	/// </summary>
	private float tempSpeed;

	/// <summary>
	/// The block position.
	/// </summary>
	private Transform blockPos;
	// Use this for initialization

	public GameObject comboText;

	private GameObject combo;

	private float delay = 0f;
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
			StartCoroutine(DisplayPerfectText(.3f));
		}

		if(BlockBehavior.displayGreat){
			StartCoroutine(DisplayGreatText(.3f));
		}

		if(BlockBehavior.displayCombo){
			StartCoroutine(DisplayCombo(.3f));
		}

		if(RainAction.rainSLow){
			StartCoroutine(SlowPlayer(8f));
		}
		else{
			tempSpeed = player.GetComponent<PlayerMovement>().absoluteSpeed;
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
		greatText.SetActive(false);
		BlockBehavior.displayGreat = false;
	}
	/// <summary>
	/// Sets the block position.
	/// </summary>
	/// <param name="obj">Object.</param>
	public void setBlockPos(Transform obj){
		blockPos.position = obj.position;
	}

	public IEnumerator DisplayCombo(float s){
		if((Combo.combo-1) >= 0 && (Combo.combo-1) <= 4){
			combo = comboText.transform.GetChild(Combo.combo-1).gameObject;
			combo.gameObject.SetActive(true);		
			yield return new WaitForSeconds(s);
			combo.gameObject.SetActive(false);			
			BlockBehavior.displayCombo = false;
		}
	}

	public IEnumerator SlowPlayer(float s){
		player.GetComponent<PlayerMovement>().absoluteSpeed = 2f;
		yield return new WaitForSeconds(s);
		player.GetComponent<PlayerMovement>().absoluteSpeed = tempSpeed;
		RainAction.rainSLow = false;
	}
}
