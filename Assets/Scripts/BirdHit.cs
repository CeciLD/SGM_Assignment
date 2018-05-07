using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHit : MonoBehaviour {

    Rigidbody rb;
    BirdAI ba;
    public GameObject []item;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ba = GetComponent<BirdAI>();
    }

	void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Bullet")
        {
            ba.enabled = false;
            rb.useGravity = true;
            rb.mass += 2;
            Destroy(gameObject);
            int idx = Random.Range(0, item.Length);
            Instantiate(item[idx],transform.position,Quaternion.identity);
        }
    }
 

}
