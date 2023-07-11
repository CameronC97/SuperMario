
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;

public class EnemyAI : MonoBehaviour
{

    public int enemySpeed;
    public int xDirection;

    public static bool alive;
    internal bool playerDied;
    public static int playerHealth;

    public GameObject Player;

    public static bool dead;
    



    public static Animator anim;


    void Start()
    {

        alive = GetComponent<EnemyHealth>().alive;
        anim = GetComponent<Animator>();
        playerDied = false;
        playerHealth = 1;
        dead = false;


    }




    // Update is called once per frame
    void Update()
    {



        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xDirection, 0));
   
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xDirection, 0) * enemySpeed;



        if (hit.distance < 0.5f)
        {


            if (hit.collider.tag == "player1"  && playerHealth == 1)
            {
                playerDied = true;
                die();
            }

            if (hit.collider.tag == "player2" && playerHealth > 1)
            { 
                playerSwitchScript.oneTime = true;
                playerHealth -= 1;
                PlayerController.pState = 1;
                playerSwitchScript.char1.transform.position = new Vector2(playerSwitchScript.char2.transform.position.x, playerSwitchScript.char2.transform.position.y + 0.5f);
                Debug.Log(playerHealth);
            }

            if (hit.collider.tag == "player3" && playerHealth > 1  ) {
                playerSwitchScript.oneTime = true;
                playerHealth -= 1;
                PlayerController.pState = 2;
                playerSwitchScript.char2.transform.position = new Vector2(playerSwitchScript.char3.transform.position.x, playerSwitchScript.char3.transform.position.y + 0.5f);

            }

            FlipEnemy();
    
       
        }
        if (gameObject == null)
        {
            Destroy(this);
        }
    }

    public void die()
    {
        if (playerDied)
        {

            Variables.updateLives();
        }


        if (Variables.lives > 0)
        {
            SceneManager.LoadScene("Level1");
        }

        else if (Variables.lives == 0)
        {
            dead = true;
            SceneManager.LoadScene("GameOver");
        }

    }


    void FlipEnemy()
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
