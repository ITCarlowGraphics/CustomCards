using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Instantiate_Card : MonoBehaviour
{
    private static Instantiate_Card instance;
    Canvas canvas;

    public static Instantiate_Card Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Instantiate_Card>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(Instantiate_Card).Name);
                    instance = singletonObject.AddComponent<Instantiate_Card>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void createCard(
        string m_cardName, // Prefab of the card
        string layoutMode, // Layout changes
        string m_backgroundColor, // background color of the card
        string m_subjectTextColor, string m_subjectFontName, // subject text properties
        string m_questionTextColor, string m_questionTextFontName, // question text properties
        string m_correctTextColor, string m_correctFontName, // correct text properties
        string m_button1ImageName, string m_button2ImageName, string m_button3ImageName, // buttons properties
        string m_button1HighlightColor, string m_button2HighlightColor, string m_button3HighlightColor, // button highlight color
        string m_button1TextColor, string m_button2TextColor, string m_button3TextColor, // button text color
        string m_button1FontName, string m_button2FontName, string m_button3FontName, // button text font
        string m_timerImageName, string m_timerTextColor, string m_timerTextFont, // timer properties
        string m_okayImageName, string m_okayTextColor, string m_okayTextFont, // Okay button properties
        string m_switchSubjectImageName, string m_switchSubjectTextColor, string m_switchSubjectFontName // switch Subject properties
        )
    {
        canvas = FindObjectOfType<Canvas>();
        GameObject prefab = Resources.Load<GameObject>($"Prefabs/{m_cardName}");

        if (prefab != null && canvas != null)
        {
            GameObject instantiatedPrefab = Instantiate(prefab, canvas.transform);
            instantiatedPrefab.transform.SetAsFirstSibling();
            instantiatedPrefab.transform.name = "Question Card";

            // Change background color
            Image backgroundImage = instantiatedPrefab.transform.Find("Card Background").GetComponent<Image>();
            backGroundColorChange(backgroundImage, m_backgroundColor);

            // Change subject text properties
            TextMeshProUGUI textComponent = instantiatedPrefab.transform.Find("QuestionSubject").GetComponent<TextMeshProUGUI>();
            changeTextColor(textComponent, m_subjectTextColor);
            changeFont(textComponent, m_subjectFontName);

            // Change question text properties
            TextMeshProUGUI questionTextComponent = instantiatedPrefab.transform.Find("QuestionText").GetComponent<TextMeshProUGUI>();
            changeTextColor(questionTextComponent, m_questionTextColor);
            changeFont(questionTextComponent, m_questionTextFontName);

            // Change correct text properties
            TextMeshProUGUI CorrectTextComponent = instantiatedPrefab.transform.Find("CorrectText").GetComponent<TextMeshProUGUI>();
            changeTextColor(CorrectTextComponent, m_correctTextColor);
            changeFont(CorrectTextComponent, m_correctFontName);

            // Change button properties
            ChangeAnswerButtonProperties(instantiatedPrefab, "Answer1", m_button1ImageName, m_button1HighlightColor, m_button1TextColor, m_button1FontName);
            ChangeAnswerButtonProperties(instantiatedPrefab, "Answer2", m_button2ImageName, m_button2HighlightColor, m_button2TextColor, m_button2FontName);
            ChangeAnswerButtonProperties(instantiatedPrefab, "Answer3", m_button3ImageName, m_button3HighlightColor, m_button3TextColor, m_button3FontName);

            // Change Timer properties
            changeTimerProperties(instantiatedPrefab, "TimerPanel", m_timerImageName, m_timerTextColor, m_timerTextFont);

            // OkayButton properties
            changeOkayButtonProperties(instantiatedPrefab, "OkayButton", m_okayImageName, m_okayTextColor, m_okayTextFont);

            // Switch Subject properties
            changeSwitchSubjectProperties(instantiatedPrefab, "Switch Subject", m_switchSubjectImageName, m_switchSubjectTextColor, m_switchSubjectFontName);

            // Apply layout changes based on mode
            layoutChanges(instantiatedPrefab, layoutMode);
        }
        else
        {
            Debug.LogError("Prefab not found!");
        }
    }

    private void backGroundColorChange(Image backgroundImage, string m_backgroundColor)
    {
        if (backgroundImage != null)
        {
            Color backgroundColor = ParseColorString(m_backgroundColor);
            backgroundImage.color = backgroundColor;
        }
        else
        {
            Debug.LogError("Image component named 'Card Background' not found in the instantiated prefab to set background color!");
        }
    }

    private void changeTextColor(TextMeshProUGUI textComponent, string m_textColor)
    {
        if (textComponent != null)
        {
            Color textColor = ParseColorString(m_textColor);
            textComponent.color = textColor;
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component named 'Card Text' not found in the instantiated prefab to set text color!");
        }
    }

    private void changeFont(TextMeshProUGUI textComponent, string m_fontName)
    {
        if (textComponent != null)
        {
            TMP_FontAsset font = Resources.Load<TMP_FontAsset>($"Fonts/{m_fontName}");
            if (font != null)
            {
                textComponent.font = font;
            }
            else
            {
                Debug.LogError($"Font '{m_fontName}' not found in Resources!");
            }
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component named 'Card Text' not found in the instantiated prefab to set font!");
        }
    }

    private void ChangeAnswerButtonProperties(GameObject parent, string buttonName, string imageName, string highlightColor, string textColor, string fontName)
    {
        Transform buttonTransform = parent.transform.Find(buttonName);
        if (buttonTransform != null)
        {
            // Change button image
            Image buttonImage = buttonTransform.GetComponent<Image>();
            if (buttonImage != null)
            {
                Sprite newSprite = Resources.Load<Sprite>($"Textures/{imageName}");
                if (newSprite != null)
                {
                    buttonImage.sprite = newSprite;
                }
                else
                {
                    Debug.LogError($"Image '{imageName}' not found in Resources/Textures!");
                }
            }
            else
            {
                Debug.LogError($"Image component not found on button '{buttonName}'!");
            }

            // Change highlight color
            Button button = buttonTransform.GetComponent<Button>();
            if (button != null)
            {
                ColorBlock colorBlock = button.colors;
                Color highlightColorParsed = ParseColorString(highlightColor);
                colorBlock.highlightedColor = highlightColorParsed;
                button.colors = colorBlock;
            }
            else
            {
                Debug.LogError($"Button component not found on '{buttonName}'!");
            }

            // Change button text properties
            TextMeshProUGUI buttonText = buttonTransform.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                changeTextColor(buttonText, textColor);
                changeFont(buttonText, fontName);
            }
            else
            {
                Debug.LogError($"TextMeshProUGUI component not found on button '{buttonName}'!");
            }
        }
        else
        {
            Debug.LogError($"Button '{buttonName}' not found in the instantiated prefab!");
        }
    }

    private void changeTimerProperties(GameObject parent, string objectName, string imageName, string textColor, string fontName)
    {
        Transform objectTransform = parent.transform.Find(objectName);
        if (objectTransform != null)
        {
            // Change object image
            Image objectImage = objectTransform.GetComponent<Image>();
            if (objectImage != null)
            {
                Sprite newSprite = Resources.Load<Sprite>($"Textures/{imageName}");
                if (newSprite != null)
                {
                    objectImage.sprite = newSprite;
                }
                else
                {
                    Debug.LogError($"Image '{imageName}' not found in Resources/Textures!");
                }
            }
            else
            {
                Debug.LogError($"Image component not found on object '{objectName}'!");
            }

            // Change object text properties
            TextMeshProUGUI objectText = objectTransform.GetComponentInChildren<TextMeshProUGUI>();
            if (objectText != null)
            {
                changeTextColor(objectText, textColor);
                changeFont(objectText, fontName);
            }
            else
            {
                Debug.LogError($"TextMeshProUGUI component not found on object '{objectName}'!");
            }
        }
        else
        {
            Debug.LogError($"Object '{objectName}' not found in the instantiated prefab!");
        }
    }

    private void changeOkayButtonProperties(GameObject parent, string objectName, string imageName, string textColor, string fontName)
    {
        Transform objectTransform = parent.transform.Find(objectName);
        if (objectTransform != null)
        {
            // Change object image
            Image objectImage = objectTransform.GetComponent<Image>();
            if (objectImage != null)
            {
                Sprite newSprite = Resources.Load<Sprite>($"Textures/{imageName}");
                if (newSprite != null)
                {
                    objectImage.sprite = newSprite;
                }
                else
                {
                    Debug.LogError($"Image '{imageName}' not found in Resources/Textures!");
                }
            }
            else
            {
                Debug.LogError($"Image component not found on object '{objectName}'!");
            }

            // Change object text properties
            TextMeshProUGUI objectText = objectTransform.GetComponentInChildren<TextMeshProUGUI>();
            if (objectText != null)
            {
                changeTextColor(objectText, textColor);
                changeFont(objectText, fontName);
            }
            else
            {
                Debug.LogError($"TextMeshProUGUI component not found on object '{objectName}'!");
            }
        }
        else
        {
            Debug.LogError($"Object '{objectName}' not found in the instantiated prefab!");
        }
    }

    private void changeSwitchSubjectProperties(GameObject parent, string objectName, string imageName, string textColor, string fontName)
    {
        Transform switchSubjectTransform = parent.transform.Find(objectName);
        if (switchSubjectTransform != null)
        {
            // Change the image of "ss Icon"
            Transform ssIconTransform = switchSubjectTransform.Find("ss Icon");
            if (ssIconTransform != null)
            {
                Image ssIconImage = ssIconTransform.GetComponent<Image>();
                if (ssIconImage != null)
                {
                    Sprite newSprite = Resources.Load<Sprite>($"Textures/{imageName}");
                    if (newSprite != null)
                    {
                        ssIconImage.sprite = newSprite;
                    }
                    else
                    {
                        Debug.LogError($"Image '{imageName}' not found in Resources/Textures!");
                    }
                }
                else
                {
                    Debug.LogError($"Image component not found on 'ss Icon'!");
                }
            }
            else
            {
                Debug.LogError($"'ss Icon' not found under '{objectName}'!");
            }

            // Change the text properties of "ss Text"
            Transform ssTextTransform = switchSubjectTransform.Find("ss Text");
            if (ssTextTransform != null)
            {
                TextMeshProUGUI ssTextComponent = ssTextTransform.GetComponent<TextMeshProUGUI>();
                if (ssTextComponent != null)
                {
                    changeTextColor(ssTextComponent, textColor);
                    changeFont(ssTextComponent, fontName);
                }
                else
                {
                    Debug.LogError($"TextMeshProUGUI component not found on 'ss Text'!");
                }
            }
            else
            {
                Debug.LogError($"'ss Text' not found under '{objectName}'!");
            }
        }
        else
        {
            Debug.LogError($"Object '{objectName}' not found in the instantiated prefab!");
        }
    }

    /// <summary>
    /// Can choose between 2 color types but it needs to be formated correctly
    /// </summary>
    /// <param name="colorString"></param>
    /// <returns></returns>
    private Color ParseColorString(string colorString)
    {
        Color color = new Color(1, 1, 1); // Default to white if parsing fails
        if (colorString.StartsWith("#"))
        {
            if (!ColorUtility.TryParseHtmlString(colorString, out color))
            {
                Debug.LogError("Invalid hex color string!");
            }
        }
        else if (colorString.StartsWith("RGB", System.StringComparison.OrdinalIgnoreCase))
        {
            string[] parts = colorString.Substring(4, colorString.Length - 5).Split(',');

            if (parts.Length == 3)
            {
                float r = float.Parse(parts[0]) / 255.0f;
                float g = float.Parse(parts[1]) / 255.0f;
                float b = float.Parse(parts[2]) / 255.0f;
                color = new Color(r, g, b);
            }
            else
            {
                Debug.LogError("RGB color string is not properly formatted!");
            }
        }
        return color;
    }

    private void layoutChanges(GameObject parent, string layoutMode)
    {
        switch (layoutMode)
        {
            case "1":
                // Default layout, no changes needed
                break;
            case "2":
                // Custom layout 2
                SetPosition(parent, "QuestionSubject", new Vector2(0, 1100));
                SetPosition(parent, "QuestionText", new Vector2(0, 860));
                SetPosition(parent, "CorrectText", new Vector2(0, -900));
                SetPosition(parent, "TimerPanel", new Vector2(0, 500));
                SetPosition(parent, "OkayButton", new Vector2(0, -1080));
                SetPosition(parent, "Switch Subject", new Vector2(0, 200));
                break;
            case "3":
                // Custom layout 3
                SetTransform(parent, "QuestionSubject", new Vector2(0, 370), new Vector3(1.5f, 1.5f, 1));
                SetTransform(parent, "QuestionText", new Vector2(280, -130), width: 60, height: 450);
                SetTransform(parent, "CorrectText", new Vector2(0, 600));
                SetTransform(parent, "TimerPanel", new Vector2(-200, 1000));
                SetTransform(parent, "OkayButton", new Vector2(0, -1080), new Vector3(1.2f, 1.2f, 1));
                SetTransform(parent, "Switch Subject", new Vector2(350, 1000), new Vector3(1.5f, 1.5f, 1));
                SetTransform(parent, "Answer1", new Vector2(-200, 120), new Vector3(0.8f, 0.8f, 1));
                SetTransform(parent, "Answer2", new Vector2(-200, -100), new Vector3(0.8f, 0.8f, 1));
                SetTransform(parent, "Answer3", new Vector2(-200, -315), new Vector3(0.8f, 0.8f, 1));
                break;
            default:
                Debug.LogWarning("Invalid layout mode");
                break;
        }
    }

    private void SetPosition(GameObject parent, string objectName, Vector2 newPosition)
    {
        Transform objTransform = parent.transform.Find(objectName);
        if (objTransform != null)
        {
            objTransform.localPosition = newPosition;
        }
        else
        {
            Debug.LogError($"Object '{objectName}' not found in the instantiated prefab!");
        }
    }

    private void SetTransform(GameObject parent, string objectName, Vector2 newPosition, Vector3? newScale = null, float width = -1, float height = -1)
    {
        Transform objTransform = parent.transform.Find(objectName);
        if (objTransform != null)
        {
            objTransform.localPosition = newPosition;

            if (newScale.HasValue)
            {
                objTransform.localScale = newScale.Value;
            }

            RectTransform rectTransform = objTransform.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                if (width > 0)
                {
                    rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
                }
                if (height > 0)
                {
                    rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
                }
            }
        }
        else
        {
            Debug.LogError($"Object '{objectName}' not found in the instantiated prefab!");
        }
    }

}
