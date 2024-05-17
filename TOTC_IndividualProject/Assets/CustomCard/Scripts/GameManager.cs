using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  
    void Start()
    {
        InstantiatePrefabInCanvas();
        //CreateCustomImage();
        //CreateCustomText();
        //CreateAnimation();
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

    private void CreateCustomText()
    {
        Instantiate_Card.Instance.createText(
            "Question Card", // Parent name
            "CustomText", // Text name
            "100", "100", // Position
            "300", "300", // Size
            "30", // Rotation
            "THIS IS A CUSTOM TEXT!!!", // Text content
            "#F8BA42", // Text color
            "Nunito Bold", // Font name
            50, // Font size
            true, // Bold
            false // Italic
        );
    }

    private void CreateAnimation()
    {
        Instantiate_Card.Instance.createAnimatedImage(
            "Question Card", // Parent name
            "Bat Animation", // Animation name
            "-370", "550", // Initial position
            "100", "100", // Size
            "0", // Rotation
            "Bat", // Image source
            "#FFFFFF", // Image color
            2.0f, // Move speed
            "zigzag" // Move pattern
        );
    }

}
