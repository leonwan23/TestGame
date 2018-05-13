using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public static int health = 1;
    public static bool hasDied;

    // Use this for initialization
    void Start()
    {
        hasDied = false;
    }

    public static bool checkHealth
    {
        get
        {
            return hasDied;
        }
    }

    bool HasPlayerDied() { return hasDied; }

    // Update is called once per frame
    void Update()
    {

    }
}
