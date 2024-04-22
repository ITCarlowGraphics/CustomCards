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

    public void instantiateCard(string cardName, Color backgroundColor)
    {
        canvas = FindObjectOfType<Canvas>();
        GameObject prefab = Resources.Load<GameObject>("Prefabs/" + cardName);

        if (prefab != null && canvas != null)
        {
            GameObject instantiatedPrefab = Instantiate(prefab, canvas.transform);
            instantiatedPrefab.transform.SetAsFirstSibling();
            instantiatedPrefab.transform.name = "Question Card";

           
            
        }
        else
        {
            Debug.LogError("Prefab not found!");
        }
    }
}
