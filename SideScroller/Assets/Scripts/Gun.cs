using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bulletToRight, bulletToLeft;
    Vector2 bulletPosition;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;

	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetButtonDown("Fire1") && Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }

	}
    
    void Shoot()
    {
        bulletPosition = transform.position;
        Instantiate(bulletToRight, bulletPosition, Quaternion.identity);
    }

}
