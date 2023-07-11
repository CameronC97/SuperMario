using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour
{

    public int playerSpeed = 10;
    public bool facingRight;
    public static bool rightFace;
    public int playerJumpPower = 1250;
    public static float moveX;
    public static bool playerGrounded;
    private bool playSound;

    public static bool onFlag;
    public bool endAnimation;

    [HideInInspector] public Scoring scoring;

    public static int pState;
    public static bool walking;



    // Start is called before the first frame update
    void Start()
    {
        rightFace = facingRight;
        scoring = GetComponent<Scoring>();
        playSound = false;
        onFlag = false;
        endAnimation = false;
        walking = false;

    }

    // Update is called once per frame
    void Update()
    {

        rightFace = facingRight;
        playerMove();
        playerRaycast();
        playerState();
        levelCompleted();


    } 


   

    void playerMove()
    {
        //playerController
        moveX = Input.GetAxis("Horizontal");


        if (Input.GetButtonDown("Jump") && playerGrounded)
        {
            playerJump();
        }

       
               GetComponent<Rigidbody2D>().velocity =
                    new Vector2(moveX * playerSpeed, GetComponent<Rigidbody2D>().velocity.y);
        

    


        //playerDirection
        if (moveX < 0.0f && !facingRight)
        {
            
            flipPlayer();
            
        }
        else if (moveX > 0.0f && facingRight)
        {
            flipPlayer();
            
        }
    }

    void playerJump()
    {

        //Playing Jumping Script, force and direction

 
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
       


  
       

        playerGrounded = false;
    }

    void flipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground" || col.gameObject.tag == "CoinBlock" || col.gameObject.tag == "PowerUpBlock" || col.gameObject.tag == "FireFlowerBlock")
        {
            playerGrounded = true;
        }

   
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "LevelEnd" && !Scoring.endLevel)
        {
            finalFlag.completed = true;
       
        }

        if (trigger.gameObject.tag == "Castle") {
            Scoring.endLevel = true;
        }


    }

        void playerRaycast()
    {

        //Ray up to hit boxes
        RaycastHit2D RayUp = Physics2D.Raycast(transform.position, Vector2.up);

        //Ray Down to hit enemy
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);


        //Raycast for the Mushroom to be spawned
        if (RayUp != null && RayUp.collider != null && RayUp.distance < 0.5f && RayUp.collider.tag == "PowerUpBlock")
        {
            Destroy(RayUp.collider.gameObject);
            Instantiate(mushroomScript.mushroom, new Vector3(mushroomScript.spawn.transform.position.x, mushroomScript.spawn.transform.position.y, 0), Quaternion.identity);
        }



        //Fire Flower Raycast for spawning
        if (RayUp != null && RayUp.collider != null && RayUp.distance < 1.5f && RayUp.collider.tag == "FireFlowerBlock")
        {


            Destroy(RayUp.collider.gameObject);


            if (pState == 1) {
                Instantiate(mushroomScript.mushroom, new Vector3(FireBlock.spawnReference.transform.position.x, FireBlock.spawnReference.transform.position.y, 0), Quaternion.identity);
            }

            if (pState == 2) {
                Instantiate(FireBlock.FireFlowerReference, FireBlock.spawnReference.transform.position, FireBlock.spawnReference.transform.rotation);
            }




        }


        if (hit != null && hit.collider != null && hit.distance < 0.2f && hit.collider.tag != "Enemy")
        {
            playerGrounded = true;

            
        }

        if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag == "Range Enemy")
        {


            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);


            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 20;
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit.collider.gameObject.GetComponent<EnemyRangeScript>().enabled = false;
            hit.collider.gameObject.GetComponent<EnemyHealth>().enabled = false;

            Scoring.playerScore += 100;

        }



        if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag == "Enemy")
        {

         
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);


            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 20;
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit.collider.gameObject.GetComponent<EnemyAI>().enabled = false;
            hit.collider.gameObject.GetComponent<EnemyHealth>().enabled = false;

            Scoring.playerScore += 100;

        }


    }

    void playerState()
    {

        if (pState == 1)
        {
           
            EnemyAI.playerHealth = 1;
            EnemyRangeScript.playerHealth = 1;
          
        }



        if (pState == 2)
        {
            EnemyAI.playerHealth = 2;
            EnemyRangeScript.playerHealth = 2;
          

        }

        if (pState == 3)
        {
            EnemyAI.playerHealth = 3;
            EnemyRangeScript.playerHealth = 3;
           

        }

    }

    private float speed = 2.5f;
   

    void levelCompleted() {

        if (finalFlag.completed) {
            GetComponent<PlayerDeath>().enabled = false;

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-1) * speed;

            if (playerGrounded) {
                walking = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * speed;
            }
            
        }
    }

}
