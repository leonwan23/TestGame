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
        if (weaponHere.name == "Shotgun")
        {
            Vector3 scale = new Vector3(2.5f, 3, 1f);   //scale sprite size of shotgun
            transform.localScale = scale;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.Find("WeaponSlot").GetComponent<WeaponManager>().ChangeWeapon(weaponHere);
            Destroy(this.gameObject);
        }
    }
}
