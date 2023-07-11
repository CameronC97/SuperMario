using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject[] pause;

    public AudioSource pauseSound;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        pause = GameObject.FindGameObjectsWithTag("PauseMenu");
        hidePause();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P)) {

            if (Time.timeScale == 1) {
                Time.timeScale = 0;
                pauseSound.Play();
                showPause();
            } else if (Time.timeScale == 0) {
                Time.timeScale = 1;
                hidePause();
            }

        }
        
    }


    public void reload() {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void showPause() {
        foreach (GameObject g in pause) {
            g.SetActive(true);
        }
    }

    public void hidePause() {
        foreach (GameObject g in pause)
        {
            g.SetActive(false);
        }
    }

    public void mainMenu() {
        Application.LoadLevel("mainMenu");
    }

}
