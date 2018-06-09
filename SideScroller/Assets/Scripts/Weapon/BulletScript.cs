using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float velX;
    public float velY;
    Rigidbody2D rb;
    public float destroyTime;
    public GameObject blood;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(velX, velY);
        //rb.velocity = Vector3.zero;
        //rb.AddForce(new Vector3(velX,0,0), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update () {

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
            Destroy(this.gameObject);
                Destroy(collision.gameObject);
                Score.setKillScore(10);
                Instantiate(blood, transform.position, Quaternion.identity);
            

        } else if (collision.gameObject.tag != "WeaponPickup")
        {
            Destroy(this.gameObject);
        }
    }
}
