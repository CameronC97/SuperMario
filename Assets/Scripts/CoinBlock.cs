using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CoinBlock : MonoBehaviour
{
    public GameObject Coin;
    public GameObject spawn;


    public bool playSound;

    public float waitTime = 1f;


    


    // Start is called before the first frame update
    void Start()
    {

        playSound = false;
       



    }

    void Update()
    {
    
        playerRaycast();

    }

    void playerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);


        //Coin Block that spawns the coin
        if (hit.distance < 0.9f && (hit.collider.tag == "player1" || hit.collider.tag == "player2" || hit.collider.tag == "player3"))
        {

            CoinScript.playSound = true;
            Destroy(gameObject);
            Scoring.playerScore += 200;
        }

        
    }








}

