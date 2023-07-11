using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverScript : MonoBehaviour
{
    public int playerScore;

    public GameObject score;
    // Start is called before the first frame update
    void Start()
    {
       
        playerScore = Scoring.playerScore;
        
    }

    // Update is called once per frame
    void Update()
    {
        score.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
        EnemyAI.dead = false;
    }

    public void setScore()
    {
        if (Scoring.playerScore > PlayerPrefs.GetInt("HighScore")){
            PlayerPrefs.SetInt("HighScore", Scoring.playerScore);
        }

        

    }

}
