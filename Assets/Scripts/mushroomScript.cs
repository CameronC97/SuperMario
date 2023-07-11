using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomScript : MonoBehaviour
{
    public static GameObject mushroom;
    public GameObject mushroomReference;

    public static GameObject spawn;
    public GameObject spawnReference;

    void Start()
    {
        mushroom = mushroomReference;
        spawn = spawnReference;
       
    }

    void Update()
    {

    }

    void OnCollisionEnter2D()
    {
        Destroy(this);

    }
}
