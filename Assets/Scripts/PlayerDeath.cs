using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerDeath : MonoBehaviour
{
    

    public bool gameOver;


    public EnemyAI enemyAi;

  


    void Start()
    {

        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -5.5)
        {
            enemyAi.die();
            Variables.updateLives();
           

        }

    }

}
