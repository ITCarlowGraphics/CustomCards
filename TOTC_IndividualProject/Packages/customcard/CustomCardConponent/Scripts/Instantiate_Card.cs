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

    /// <summary>
    /// Creates a custom card using multple different values
    /// </summary>
    /// <param name="m_cardName"></param>
    /// <param name="m_backgroundColor"></param>
    public void createCard(
        string m_cardName, // Prefab of the card
        string m_backgroundColor, // background color of the card
        string m_subjectTextColor, string m_subjectFontName, // subject text properties
        string m_questionTextColor, string m_questionTextFontName, // question text properties
        string m_correctTextColor, string m_correctFontName, // correct text properties
        string m_button1ImageName, string m_button2ImageName, string m_button3ImageName, // buttons properties
        string m_button1HighlightColor, string m_button2HighlightColor, string m_button3HighlightColor, // button highlight color
        string m_button1TextColor, string m_button2TextColor, string m_button3TextColor, // button text color
        string m_button1FontName, string m_button2FontName, string m_button3FontName // button text font
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
}
