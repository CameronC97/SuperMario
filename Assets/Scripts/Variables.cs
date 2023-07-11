using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{

    public static int lives;

    public static bool Creation = true;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (Creation)
        {
            lives = 3;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    } 



    public static void updateLives()
    {
        lives -= 1;
        Creation = false;
    }
}
