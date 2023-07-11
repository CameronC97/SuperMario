using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public AudioSource shoot;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      

     
        fireBallShoot();

    }

    void fireBallShoot()
    {


        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerAnimation.playerShoot = true;
            Instantiate(FireBallObjectScript.fireBallReference, new Vector3(FireBallObjectScript.spawnReference.transform.position.x, FireBallObjectScript.spawnReference.transform.position.y, 0), Quaternion.identity);
            shoot.Play();
        }


        if (Input.GetKeyUp(KeyCode.Q)) {
            playerAnimation.playerShoot = false;
        }

    }
}
