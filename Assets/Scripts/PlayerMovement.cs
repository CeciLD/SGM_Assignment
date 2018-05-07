using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float horizontalSpeed = 6;
    private float verticalVelocity;
    [SerializeField]
    private float gravity = 14.0f;
    [SerializeField]
    private float jumpForce = 10.0f;
    private bool canDoubleJump;
    private CharacterController charController;
    [SerializeField]
    private int maxAllowedJumps = 2;
    [SerializeField]
    private int bulletSpeed = 100;

    bool grounded;
    bool canShoot = true;

    private int jumpsLeft;

    public GameObject bulletPrefab;


    // Use this for initialization
    void Start () {
        charController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        Shooting();

    }

    void Movement()
    {
        //Moving and Jumping
        if (charController.isGrounded)
        {
            //canDoubleJump = true;
            //grounded = true;
            jumpsLeft = maxAllowedJumps;
        }

        //if (Input.GetKey("w") && grounded)
        if (Input.GetKey("w") && charController.isGrounded)
        {
            //verticalVelocity = jumpForce;
            Jump();
            //grounded = false;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime; //falling down
            //if (canDoubleJump)
            if (jumpsLeft == 1)
            {
                if (Input.GetKeyDown("w"))
                {
                    //canDoubleJump = false;
                    verticalVelocity = 0;
                    // verticalVelocity = jumpForce;
                    Jump();
                }
            }
        }

        Vector3 moveVector = Vector3.zero;

        moveVector.x = Input.GetAxis("Horizontal") * horizontalSpeed;
        moveVector.y = verticalVelocity;
        charController.Move(moveVector * Time.deltaTime);
    }

    void Jump()
    {
        verticalVelocity = jumpForce;
        jumpsLeft--;
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            GameObject bulletProjectile = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody rb = bulletProjectile.GetComponent<Rigidbody>();
            Transform weapon = this.gameObject.transform.GetChild(0);

            Vector3 direction = weapon.transform.position - this.gameObject.transform.position;
            direction.Normalize();
            rb.AddForce(direction * bulletSpeed);
            

            canShoot = false;
            StartCoroutine(ShootingCooldown());
        }
    }

    IEnumerator ShootingCooldown()
    {
        yield return new WaitForSeconds(0.4f);
        canShoot = true;
    }
}
