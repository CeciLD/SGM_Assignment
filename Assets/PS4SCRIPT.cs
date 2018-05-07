using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS4SCRIPT : MonoBehaviour {

    [SerializeField]
    private float horizontalSpeed = 6;
    [SerializeField]
    private float jumpForce = 10.0f;
    private bool canDoubleJump;
    [SerializeField]
    public static int maxAllowedJumps = 2;
    [SerializeField]
    private int bulletSpeed = 100;
    [SerializeField]
    private int pushBackForce = 100;
    public static float shootingCooldown = 0.4f;

    bool grounded;
    bool canShoot = true;

    private int jumpsLeft;
    Rigidbody rb;

    public GameObject bulletPrefab;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();

    }

    void Movement()
    {
        //Moving and Jumping
        if (grounded)
        {
            //canDoubleJump = true;
            //grounded = true;
            jumpsLeft = maxAllowedJumps;
        }

        //if (Input.GetKey("w") && grounded)
        if (Input.GetButtonDown("PSLB") && grounded)
        {
            //verticalVelocity = jumpForce;
            Jump();
            //grounded = false;
        }
        else
        {
            //if (canDoubleJump)
            if (jumpsLeft > 0)
            {
                if (Input.GetButtonDown("PSLB"))
                {
                    //canDoubleJump = false;
                    rb.velocity = new Vector3(0, 0, 0);
                    // verticalVelocity = jumpForce;
                    Jump();
                }
            }
        }

        float deltaX = Input.GetAxis("PSLJx") * horizontalSpeed;

        if (rb.velocity.x < 20)
        {

            rb.AddForce(deltaX * Vector3.right);
        }

    }

    void Jump()
    {
        grounded = false;
        if (rb.velocity.y < 20)
        {
            rb.AddForce(new Vector3(0, 1, 0) * jumpForce);
        }

        jumpsLeft--;
    }

    void Shooting()
    {
        if (Input.GetButton("Player1RB") && canShoot)
        {
            GameObject bulletProjectile = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody rbBullet = bulletProjectile.GetComponent<Rigidbody>();
            Transform weapon = this.gameObject.transform.GetChild(0);

            Vector3 direction = weapon.transform.position - this.gameObject.transform.position;
            direction.Normalize();
            rbBullet.AddForce(direction * bulletSpeed);
            rb.AddForce(-direction * pushBackForce);

            canShoot = false;
            StartCoroutine(ShootingCooldown());
        }
    }

    IEnumerator ShootingCooldown()
    {
        yield return new WaitForSeconds(shootingCooldown);
        canShoot = true;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
