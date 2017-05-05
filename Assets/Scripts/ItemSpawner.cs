using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	public GameObject thunder;
	public GameObject wind;
	public GameObject rain;
	public GameObject twoTime;

	private int itemID;

	public static bool ACTIVEITEM;

	public bool active;
	// Use this for initialization
	void Start () {
		itemID = -1;
	}
	
	// Update is called once per frame
	void Update () {
		active = ACTIVEITEM;
		if(itemID >= 0 && ACTIVEITEM){
			switch(itemID){
				case 0:
					thunder.gameObject.GetComponent<ThunderAction>().Effect();
					break;
				case 1:
					wind.gameObject.GetComponent<WindAction>().Effect();
					break;
				case 2:
					rain.gameObject.GetComponent<RainAction>().Effect();
					break;
				case 3:
					twoTime.gameObject.GetComponent<TwoXAction>().Effect();
					break;
			}
			ACTIVEITEM = false;
		}
	}

	public void ItemSpawn(){
		if(itemID >= 0){
			switch(itemID){
				case 0:
					thunder.gameObject.GetComponent<ThunderAction>().Effect();
					break;
				case 1:
					wind.gameObject.GetComponent<WindAction>().Effect();
					break;
				case 2:
					rain.gameObject.GetComponent<RainAction>().Effect();
					break;
				case 3:
					twoTime.gameObject.GetComponent<TwoXAction>().Effect();
					break;
			}
		}
		itemID = Random.Range(0, 4);
		switch(itemID){
			case 0:
				thunder.SetActive(true);
				break;
			case 1:
				wind.SetActive(true);
				break;
			case 2:
				rain.SetActive(true);
				break;
			case 3:
				twoTime.SetActive(true);
				break;
		}
	}
}
