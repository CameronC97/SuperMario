using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallObjectScript : MonoBehaviour
{
    public GameObject fireBall;
    public static GameObject fireBallReference;

    public GameObject spawn;
    public static GameObject spawnReference;

    // Start is called before the first frame update
    void Start()
    {
        fireBallReference = fireBall;
        spawnReference = spawn;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
