using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public AudioSource coin;

    [HideInInspector]
    public static bool playSound;

    

    void Start()
    {
        playSound = false;
        
                
      
    }

    void Update()
    {
        if (playSound) {

            coin.Play();

            playSound = false;
            }
    }


}
