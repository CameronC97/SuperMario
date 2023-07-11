using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDetection : MonoBehaviour
{

    public static bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        inRange = false;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player1" || other.tag == "player2" || other.tag == "player3")
        {
            inRange = true;

        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
