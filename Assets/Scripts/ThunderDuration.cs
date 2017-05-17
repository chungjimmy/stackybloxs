using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderDuration : MonoBehaviour {
	public GameObject particle;

	private float delayParticle;

	private float randomSpawnX;

	private float randomSpawnY;

	private int counter;

	private GameObject particleEffect;

	private float randomSize;

	private Vector3 particleSpawnPoint;

	private float timeToDisplay;
	// Use this for initialization
	void Start () {
		counter = 0;
		delayParticle = 0f;
		timeToDisplay = .2f;
		randomSpawnX = 0f;
		randomSpawnY = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(delayParticle <= Time.time){
			randomSpawnX = Random.Range(-2f, 2f);
			randomSpawnY = Random.Range(-2f, 2f);
			particleSpawnPoint = new Vector3(this.transform.position.x + randomSpawnX , this.transform.position.y + randomSpawnY, this.transform.position.z);
			particleEffect = Instantiate(particle, particleSpawnPoint, Quaternion.identity);
			randomSize = Random.Range(-.2f, 1f);
			particleEffect.transform.localScale = new Vector3(particleEffect.transform.localScale.x + randomSize, particleEffect.transform.localScale.y + randomSize, particleEffect.transform.localScale.z);
			delayParticle = Time.time + timeToDisplay;
			counter++;
		}

		if(counter > 6){
			counter = 0;
			BlockBehavior.displayParticle = false;
			delayParticle = 0f;
			this.gameObject.SetActive(false);
		}
	}
}
