using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource music;


   
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
       

       
        
    }

    private void Start()
    {
        if (!music.isPlaying) {
            music.Play();
        }
        
    }
    // Update is called once per frame
    void Update()
    {

        if (finalFlag.completed || Scoring.endLevel || EnemyAI.dead) {
            music.Stop();
        }

    }


    public void changeMusic() {

        if (music.isPlaying)
        {
            music.Stop();
        }

        else {
            music.Play();
        }

    }


}
