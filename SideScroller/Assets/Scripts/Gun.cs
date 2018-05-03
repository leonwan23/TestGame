using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    //fire when mouse click
    public float fireRate = 0;

    public float damage = 10;
    public LayerMask whatToHit;

    private float timeToFire = 0;
    private Transform firePoint;

	// Use this for initialization
	void Awake () {
        firePoint = transform.Find("FirePoint");

        //if no firepoint
        if (firePoint == null)
        {
            Debug.LogError("NO FIREPOINT");
        }
	}
	
	// Update is called once per frame
	void Update () {
        Shoot();
		if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
            else if (Input.GetButtonDown("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}

    void Shoot() {
        Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        //set firepoint as a vector2
        Vector2 firePointPosition = new Vector2(firePoint.position.x,firePoint.position.y);

        //cast out the ray, first qrg = origin, second arg = direction, third arg(optional) = distance, fourth arg(optional) = layermask
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 10, whatToHit);

        Debug.DrawLine(firePointPosition, mousePosition);
    }
}
