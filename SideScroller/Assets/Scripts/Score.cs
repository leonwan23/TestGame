using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreDisplay;
    public string weaponType = "Pistol";
    public Text killScoreDisplay;
    private static int killScore = 0;
    public Text highScoreDisplay;
    private int highScore;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        scoreDisplay.text = "Weapon: " + weaponType;
        killScoreDisplay.text = "Kills: " + killScore;
        highScoreDisplay.text = "High Score: " + highScore;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            weaponType = collision.gameObject.tag.ToString();
            Destroy(collision.gameObject);
        }
    }

    public static int getKillScore()
    {
        return killScore;
    }

    public static void setKillScore(int kills)
    {
        killScore += kills;
    }
}
