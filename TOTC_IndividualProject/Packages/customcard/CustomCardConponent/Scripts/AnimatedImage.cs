using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedImage : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public string movePattern = "";

    private Vector3 startPosition;
    private float time;
    private RectTransform rectTransform;
    private RectTransform cardBackground;
    private bool isJumpScareCompleted = false;

    private void Start()
    {
        startPosition = transform.localPosition;
        rectTransform = GetComponent<RectTransform>();

        // Find the "Card Background" RectTransform this is to make it appear on the other side if it leaves the background
        GameObject cardBackgroundObject = GameObject.Find("Card Background");
        if (cardBackgroundObject != null)
        {
            cardBackground = cardBackgroundObject.GetComponent<RectTransform>();
        }
        else
        {
            Debug.LogError("Card Background not found!");
        }
    }

    private void Update()
    {
        if (cardBackground == null) return;

        time += Time.deltaTime * moveSpeed;

        switch (movePattern.ToLower())
        {
            case "vertical":
                transform.localPosition += new Vector3(0, moveSpeed, 0);
                break;
            case "horizontal":
                transform.localPosition += new Vector3(moveSpeed, 0, 0);
                break;
            case "zigzag":
                transform.localPosition = startPosition + new Vector3(0, Mathf.Sin(time * moveSpeed) * 50, 0);
                break;
            case "circular":
                transform.localPosition = startPosition + new Vector3(Mathf.Cos(time * moveSpeed) * 100, Mathf.Sin(time * moveSpeed) * 100, 0);
                break;
            case "scale":
                transform.localScale = new Vector3(1 + Mathf.Sin(time * moveSpeed) * 0.5f, 1 + Mathf.Sin(time * moveSpeed) * 0.5f, 1);
                break;
            case "jumpscare": // only runs once
                if (!isJumpScareCompleted)
                {
                    StartCoroutine(JumpScareAnimation());
                }
                break;
            default:
                transform.localPosition += new Vector3(moveSpeed, 0, 0);
                break;
        }

        if (movePattern.ToLower() != "jumpscare")
        {
            ReappearOnOppositeSide();
        }
    }

    private void ReappearOnOppositeSide()
    {
        Vector3 localPos = rectTransform.localPosition;
        Vector2 halfSize = cardBackground.rect.size / 2;

        if (localPos.x > halfSize.x)
        {
            localPos.x = -halfSize.x;
        }
        else if (localPos.x < -halfSize.x)
        {
            localPos.x = halfSize.x;
        }

        if (localPos.y > halfSize.y)
        {
            localPos.y = -halfSize.y;
        }
        else if (localPos.y < -halfSize.y)
        {
            localPos.y = halfSize.y;
        }

        rectTransform.localPosition = localPos;
    }

    private IEnumerator JumpScareAnimation()
    {
        // Initial scale up for jump scare
        float initialScale = 1f;
        float targetScale = 10f;
        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float scale = Mathf.Lerp(initialScale, targetScale, elapsed / duration);
            transform.localScale = new Vector3(scale, scale, scale);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Maintain target scale for a moment
        yield return new WaitForSeconds(0.2f);

        // Fade out
        Image imageComponent = GetComponent<Image>();
        if (imageComponent != null)
        {
            elapsed = 0f;
            Color initialColor = imageComponent.color;
            Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0);

            while (elapsed < duration)
            {
                imageComponent.color = Color.Lerp(initialColor, targetColor, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }
        }

        // Destroy the game object after the jump scare
        Destroy(gameObject);
        isJumpScareCompleted = true;
    }
}
