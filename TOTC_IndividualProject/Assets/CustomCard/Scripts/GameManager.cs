using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  
    void Start()
    {
        InstantiatePrefabInCanvas();
        //CreateCustomImage();
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

        Instantiate_Card.Instance.createCard(
            "CC_Default_Question Card", // Name of preset card
             "1", // Layout
            "RGB,0,0,0,", // Background color
            "#ffffff", "Nunito Bold", // Subject text
            "#4CF4FF", "Nunito Bold", // Question text
            "#7FB93D", "Nunito Bold", // Correct text
            "AnswerButton", "AnswerButton", "AnswerButton", // Answer button image
            "#38FF00", "#FF0000", "#FF0000", // Answer button highlight color
            "#323232", "#323232", "#323232", // Answer button text color
            "Nunito Bold", "Nunito Bold", "Nunito Bold", // Answer button font 
            "Ellipse 12", "#FFFFFF", "Nunito Bold", // Timer properties
            "Rectangle_383", "#323232", "Nunito Bold", // okay button prperties
            "Vector", "#88FFF1", "Nunito Bold" // switch subject properties
            );

    }

    private void CreateCustomImage()
    {
        Instantiate_Card.Instance.createImage(
            "Question Card", // Parent name
            "CustomImage", // Image name
            "0", "200", // Position
            "400", "120", // Size
            "0", // Rotation
            "Rectangle 424", // Image source
            "#FFFFFF", // Image color
            "" // Image material (optional)
            );
    }
}
