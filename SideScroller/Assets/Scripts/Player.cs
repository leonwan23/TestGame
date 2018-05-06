using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int playerSpeed = 10;
    public bool facingRight = true;
    public int playerJumpHeight = 1250;
    public float moveX;
    public bool isOnGround = true;


    public GameObject bulletToRight;
    Vector2 bulletPosition;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void PlayerMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && isOnGround == true)
        {
            Jump();
        }
        //Animations
        //Player Direction
        if(moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        } else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        //add jump in direction of up * jump height
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpHeight);
        isOnGround = false;
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Platform")
        {
            isOnGround = true;
        }

    }

    void Shoot()
    {
        bulletPosition = transform.position;

        if (facingRight)
        {
            bulletPosition += new Vector2(-3.5f, 0.5f);
            GameObject g = Instantiate(bulletToRight, bulletPosition, Quaternion.identity) as GameObject;
            BulletScript bulletLeft = g.GetComponent<BulletScript>();
            bulletLeft.velX *= -1;
            
        } else
        {
            bulletPosition += new Vector2(+3.5f, 0.5f);
            Instantiate(bulletToRight, bulletPosition, Quaternion.identity);

        }
       
    }

}
