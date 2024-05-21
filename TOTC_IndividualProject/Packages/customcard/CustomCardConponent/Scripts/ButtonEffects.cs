using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEffects : MonoBehaviour
{
    private Vector3 originalScale;
    private Quaternion originalRotation;
    private bool isAnimating = false;
    private float animationTime = 0.1f;
    private float elapsedTime = 0f;

    void Start()
    {
        originalScale = transform.localScale;
        originalRotation = transform.localRotation;
    }

    public void OnButtonClick()
    {
        if (!isAnimating)
        {
            StartCoroutine(AnimateButton());
        }
    }

    private IEnumerator AnimateButton()
    {
        isAnimating = true;
        elapsedTime = 0f;

        // Scale up and rotate
        while (elapsedTime < animationTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / animationTime;
            transform.localScale = Vector3.Lerp(originalScale, originalScale * 1.1f, t);
            transform.localRotation = Quaternion.Lerp(originalRotation, Quaternion.Euler(0, 0, -10), t);
            yield return null;
        }

        // Reset scale and rotation
        elapsedTime = 0f;
        while (elapsedTime < animationTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / animationTime;
            transform.localScale = Vector3.Lerp(originalScale * 1.1f, originalScale, t);
            transform.localRotation = Quaternion.Lerp(Quaternion.Euler(0, 0, -10), originalRotation, t);
            yield return null;
        }

        isAnimating = false;
    }
}
