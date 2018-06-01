using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerFrontScript : MonoBehaviour {

    public GameObject enemy;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 5f; //2 seconds
    float nextSpawn = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randY = Random.Range(0f, 15f); // top and bottom bounds
            whereToSpawn = new Vector2(transform.position.x, randY);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
    }
}
