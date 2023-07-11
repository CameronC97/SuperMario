using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalFlag : MonoBehaviour
{
    Animator anim;
    public static bool completed;

    public GameObject childOb;
    // Start is called before the first frame update
    void Start()
    {
     
        childOb.SetActive(false);
        
        completed = false;
     
        anim = GetComponent<Animator>();
        anim.SetBool("endLevel", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (completed) {
            anim.SetBool("endLevel", true);
            childOb.SetActive(true);
            
        }

    }

}
