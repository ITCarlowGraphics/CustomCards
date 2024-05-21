using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{

    public void OnCustomButtonClick()
    {
        // Find the ButtonEffects component on the same GameObject and call its OnButtonClick method
        GameObject buttonGameObject = gameObject;
        Debug.Log(gameObject);

        ButtonEffects clickEffect = buttonGameObject.GetComponent<ButtonEffects>();

        if (clickEffect != null)
        {
            clickEffect.OnButtonClick();
        }
        else
        {
            Debug.LogError("ButtonEffects component not found on this GameObject!");
        }
    }

    public void onButtonClickCreateAnimation()
    {
        Debug.Log("ANIMATION APPEARS");

        Custom_Card.Instance.createAnimation(
            "Canvas", // Parent name
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
    }
}
