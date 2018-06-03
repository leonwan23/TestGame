﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    //public float velX = 5;
    //public float velY = 0;
    Rigidbody2D rb;
    public float destroyTime;
    public GameObject blood;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        //rb.velocity = new Vector2(velX, velY);
        Destroy(gameObject, destroyTime);

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall") || collision.gameObject.tag.Equals("Platform") || collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Score.setKillScore(10);
            Instantiate(blood, transform.position, Quaternion.identity);

        } else if (collision.gameObject.tag != "WeaponPickup")
        {
            Destroy(this.gameObject);
        }
    }
}
