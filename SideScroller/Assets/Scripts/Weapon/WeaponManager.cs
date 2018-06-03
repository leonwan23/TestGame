using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public GameObject activeWeapon;
    private WeaponScript weapon;
    bool canShoot = true;


	// Use this for initialization
	void Start () {

        weapon = activeWeapon.GetComponent<WeaponScript>();
        GetComponent<SpriteRenderer>().sprite = weapon.weaponSprite;
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            canShoot = false;
            StartCoroutine("CoolDown");

            //Vector3 rotation = transform.parent.localScale.x == 1 ? Vector3.zero : Vector3.forward * 180;
            GameObject projectile = (GameObject)Instantiate(weapon.projectile, transform.position + activeWeapon.transform.GetChild(0).localPosition * -transform.parent.localScale.x, Quaternion.identity);
            //SoundManagerScript.PlaySound("fireSound"); //play fire sound

            if (weapon.projectileMode == WeaponScript.Modes.Straight)
            {
                projectile.GetComponent<Rigidbody2D>().velocity = transform.parent.localScale.x * Vector2.left * weapon.projectileSpeed;   
            }
            else if(weapon.projectileMode == WeaponScript.Modes.Shotgun)
            {
                
            }
        }
	}

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(weapon.cooldown);
        canShoot = true;
    }

    public void ChangeWeapon(GameObject newWeapon)
    {
        activeWeapon = newWeapon;
        weapon = activeWeapon.GetComponent<WeaponScript>();
        GetComponent<SpriteRenderer>().sprite = weapon.weaponSprite;
        if(weapon.name == "Shotgun")
        {
            Vector3 scale = new Vector3(2.5f, 3, 1f);   //scale sprite size of shotgun
            transform.localScale = scale;
        }
    }
}
