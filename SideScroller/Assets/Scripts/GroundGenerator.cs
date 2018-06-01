using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour {

    public GameObject ground;
    public Transform generationPoint;

    private float groundWidth;

    public ObjectPooler objectPooler;

	// Use this for initialization
	void Start () {

        groundWidth = ground.GetComponent<BoxCollider2D>().size.x;
  
	}
	
	// Update is called once per frame
	void Update () {

        if(transform.position.x < generationPoint.position.x)
        {
           transform.position = new Vector3(transform.position.x + groundWidth, transform.position.y, transform.position.z);
           Instantiate(ground, transform.position, transform.rotation);

          GameObject newGround = objectPooler.getPooledObject();
          newGround.transform.position = transform.position;
          newGround.transform.rotation = transform.rotation;
          newGround.SetActive(true);
        }
	}
}
