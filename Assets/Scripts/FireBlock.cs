using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlock : MonoBehaviour
{

    public GameObject FireFlower;
    public static GameObject FireFlowerReference;

    public GameObject spawn;
    public static GameObject spawnReference;
    // Start is called before the first frame update
    void Start()
    {
        FireFlowerReference = FireFlower;
        spawnReference = spawn;

    }

    void Update()
    {

    }

    void OnCollisionEnter2D()
    {
        Destroy(this);

    }
}
