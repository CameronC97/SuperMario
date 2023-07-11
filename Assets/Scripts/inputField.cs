using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class inputField : MonoBehaviour {

    public Text name;
    public static string player;


    public void GetName() {
        player = name.text.ToString();

        Debug.Log(player);
      
    }
}
