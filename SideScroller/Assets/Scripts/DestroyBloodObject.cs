using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBloodObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //destroy blood object after 2 seconds
        Destroy(gameObject, 2f);
	}
}
