using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMove : MonoBehaviour {

    public int enemySpeed;
    public int xMove = 1;


	// Update is called once per frame
	void Update () {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMove, 0));
        //enemies only move in x direction
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMove, 0) * enemySpeed;
        if(hit.distance < 1.5)
        {
            FlipEnemy();
        }
	}

    void FlipEnemy()
    {
        if (xMove>0)
        {
            xMove = -1;
        }
        else
        {
            xMove = 1;
        }
    }
}
