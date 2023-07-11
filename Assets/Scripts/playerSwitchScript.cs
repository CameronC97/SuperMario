using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class playerSwitchScript : MonoBehaviour
{
    public  GameObject p1;

    public   GameObject p2;

    public   GameObject p3;

    public static GameObject char1;
    public static GameObject char2;
    public static GameObject char3;


   

    public static bool oneTime;
  


    // Start is called before the first frame update
    void Start()
    {

        char1 = p1;
        char2 = p2;
        char3 = p3;

        oneTime = false;
        PlayerController.pState = 1;


    } 

    // Update is called once per frame
    void Update()
    { 

        switchPlayer();

    }

    public void switchPlayer()
    {



        if (PlayerController.pState == 1) {

          

            p1.gameObject.SetActive(true);
            p2.gameObject.SetActive(false);
            p3.gameObject.SetActive(false);


        }
               

        

        if (PlayerController.pState == 2) {

           

            p1.gameObject.SetActive(false);
            p2.gameObject.SetActive(true);
            p3.gameObject.SetActive(false);

            
        }



        if (PlayerController.pState == 3) {

      

            p1.gameObject.SetActive(false);
            p2.gameObject.SetActive(false);
            p3.gameObject.SetActive(true);
           
        }
       

               

        
    }
}
