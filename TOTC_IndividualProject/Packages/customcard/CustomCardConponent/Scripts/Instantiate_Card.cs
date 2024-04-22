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

    public void createCard(string m_cardName, string m_backgroundColor)
    {
        canvas = FindObjectOfType<Canvas>();
        GameObject prefab = Resources.Load<GameObject>("Prefabs/" + m_cardName);

        if (prefab != null && canvas != null)
        {
            GameObject instantiatedPrefab = Instantiate(prefab, canvas.transform);
            instantiatedPrefab.transform.SetAsFirstSibling();
            instantiatedPrefab.transform.name = "Question Card";

            Image backgroundImage = instantiatedPrefab.transform.Find("Card Background").GetComponent<Image>();
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
        else
        {
            Debug.LogError("Prefab not found!");
        }
    }

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