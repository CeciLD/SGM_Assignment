using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	public GameObject []item;
	float randX;
	Vector2 whereToSpawn;
	public float spawnRate = 2f;
	float nextSpawn = 2;
	
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.time>nextSpawn){
			nextSpawn = Time.time + spawnRate;
			randX = Random.Range(-30f,30f);
			whereToSpawn = new Vector3(randX,transform.position.y,0);
			int idx = Random.Range(0, item.Length);
			Instantiate(item[idx],whereToSpawn,Quaternion.identity);	
		}
	}
}


    // Position Storage Variables