using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorScript : MonoBehaviour {

    public Transform generationPoint;
    public Transform destroyPoint;

    public GameObject[] platformArray;
    private int platformSelector;
    private float[] platformWidthArray;
    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;


    // Use this for initialization
    void Start () {

        platformWidthArray = new float[platformArray.Length];
       
        
        for(int i=0; i<platformArray.Length; i++)
        {
            platformWidthArray[i] = platformArray[i].GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < generationPoint.position.x)
        {

            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformSelector = Random.Range(0, platformArray.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + platformWidthArray[platformSelector] + distanceBetween, heightChange, transform.position.z);


            Instantiate(platformArray[platformSelector], transform.position, transform.rotation);
        }

        if (transform.position.x < destroyPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
;