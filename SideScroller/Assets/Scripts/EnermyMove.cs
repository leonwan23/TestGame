using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMove : MonoBehaviour {

    public int enemySpeed;
    public int xMove = 1;
    public int enemyHp;

    public float contactDistance;

    public bool faceRight;

    //for chasing player
    private Transform target; // player as target to chase after

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  //find object tagged as player
    }


    // Update is called once per frame
    void Update () {

        transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);  //move from, move to, speed

        //faceRight = Player.facingRight;
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMove, 0));
        ////enemies only move in x direction
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMove, 0) * enemySpeed;
        //if(hit.distance < contactDistance)
        //{
        //    FlipEnemy();
        //}
        //if(faceRight) {
        //    Debug.Log("Right");
        //}
        //else {
        //    Debug.Log("Left");
        //}

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

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag.Equals("Bullet"))
    //    {
          
    //        Score.setKillScore(10);

    //        Instantiate(blood, transform.position, Quaternion.identity);
    //        Destroy(collision.gameObject);
    //        Destroy(gameObject);
    //    }
    //} 
}
