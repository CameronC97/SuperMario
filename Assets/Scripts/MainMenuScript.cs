using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject[] g;
    public GameObject[] opG;

    public static bool musicChange;

    public Text highScore;



    // Start is called before the first frame update
    void Start()
    {

        Variables.Creation = true;
        Scoring.gameOver = false;
        Scoring.endLevel = false;
        finalFlag.completed = false; 

        g = GameObject.FindGameObjectsWithTag("MainMenuButtons");
        opG = GameObject.FindGameObjectsWithTag("Options");

        foreach (GameObject o in g) {
            o.SetActive(true);
        }



        foreach (GameObject ob in opG) {
            ob.SetActive(false);
        
        }

        musicChange = true;

        highScore.text = ("HighScore: " + PlayerPrefs.GetInt("HighScore").ToString());



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame() {
        Application.LoadLevel("Level1");
    }



    public void quitGame() {
        Application.Quit();
        }


    public void highScores() {

        Application.LoadLevel("HighScore"); 
    }


    public void showoptions()
    {
        foreach (GameObject o in g)
        {
            o.SetActive(false);
        }

        foreach (GameObject op in opG)
        {
            op.SetActive(true);
        }
    }


    public void showMainMenu()
    {
        foreach (GameObject o in g)
        {
            o.SetActive(true);
        }

        foreach (GameObject op in opG)
        {
            op.SetActive(false);
        }
    }

        
    


}
