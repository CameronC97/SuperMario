using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private int mushroomSpeed;

    private int xDirection;

    public AudioSource powerUp;



    void Start()
    {
        mushroomSpeed = 2;
        xDirection = 1;
       
    }

    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xDirection, 0) * mushroomSpeed;

        if (hit.distance < 0.5f)
        {
            FlipMushroom();
        }

    


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "player1" || col.gameObject.tag == "player2" || col.gameObject.tag == "player3")
        {
            

            if (PlayerController.pState == 1)
            {
              
                playerSwitchScript.char2.transform.position = new Vector2(playerSwitchScript.char1.transform.position.x, playerSwitchScript.char1.transform.position.y + 0.5f);
                playerSwitchScript.oneTime = true;
                PlayerController.pState = 2;
            }
            Destroy(gameObject);
            Destroy(this);
      

        }

    }


    void FlipMushroom()
    {
        if (xDirection > 0)
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }

    }
}
