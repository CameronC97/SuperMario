using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSounds : MonoBehaviour
{
    public AudioSource jump;



    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        playerJumpSound();
        
    }

    void playerJumpSound() {

        if (Input.GetButtonDown("Jump"))
        {
            jump.Play();

        }
    }
}
