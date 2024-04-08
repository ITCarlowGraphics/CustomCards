using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }

    [Header("Timer")]
    public float timeForQuestion = 20.0f;
    public bool timerRunning = false;
    public GameObject timerComponent;
    public TextMeshProUGUI timerText;

    [Header("Time's Up Display")]
    public GameObject timeoutShade;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip startSound;

    private void Awake()
    {
        timerComponent = GameObject.FindGameObjectWithTag("Timer");

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Warning: multiple Timer instances exist!");
            Destroy(gameObject);
        }
    }

    public void ShowTimer(bool showTimer)
    {
        timerComponent.SetActive(showTimer);
    }

    public void TimerUpdate()
    {
        timerText.text = ((int)timeForQuestion).ToString();   
    }

    public void TimerIsRunning(bool running)
    {
        timerRunning = running;
        if(running)
        {
            timeoutShade.SetActive(false);
        }
    }

    public void resetTimer()
    {
        TimerIsRunning(false);
        timeForQuestion = 20;
        UpdateTimerColorAndText();
    }

    public void UpdateTimerColorAndText()
    {
        Color targetColor = Color.white;

        if (timeForQuestion > 15)
        {
            // Green to Yellow
            targetColor = Color.Lerp(Color.yellow, Color.green, (timeForQuestion - 15) / 5);
        }
        else if (timeForQuestion > 10)
        {
            // Yellow to Orange
            targetColor = Color.Lerp(new Color(1, 0.5f, 0), Color.yellow, (timeForQuestion - 10) / 5);
        }
        else if (timeForQuestion > 5)
        {
            // Orange to Red
            targetColor = Color.Lerp(Color.red, new Color(1, 0.5f, 0), (timeForQuestion - 5) / 5);
        }
        else
        {
            // Red
            targetColor = Color.red;
        }

        UnityEngine.UI.Image image = timerComponent.GetComponent<UnityEngine.UI.Image>();
        image.color = targetColor;
    }

    public void PlaySound(bool play)
    {
        if (play)
        {
            audioSource.PlayOneShot(startSound);
        }
        else 
        {
            audioSource.Stop();
        }
    }

    public void TimesUp()
    {
        if (timeoutShade != null)
        {
            timeoutShade.SetActive(true);
        }
        PlaySound(false);
    }
}
