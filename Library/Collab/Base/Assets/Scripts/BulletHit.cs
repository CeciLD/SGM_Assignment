using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {

    [SerializeField]
    float impactForce;

    bool canHit = false;
    Rigidbody rb;

    private ParticleSystem ps;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ps = GetComponent<ParticleSystem>();
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player1" || coll.tag == "Player2" || coll.tag == "Player3" || coll.tag == "Player4")
        {
            canHit = true;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if ((coll.tag == "Player1" || coll.tag == "Player2" || coll.tag == "Player3" || coll.tag == "Player4") && canHit)
        {
            //ps.enableEmission = true;
            Destroy(gameObject);
            Rigidbody collRB = coll.GetComponent<Rigidbody>();

            Vector3 direction = rb.velocity.normalized;
            collRB.AddForce(direction * impactForce);

            canHit = false;
        }

        if(coll.tag == "Ground")
        {
            Destroy(gameObject);
        }

        if(coll.tag == "Bird")
        {
            Rigidbody collRB = coll.GetComponent<Rigidbody>();

            Vector3 direction = rb.velocity.normalized;
            collRB.AddForce(direction * 300);
        }
    }
    
}
