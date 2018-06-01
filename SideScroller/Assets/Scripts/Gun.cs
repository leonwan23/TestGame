using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    //for bullets
    public GameObject bulletToRight;
    Vector2 bulletPosition;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;
    public bool faceRight;

    // Use this for initialization
    void Awake () {

	}
	
	// Update is called once per frame
	void Update () {

        //Input.GetButtonDown("Fire1") &&

        faceRight = Player.facingRight;
        if (Input.GetButtonDown("Fire1") &&  Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            SoundManagerScript.PlaySound("fireSound"); //play fire sound
            Shoot();
        }
    }

    void Shoot()
    {
        bulletPosition = transform.position;

        if (faceRight)
        {
            bulletPosition += new Vector2(-3.5f, 0.5f);
            GameObject g = Instantiate(bulletToRight, bulletPosition, Quaternion.identity) as GameObject;
            BulletScript bulletLeft = g.GetComponent<BulletScript>();
            bulletLeft.velX *= -1;

        }
        else
        {
            bulletPosition += new Vector2(+3.5f, 0.5f);
            Instantiate(bulletToRight, bulletPosition, Quaternion.identity);

        }

    }
}
