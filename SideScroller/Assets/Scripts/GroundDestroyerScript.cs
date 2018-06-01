using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyerScript : MonoBehaviour {

    public GameObject groundDestroyPoint;

	// Use this for initialization
	void Start () {
        groundDestroyPoint = GameObject.Find("GroundDestroyerPoint"); //same name as object in unity
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x < groundDestroyPoint.transform.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false); //object pooling, better performance
        }
	}
}
