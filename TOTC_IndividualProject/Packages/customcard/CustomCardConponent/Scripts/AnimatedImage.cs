using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedImage : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public string movePattern = "";

    private Vector3 startPosition;
    private float time;

    private void Start()
    {
        startPosition = transform.localPosition;
    }

    private void Update()
    {
        time += Time.deltaTime * moveSpeed;

        switch (movePattern.ToLower())
        {
            case "zigzag":
                transform.localPosition = startPosition + new Vector3(time, Mathf.Sin(time * 5) * 50, 0);
                break;
            case "circular":
                transform.localPosition = startPosition + new Vector3(Mathf.Cos(time) * 100, Mathf.Sin(time) * 100, 0);
                break;
            default:
                transform.localPosition = startPosition + new Vector3(time, 0, 0);
                break;
        }
    }
}
