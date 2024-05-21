using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageBehaviours : MonoBehaviour
{
    [Header("Image Swap Settings")]
    public bool enableImageSwap = false;
    public Sprite image1;
    public Sprite image2;
    public float swapInterval = 0.5f;

    [Header("Color Change Settings")]
    public bool enableColorChange = false;
    public Color startColor = Color.white;
    public Color endColor = Color.red;
    public float colorChangeDuration = 1.0f;

    private Image targetImage;
    private float nextSwapTime;
    private float colorChangeStartTime;

    void Start()
    {
        targetImage = GetComponent<Image>();
        if (targetImage == null)
        {
            Debug.LogError("ImageBehaviours cannot find an Image component on the GameObject.");
            return;
        }

        if (enableImageSwap)
        {
            targetImage.sprite = image1;
            nextSwapTime = Time.time + swapInterval;
        }

        if (enableColorChange)
        {
            targetImage.color = startColor;
            colorChangeStartTime = Time.time;
        }
    }

    void Update()
    {
        if (enableImageSwap && Time.time >= nextSwapTime)
        {
            SwapImage();
            nextSwapTime = Time.time + swapInterval;
        }

        if (enableColorChange)
        {
            float t = (Time.time - colorChangeStartTime) / colorChangeDuration;
            targetImage.color = Color.Lerp(startColor, endColor, t);
            if (t >= 1.0f)
            {
                // Reverse the colors for the next transition
                Color temp = startColor;
                startColor = endColor;
                endColor = temp;
                colorChangeStartTime = Time.time;
            }
        }
    }

    private void SwapImage()
    {
        if (targetImage.sprite == image1)
        {
            targetImage.sprite = image2;
        }
        else
        {
            targetImage.sprite = image1;
        }
    }
}
