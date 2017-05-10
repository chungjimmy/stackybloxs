using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

	public GameObject tut;
	public GameObject player;
	public GameObject itemBox;
	public bool playTut;

	private bool step1, step2, step3, step4, step5;
	//cheks if player is in tutorial or not
	public static bool INTUTORIAL;


	// Use this for initialization
	void Start () {

		if(PlayerPrefs.GetInt("noob") == 1){
			Debug.Log("Tutorial is turned off");
		}
		else{
			Debug.Log("Tutorial is turned on");
		}

		if(playTut){
			PlayerPrefs.SetInt("noob", 0);
			PlayerPrefs.Save();
		}
			
		if(!PlayerPrefs.HasKey("noob") || PlayerPrefs.GetInt("noob") != 1){
			INTUTORIAL = true;
			step1 = true;
			player.gameObject.GetComponent<PlayerMovement>().isStopped = true;
			tut.transform.GetChild(0).gameObject.SetActive(true);
			tut.transform.GetChild(1).gameObject.SetActive(true);
			tut.transform.GetChild(4).gameObject.SetActive(true);
		}
		else{
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(step5){
			player.gameObject.GetComponent<PlayerMovement>().isStopped = true;
			tut.transform.GetChild(1).gameObject.SetActive(true);
			tut.transform.GetChild(8).gameObject.SetActive(true);

			if (Input.GetMouseButtonDown(0)){
				tut.transform.GetChild(1).gameObject.SetActive(false);
				tut.transform.GetChild(8).gameObject.SetActive(false);
				player.gameObject.GetComponent<PlayerMovement>().isStopped = false;
				player.gameObject.GetComponent<PlayerAction>().enabled = true;
				step5 = false;
				step1 = true;
				PlayerPrefs.SetInt("noob", 1);
				PlayerPrefs.Save();
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
				INTUTORIAL = false;
				this.enabled = false;
			}
		}
		//lose
		if(step4){
			player.gameObject.GetComponent<PlayerMovement>().isStopped = true;
			tut.transform.GetChild(3).gameObject.SetActive(true);
			tut.transform.GetChild(7).gameObject.SetActive(true);
			tut.transform.GetChild(1).gameObject.SetActive(true);
			tut.transform.GetChild(9).gameObject.SetActive(true);

			if (Input.GetMouseButtonDown(0)){
				player.gameObject.GetComponent<PlayerMovement>().isStopped = true;
				tut.transform.GetChild(3).gameObject.SetActive(false);
				tut.transform.GetChild(7).gameObject.SetActive(false);
				tut.transform.GetChild(1).gameObject.SetActive(false);
				tut.transform.GetChild(9).gameObject.SetActive(false);
				step4 = false;
				step5 = true;
			}
		}
		//item
		if(step3){
			if(player.transform.position.x > 0){
				player.gameObject.GetComponent<PlayerMovement>().isStopped = true;
				tut.transform.GetChild(0).gameObject.SetActive(true);
				tut.transform.GetChild(2).gameObject.SetActive(true);
				tut.transform.GetChild(6).gameObject.SetActive(true);
				tut.transform.GetChild(1).gameObject.SetActive(true);
				tut.transform.GetChild(9).gameObject.SetActive(true);
				itemBox.GetComponent<SpriteRenderer>().sortingOrder = 11;

				if (Input.GetMouseButtonDown(0)){
					player.gameObject.GetComponent<PlayerMovement>().isStopped = true;
					itemBox.GetComponent<SpriteRenderer>().sortingOrder = 6;
					tut.transform.GetChild(2).gameObject.SetActive(false);
					tut.transform.GetChild(6).gameObject.SetActive(false);
					tut.transform.GetChild(1).gameObject.SetActive(false);
					tut.transform.GetChild(9).gameObject.SetActive(false);
					step3 = false;
					step4 = true;
				}
			}
			else{
				player.gameObject.GetComponent<PlayerAction>().enabled = false;
			}
		}
		//drop block onto block
		if(step2){
			if(player.transform.position.x < 0){
				player.gameObject.GetComponent<PlayerMovement>().isStopped = true;
				tut.transform.GetChild(0).gameObject.SetActive(true);
				tut.transform.GetChild(1).gameObject.SetActive(true);
				tut.transform.GetChild(5).gameObject.SetActive(true);
				player.gameObject.GetComponent<PlayerAction>().enabled = true;

				if (Input.GetMouseButtonDown(0)){
					tut.transform.GetChild(0).gameObject.SetActive(false);
					tut.transform.GetChild(1).gameObject.SetActive(false);
					tut.transform.GetChild(5).gameObject.SetActive(false);
					step2 = false;
					step3 = true;
				}
			}
			else{
				player.gameObject.GetComponent<PlayerAction>().enabled = false;
			}
		}
		//drop block to platform
		if(step1){
			if (Input.GetMouseButtonDown(0)){
				tut.transform.GetChild(0).gameObject.SetActive(false);
				tut.transform.GetChild(1).gameObject.SetActive(false);
				tut.transform.GetChild(4).gameObject.SetActive(false);
				step1 = false;
				step2 = true;
			}
		}
	}
}
