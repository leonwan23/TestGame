using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    public int cameraSpeed = 5;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.right * Time.deltaTime * cameraSpeed;
    }
}
