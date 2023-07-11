using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class Scoring : MonoBehaviour
{
    private int life;

    private float timeLeft = 120;
    public static int playerScore;

    private int count;

  
   
    

    public GameObject time;
    public GameObject score;
    public GameObject lives;

    public static bool gameOver;
    public static bool endLevel;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
       
        life = Variables.lives;
        gameOver = false;
        endLevel = false;

        

        
    }

    // Update is called once per frame
    void Update()
    {

        timeLeft -= Time.deltaTime;

        time.gameObject.GetComponent<Text>().text = ("Time: " + (int)timeLeft);
        score.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        lives.gameObject.GetComponent<Text>().text = ("Lives: " + life);

        if (timeLeft <0.1f)
        {
            SceneManager.LoadScene("Level1");
            Variables.lives -= 1;

        }

        if (endLevel) {
            SceneManager.LoadScene("EndGame");
        }



    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "LevelEnd" && !endLevel)
        {
            CountScore();
            finalFlag.completed = true;
         
        }
    }


    void CountScore()
    {
        playerScore = playerScore + ((int)timeLeft * 10);
      
    }
}
