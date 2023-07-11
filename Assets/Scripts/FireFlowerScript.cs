using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlowerScript : MonoBehaviour
{

    public AudioSource powerUp;
  


    private void Update()
    {
  
    }

    void OnCollisionEnter2D(Collision2D col)
    {


        if (col.gameObject.tag == "player1" || col.gameObject.tag == "player2" || col.gameObject.tag == "player3")
        {
            playerSwitchScript.oneTime = true;
            



            if (PlayerController.pState == 2)
            {
                
                playerSwitchScript.char3.transform.position = new Vector2(playerSwitchScript.char2.transform.position.x, playerSwitchScript.char2.transform.position.y + 0.5f);
                playerSwitchScript.oneTime = true;
                PlayerController.pState = 3;
            }

            Destroy(gameObject);
            Destroy(this);
      

        }


    }
}
