using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public enum Modes { melee, Straight, Follow, Throw};

    public Sprite weaponSprite;
    public GameObject projectile;
    public float projectileSpeed;
    public float cooldown;
    public Modes projectileMode;

	// Use this for initialization
	void Start () {
        
	}
}
