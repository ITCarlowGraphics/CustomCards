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
    public void createCard(string m_cardName, string m_backgroundColor, string m_subjectTextColor, string m_subjectFontName)
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
