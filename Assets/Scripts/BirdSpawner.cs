using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour {
	[SerializeField]
	private GameObject bird;
	// Use this for initialization
	void Start () {
		StartCoroutine("SpawnBirdTimer");
	}
	
	// Update is called once per frame
	void Update () {
		 
	}

	IEnumerator SpawnBirdTimer(){
		yield return new WaitForSeconds(15);
		
		SpawnBird();
	}

	void SpawnBird(){
		Instantiate(bird,transform.position,Quaternion.identity);
		StartCoroutine("SpawnBirdTimer");
	}
}
