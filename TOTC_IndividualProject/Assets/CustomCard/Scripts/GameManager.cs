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

        //SetupTimerSound();
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
        //Fonts - Nunito Bold, AIW

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

        //Instantiate_Card.Instance.createCard("CC_Default_Question Card", "1", "RGB,0,0,0,", "#ffffff", "Nunito Bold", "#4CF4FF", "Nunito Bold", "#7FB93D", "Nunito Bold", "AnswerButton", "AnswerButton", "AnswerButton", "#38FF00", "#FF0000", "#FF0000", "#323232", "#323232", "#323232", "Nunito Bold", "Nunito Bold", "Nunito Bold", "Ellipse 12", "#FFFFFF", "Nunito Bold", "Rectangle_383", "#323232", "Nunito Bold", "Vector", "#88FFF1", "Nunito Bold");
    }

    private void CreateCustomImage()
    {
        Instantiate_Card.Instance.createImage(
            "Canvas", // Parent name
            "Image with material", // Image name
            "0", "200", // Position
            "800", "350", // Size
            "0", // Rotation
            "Rectangle 424", // Image source
            "#FFFFFF", // Image color
            "" // Image material (optional)
            );

        //Instantiate_Card.Instance.createImage("Question Card", "CustomImage", "0", "200", "400", "120", "0", "Rectangle 424", "#FFFFFF", "");
    }

    private void CreateCustomText()
    {
        Instantiate_Card.Instance.createText(
            "Question Card", // Parent name
            "CustomText", // Text name
            "100", "100", // Position
            "300", "300", // Size
            "-30", // Rotation
            "THIS IS A CUSTOM TEXT!!!", // Text content
            "#F8BA42", // Text color
            "Nightcore", // Font name
            50, // Font size
            true, // Bold
            false // Italic
        );

        //Instantiate_Card.Instance.createText("Question Card", "CustomText", "100", "100", "300", "300", "30", "THIS IS A CUSTOM TEXT!!!", "#F8BA42", "Nunito Bold", 50, true, false);
    }

    private void CreateAnimation()
    {
        // Create animation with zigzag movement goes up and down
        Instantiate_Card.Instance.createAnimation(
            "Question Card", // Parent name
            "zig zag animation", // animation name
            "-350", "500", // Initial position
            "100", "100", // Size
            "0", // Rotation
            "Bat", // Image source
            "#FFFFFF", // Image color
            3.0f, // Move speed
            "zigzag", // Move pattern
            1 // Quantity
        );

        // Create an animation with vertical movement
        Instantiate_Card.Instance.createAnimation(
            "Question Card", // Parent name
            "Vertical animation", // animation name
            "200", "500", // Initial position
            "100", "100", // Size
            "3", // Rotation
            "Bat", // Image source
            "#FFFFFF", // Image color
            4.0f, // Move speed
            "vertical", // Move pattern
            2 // Quantity
        );

        // Create an animation with horizontal movement
        Instantiate_Card.Instance.createAnimation(
            "Question Card", // Parent name
            "Horizontal animation", // animation name
            "0", "300", // Initial position
            "100", "100", // Size
            "-10", // Rotation
            "Bat", // Image source
            "#FFFFFF", // Image color
            3.5f, // Move speed
            "horizontal", // Move pattern
            1 // Quantity
        );

        // Create an animation with Circular movement
        Instantiate_Card.Instance.createAnimation(
            "Question Card", // Parent name
            "Circuly animation", // animation name
            "250", "300", // Initial position
            "100", "100", // Size
            "-10", // Rotation
            "Bat", // Image source
            "#FFFFFF", // Image color
            2.0f, // Move speed
            "circular", // Move pattern
            2 // Quantity
        );

        // Create an animation with scaling effect
        Instantiate_Card.Instance.createAnimation(
            "Question Card", // Parent name
            "Scaling animation", // animation name
            "0", "200", // Initial position
            "100", "100", // Size
            "0", // Rotation
            "Bat", // Image source
            "#FFFFFF", // Image color
            2.0f, // Move speed
            "scale", // Move pattern
            1 // Quantity
        );

        // Create an animation with jump scare effect
        Instantiate_Card.Instance.createAnimation(
            "Question Card", // Parent name
            "JumpScare animation", // animation name
            "0", "0", // Initial position
            "100", "100", // Size
            "0", // Rotation
            "Bat", // Image source
            "#FFFFFF", // Image color
            1.0f, // Move speed
            "jumpscare", // Move pattern
            1 // Quantity
        );

        //Instantiate_Card.Instance.createAnimation("Question Card", "Vertical animation", "200", "500", "100", "100", "3", "Bat", "#FFFFFF", 4.0f, "vertical", 2);
        //Instantiate_Card.Instance.createAnimation("Question Card", "Horizontal animation", "0", "300", "100", "100", "-10", "Bat", "#FFFFFF", 3.5f, "horizontal", 1);
        //Instantiate_Card.Instance.createAnimation("Question Card", "zig zag animation", "-350", "500", "100", "100", "0", "Bat", "#FFFFFF", 3.0f, "zigzag", 1);
        //Instantiate_Card.Instance.createAnimation("Question Card", "Circuly animation", "250", "300", "100", "100", "-10", "Bat", "#FFFFFF", 2.0f, "circular", 2);
        //Instantiate_Card.Instance.createAnimation("Question Card", "Scaling animation", "0", "200", "100", "100", "0", "Bat", "#FFFFFF", 2.0f, "scale", 1);
        //Instantiate_Card.Instance.createAnimation("Question Card", "JumpScare animation", "0", "0", "100", "100", "0", "Bat", "#FFFFFF", 1.0f, "jumpscare", 1);
    }

    private void SetupTimerSound()
    {
        // Other sounds - alarme, beam-wowowfast, moo-death

        CC_Timer.Instance.LoadSoundFromResources("beam-wowowfast");
        CC_Timer.Instance.playSoundAt = 8.0f;
        CC_Timer.Instance.TimerIsRunning(true);
    }

}
