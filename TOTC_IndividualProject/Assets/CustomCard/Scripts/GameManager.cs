using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InstantiatePrefabInCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstantiatePrefabInCanvas()
    {
        // Current cards available

        // ########  DEFAULT CARD  ########
        // CC_Default_Question Card

        // ########  THEMED CARDS  ########
        // H_Theme_Question Card

        // Can choose between 2 colors RGB and HEX code, demonstration below it needs to be that format
        //RGB,255,100,255,
        //#1949c2

        Instantiate_Card.Instance.createCard("CC_Default_Question Card", "RGB,0,0,0,");

    }
}
