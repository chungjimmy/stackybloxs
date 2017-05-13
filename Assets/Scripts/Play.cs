using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour {

	public GameObject Home;

	public GameObject transition;

	public void StartGame(){
		transition.SetActive(true);
		Home.SetActive(false);
	}
}
