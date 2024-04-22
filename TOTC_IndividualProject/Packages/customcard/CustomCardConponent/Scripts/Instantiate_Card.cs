using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Instantiate_Card : MonoBehaviour
{

    private GameObject questionCardBackground;


    void instantiateCard()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/H_Theme_Question Card");
        if (prefab != null)
        {
            GameObject instantiatedPrefab = Instantiate(prefab);
            instantiatedPrefab.transform.SetAsFirstSibling();
            instantiatedPrefab.transform.name = "Question Card";


        }
        else
        {
            Debug.LogError("Prefab not found!");
        }
    }
}
