using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMove : MonoBehaviour {

    public int enemySpeed;
    public int xMove = 1;

    public float contactDistance;

    public GameObject blood;

	// Update is called once per frame
	void Update () {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMove, 0));
        //enemies only move in x direction
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMove, 0) * enemySpeed;
        if(hit.distance < contactDistance)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Bullet"))
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
