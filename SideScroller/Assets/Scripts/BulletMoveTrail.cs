using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveTrail : MonoBehaviour {

    public int bulletSpeed = 230;

	// Update is called once per frame
	void Update () {
        //show moving object
        transform.Translate(Vector3.right * Time.deltaTime * bulletSpeed);

        //destroy after 1 second
        Destroy(gameObject, 1);
	}
}
