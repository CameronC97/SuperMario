using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{

    [HideInInspector]
    Animator anim;




    public static bool playerShoot;
    // Start is called before the first frame update
    void Start()
    {
        playerShoot = false;
        anim = GetComponent<Animator>();

      


        //Sets player to being alive so animation dont play
        anim.SetBool("isDead", false);

    }

    // Update is called once per frame
    void Update()
    {
        playerMoving();
        playerJumping();

        if (PlayerController.pState == 3) {
            fireFlowerThrow();
        }
       

    }


    void playerMoving()
    {


        //playerAnimation

        if (PlayerController.moveX != 0)
        {
            anim.SetBool("isMoving", true);
        }

        if (PlayerController.moveX == 0)
        {
            anim.SetBool("isMoving", false);
        }

        if (PlayerController.walking) {

            anim.speed = 0.75f;

            anim.SetBool("isMoving", true);
        }
    }


    void playerJumping()
    {

        if (PlayerController.playerGrounded)
        {
            anim.SetBool("isJumping", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isJumping", true);
           
        }
    }

    void fireFlowerThrow() {
        if (playerShoot) {
            anim.SetBool("isShooting", true);
        }

        else {
            anim.SetBool("isShooting", false);
        }
    }
}
