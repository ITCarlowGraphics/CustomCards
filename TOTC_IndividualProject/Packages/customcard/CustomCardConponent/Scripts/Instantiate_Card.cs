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

    public void createCard(string cardName, string hexBackgroundColor)
    {
        canvas = FindObjectOfType<Canvas>();
        GameObject prefab = Resources.Load<GameObject>("Prefabs/" + cardName);

        if (prefab != null && canvas != null)
        {
            GameObject instantiatedPrefab = Instantiate(prefab, canvas.transform);
            instantiatedPrefab.transform.SetAsFirstSibling();
            instantiatedPrefab.transform.name = "Question Card";

            Image backgroundImage = instantiatedPrefab.transform.Find("Card Background").GetComponent<Image>();
            if (backgroundImage != null)
            {
                Color backgroundColor;
                if (ColorUtility.TryParseHtmlString(hexBackgroundColor, out backgroundColor))
                {
                    backgroundImage.color = backgroundColor;
                }
                else
                {
                    Debug.LogError("Invalid hex color string!");
                }
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
}
