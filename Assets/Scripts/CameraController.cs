using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   // private GameObject player;

    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    public float x;
    public float y;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerController.pState == 1)
        {
            x = Mathf.Clamp(player1.transform.position.x, minX, maxX);
            y = Mathf.Clamp(player1.transform.position.y, minY, maxY);
        }

        if (PlayerController.pState == 2) {
            x = Mathf.Clamp(player2.transform.position.x, minX, maxX);
            y = Mathf.Clamp(player2.transform.position.y, minY, maxY);
        }

        if (PlayerController.pState == 3)
        {
            x = Mathf.Clamp(player3.transform.position.x, minX, maxX);
            y = Mathf.Clamp(player3.transform.position.y, minY, maxY);
        }


        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);

    }
}
