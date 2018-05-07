using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpScript : MonoBehaviour {

	public AudioClip[] pickAudio;
	//public GameObject shield;
	//public static bool shieldActive;
	
	void OnTriggerEnter(Collider coll){
	
		if(coll.tag == "banana"){
			playSound(0);
			Destroy(coll.gameObject);
            BananaEffect();
			Invoke("Res",5); 
		}

		if(coll.tag == "meat"){
			playSound(2);
			Destroy(coll.gameObject);
			MeatEffect();
			Invoke("Res",2);
		}
	}
	private void Res() {  //doesnt apply
 	 ControllerMovementNew.maxAllowedJumps = 2;
	ControllerMovementNew.shootingCooldown = 0.4f;

	}
	 public void BananaEffect(){
		ControllerMovementNew.maxAllowedJumps = 3;
	}
	public void MeatEffect(){
		ControllerMovementNew.shootingCooldown = 0.1f;
		//BulletHit.impactForce = 2000;
		//shieldActive = true;
		//shield.SetActive(true);
	}
	void playSound(int clip){
		GetComponent<AudioSource>().clip = pickAudio[clip];
		GetComponent<AudioSource>().Play();	
	}
}
