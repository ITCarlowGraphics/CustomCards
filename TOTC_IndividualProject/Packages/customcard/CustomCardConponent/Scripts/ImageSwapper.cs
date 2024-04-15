using UnityEngine;
using UnityEngine.UI;

public class ImageSwapper : MonoBehaviour
{
    public Sprite image1;       // First image
    public Sprite image2;       // Second image
    public float swapInterval = 1.0f;  // Interval in seconds at which images should switch

    private Image targetImage;   // The Image component on the GameObject
    private float nextSwapTime = 0;

    void Start()
    {
        targetImage = GetComponent<Image>();
        if (targetImage == null)
        {
            Debug.LogError("ImageSwapper cannot find an Image component on the GameObject.");
            return;
        }

        // Initialize with the first image
        targetImage.sprite = image1;
    }

    void Update()
    {
        if (CC_Timer.Instance == null || !CC_Timer.Instance.timerRunning)
            return;

        if (Time.time >= nextSwapTime)
        {
            SwapImage();
            nextSwapTime = Time.time + swapInterval;
        }
    }

    private void SwapImage()
    {
        if (targetImage.sprite == image1)
            targetImage.sprite = image2;
        else
            targetImage.sprite = image1;
    }
}
