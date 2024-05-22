using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTest : MonoBehaviour
{

    void Start()
    {
        InstantiatePrefabInCanvas();

        //CreateCustomImage();
        //CreateCustomText();
        //CreateCustomButton();
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
        // RGB,255,100,255,
        // #1949c2
        // Fonts - Nunito Bold, AIW, Nightcore
        // Sound - 20-second-timer-v3, beam-wowowfast, moo-death

        Custom_Card.Instance.createCard(
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
        Custom_Card.Instance.createImage(
            "Canvas", // Parent name
            "Custom image", // Image name
            "0", "100", // Position
            "400", "150", // Size
            "0", // Rotation
            "MadPenguin", // Image source
            "#FFFFFF", // Image color
            "" // Image material (optional)
            );

        Custom_Card.Instance.createImage(
            "Canvas", // parent name 
            "Custom Image With Behaviors", // image name
            "0", "400", // positions
            "800", "350", // witdh and height
            "0", // rotation
            "MadPenguin", // image source
            "#FFFFFF", // image color
            "", // material
            true, // Attach ImageBehaviours script
            true, // Enable image swapping
            "Ellipse13", "Ellipse14", 1.0f, // Image swap parameters
            true, // Enable color changing
            "#FFFFFF", "#FF0000", 2.0f // Color change parameters
            );

        //Instantiate_Card.Instance.createImage("Question Card", "CustomImage", "0", "200", "400", "120", "0", "Rectangle 424", "#FFFFFF", "");
    }

    private void CreateCustomButton()
    {
        Custom_Card.Instance.createButton(
            "Canvas", // Parent GameObject name
            "Custom Button", // Button name
            "0", "100", // Position
            "400", "200", // Size
            "0", // Rotation
            "Click Me to pop", // Button text
            "#FFFFFF", // Text color
            "Nunito Bold", // Font name
            40, // Font size
            true, // Bold
            false, // Italic
            "Rectangle 424", // Button image source
            "#FF0000", // Highlight color
            //buttonHandler.OnCustomButtonClick // OnClick action
            () => {
                GameObject button = GameObject.Find("Custom Button");
                ButtonHandler buttonHandler = button.GetComponent<ButtonHandler>();
                buttonHandler.OnCustomButtonClick();
            } // OnClick action
            );

        Custom_Card.Instance.createButton(
            "Canvas", // Parent GameObject name
            "Custom Button 2", // Button name
            "100", "-200", // Position
            "400", "200", // Size
            "0", // Rotation
            "Click Me for animation", // Button text
            "#FFFFFF", // Text color
            "Nunito Bold", // Font name
            40, // Font size
            true, // Bold
            false, // Italic
            "Rectangle 424", // Button image source
            "#FF0000", // Highlight color
            //buttonHandler.onButtonClickCreateAnimation // OnClick action
            () => {
                GameObject button = GameObject.Find("Custom Button 2");
                ButtonHandler buttonHandler = button.GetComponent<ButtonHandler>();
                buttonHandler.onButtonClickCreateAnimation();
                buttonHandler.OnCustomButtonClick();
            } // OnClick action
            );

        Custom_Card.Instance.createButton(
            "Canvas", // Parent GameObject name
            "Custom Button 3", // Button name
            "100", "-400", // Position
            "400", "200", // Size
            "0", // Rotation
            "Click Me for create image", // Button text
            "#FFFFFF", // Text color
            "Nunito Bold", // Font name
            40, // Font size
            true, // Bold
            false, // Italic
            "Rectangle 424", // Button image source
            "#FF0000", // Highlight color
            //buttonHandler.onButtonClickCreateAnimation // OnClick action
            CreateCustomImage
            );
    }

    private void CreateCustomText()
    {
        Custom_Card.Instance.createText(
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
        Custom_Card.Instance.createAnimation(
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
        Custom_Card.Instance.createAnimation(
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
        Custom_Card.Instance.createAnimation(
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
        Custom_Card.Instance.createAnimation(
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
        Custom_Card.Instance.createAnimation(
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
        Custom_Card.Instance.createAnimation(
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
