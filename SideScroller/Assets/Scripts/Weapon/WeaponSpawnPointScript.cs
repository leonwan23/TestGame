using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawnPointScript : MonoBehaviour {

    public GameObject[] weaponsArray;
    public GameObject weaponHere;
    public bool isTakeWeapon;
    int weaponIndex;
    public GameObject previousWeapon;

	// Use this for initialization
	void Start () {

        weaponIndex = Random.Range(0, weaponsArray.Length);
        weaponHere = weaponsArray[weaponIndex];
       
        GetComponent<SpriteRenderer>().sprite = weaponHere.GetComponent<SpriteRenderer>().sprite;
        if (weaponHere.name == "Shotgun")
        {
            Vector3 scale = new Vector3(2.5f, 3, 1f);   //scale sprite size of shotgun
            transform.localScale = scale;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (isTakeWeapon)
        {
            weaponHere = weaponsArray[weaponIndex];
            GetComponent<SpriteRenderer>().sprite = weaponHere.GetComponent<SpriteRenderer>().sprite;
            isTakeWeapon = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject oldWeapon = collision.transform.Find("WeaponSlot").GetComponent<WeaponManager>().DropWeapon();

            collision.transform.Find("WeaponSlot").GetComponent<WeaponManager>().ChangeWeapon(weaponHere);
            Destroy(this.gameObject);
            //isTakeWeapon = true;
            //GetComponent<SpriteRenderer>().sprite = null;

            Instantiate(oldWeapon, transform.position, Quaternion.identity);
            GetComponent<SpriteRenderer>().sprite = oldWeapon.GetComponent<SpriteRenderer>().sprite;
            isTakeWeapon = true;
        }
    }
}
