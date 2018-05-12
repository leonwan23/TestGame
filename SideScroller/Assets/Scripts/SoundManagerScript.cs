using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

    public static AudioClip fireSound;
    static AudioSource audioSource;

	// Use this for initialization
	void Start () {
        fireSound = Resources.Load<AudioClip>("fireSound"); //load audio clip

        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "fireSound":
                audioSource.PlayOneShot(fireSound);
                break;
        }
    }
}
