using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionCard_Customization : MonoBehaviour
{
    private int red = 120;
    private int green = 10;
    private int blue = 50;

    void Start()
    {
        float r = red / 255f;
        float g = green / 255f;
        float b = blue / 255f;

        Transform questionCardBackgroundTransform = transform.Find("Card Background");
        Transform QuestionSubjectTransform = transform.Find("QuestionSubject"); 

        if (questionCardBackgroundTransform != null)
        {
            Image backgroundImg = questionCardBackgroundTransform.GetComponent<Image>();

            if (backgroundImg != null)
            {
                backgroundImg.color = new Color(r, g, b);
            }
            else
            {
                Debug.LogError("Image component not found on the QuestionCardBackground object!");
            }
        }
        else
        {
            Debug.LogError("An Object has not been found !!!!!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
