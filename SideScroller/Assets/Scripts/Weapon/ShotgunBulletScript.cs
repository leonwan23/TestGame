using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBulletScript : MonoBehaviour {

    public float velX;
    public float velYUp;
    public float velYStraight;
    public float velYDown;
    public Rigidbody2D rbUp;
    public Rigidbody2D rbStraight;
    public Rigidbody2D rbDown;
    public float destroyTime;
    public GameObject blood;

    // Use this for initialization
    void Start()
    {
        rbUp = GetComponent<Rigidbody2D>();
        rbStraight = GetComponent<Rigidbody2D>();
        rbDown = GetComponent<Rigidbody2D>();
        rbUp.velocity = new Vector2(velX, velYUp);
        rbStraight.velocity = new Vector2(velX, velYStraight);
        rbDown.velocity = new Vector2(velX, velYDown);

        //rb.AddForce(new Vector3(velX,velY, 0));

    }

    // Update is called once per frame
    void Update()
    {
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

        }
        else if (collision.gameObject.tag != "WeaponPickup")
        {
            Destroy(this.gameObject);
        }
    }
}
