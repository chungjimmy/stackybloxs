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

	public GameObject[] particle;

	private int randomParticle;

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

	private float timeToDisplay;

	private float delayParticle;

	private float randomSpawnX;

	private float randomSpawnY;

	private int counter;

	private GameObject particleEffect;

	private float randomSize;

	private Vector3 particleSpawnPoint;
	/// <summary>
	/// initialize blockPos
	/// </summary>
	void Start () {
		randomParticle = 0;
		counter = 0;
		blockPos = gameObject.transform;
		tempSpeed = 2f;
		delayParticle = 0f;
		timeToDisplay = .1f;
		randomSpawnX = 0f;
		randomSpawnY = 0f;
	}
	
	/// <summary>
	/// check to see if blocks hit perfect or great
	/// </summary>
	void Update () {
		if(BlockBehavior.displayPerfect){
			StartCoroutine(DisplayPerfectText(.6f));
		}

		if(BlockBehavior.displayGreat){
			StartCoroutine(DisplayGreatText(.6f));
		}

		if(BlockBehavior.displayCombo){
			StartCoroutine(DisplayCombo(.6f));
		}
		//animation for when block is destroyed
		if(BlockBehavior.displayParticle){
			if(delayParticle <= Time.time){
				randomSpawnX = Random.Range(-.5f, .5f);
				randomSpawnY = Random.Range(-.5f, .5f);
				particleSpawnPoint = new Vector3(blockPos.transform.position.x + randomSpawnX , blockPos.transform.position.y + randomSpawnY, blockPos.transform.position.z);
				randomParticle = Random.Range(0, 6);
				particleEffect = Instantiate(particle[randomParticle], particleSpawnPoint, Quaternion.identity);
				randomSize = Random.Range(-.2f, 1.4f);
				particleEffect.transform.localScale = new Vector3(particleEffect.transform.localScale.x + randomSize, particleEffect.transform.localScale.y + randomSize, particleEffect.transform.localScale.z);
				delayParticle = Time.time + timeToDisplay;
				counter++;
			}

			if(counter > 5){
				counter = 0;
				BlockBehavior.displayParticle = false;
				delayParticle = 0f;
			}
		}

//		if(RainAction.rainSLow){
//			StartCoroutine(RainSlowPlayer(10f));
//		}
//		else{
//			tempSpeed = player.GetComponent<PlayerMovement>().absoluteSpeed;
//		}
//
//		if(WindAction.windStop){
//			StartCoroutine(WindStopPlayer(8f));
//		}


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

//	public IEnumerator DisplayParticle(float s){
//		particle.transform.position = blockPos.transform.position;
//		particle.SetActive(true);
//		yield return new WaitForSeconds(s);
//		particle.SetActive(false);
//		BlockBehavior.displayParticle = false;
//	}
//
//	public IEnumerator RainSlowPlayer(float s){
//		player.GetComponent<PlayerMovement>().absoluteSpeed = 2f;
//		player.transform.GetChild(0).gameObject.SetActive(true);
//		yield return new WaitForSeconds(s);
//		player.transform.GetChild(0).gameObject.SetActive(false);
//		player.GetComponent<PlayerMovement>().absoluteSpeed = tempSpeed;
//		RainAction.rainSLow = false;
//	}
//
//	public IEnumerator WindStopPlayer(float s){
//		player.GetComponent<PlayerMovement>().isStopped = true;
//		yield return new WaitForSeconds(s);
//		WindAction.windStop = false;
//	}
}
