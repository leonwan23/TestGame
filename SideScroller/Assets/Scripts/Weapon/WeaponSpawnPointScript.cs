using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawnPointScript : MonoBehaviour {

    public GameObject[] weaponsArray;
    public GameObject weaponHere;

	// Use this for initialization
	void Start () {
        weaponHere = weaponsArray[Random.Range(0, weaponsArray.Length)];
        GetComponent<SpriteRenderer>().sprite = weaponHere.GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

        }
    }
}
