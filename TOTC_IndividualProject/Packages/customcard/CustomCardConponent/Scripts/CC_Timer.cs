using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CC_Timer : MonoBehaviour
{
    public static CC_Timer Instance { get; private set; }

    [Header("Timer")]
    public float timeForQuestion = 20.0f;
    public bool timerRunning = false;
    public bool changeColor = false;
    public GameObject timerComponent;
    public TextMeshProUGUI timerText;

    [Header("Time's Up Display")]
    public GameObject timeoutShade;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip startSound;
    public float playSoundAt = 20.0f;

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

    private void Update()
    {
        // For other use

        //if (timerRunning)
        //{
        //    timeForQuestion -= Time.deltaTime;
        //    TimerUpdate();
        //    if (timeForQuestion <= playSoundAt && !audioSource.isPlaying)
        //    {
        //        PlaySound(true);
        //    }
        //    if (timeForQuestion <= 0)
        //    {
        //        timerRunning = false;
        //        TimesUp();
        //    }
        //}

        if (timerRunning)
        {
            if (timeForQuestion <= (playSoundAt + 1.0f) && !audioSource.isPlaying)
            {
                PlaySound(true);
            }
        }
        if (timeForQuestion <= 0)
        {
            TimesUp();
        }
    }

    public void ShowTimer(bool showTimer)
    {
        timerComponent.SetActive(showTimer);
    }

    public void TimerUpdate()
    {
        timerText.text = ((int)timeForQuestion).ToString();
        UpdateTimerColor();
    }

    public void TimerIsRunning(bool running)
    {
        timerRunning = running;
        if (running)
        {
            timeoutShade.SetActive(false);
        }
    }

    public void ResetTimer()
    {
        TimerIsRunning(false);
        timeForQuestion = 20;
        UpdateTimerColor();
        PlaySound(false);
    }

    /// <summary>
    /// changes color for the timer UI
    /// </summary>
    public void UpdateTimerColor()
    {
        Color targetColor = Color.white;

        if (changeColor)
        {
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
        }

        UnityEngine.UI.Image image = timerComponent.GetComponent<UnityEngine.UI.Image>();
        image.color = targetColor;
    }

    /// <summary>
    /// plays the sound
    /// </summary>
    /// <param name="play"></param>
    public void PlaySound(bool play)
    {
        if (play)
        {
            audioSource.PlayOneShot(startSound);
            Debug.Log("Sound is playing");
        }
        else
        {
            audioSource.Stop();
            Debug.Log("Sound is stopped");
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

    /// <summary>
    /// loads the sound from resources
    /// </summary>
    /// <param name="soundName"></param>
    public void LoadSoundFromResources(string soundName)
    {
        AudioClip clip = Resources.Load<AudioClip>($"Sounds/{soundName}");
        if (clip != null)
        {
            startSound = clip;
        }
        else
        {
            Debug.LogError($"Sound '{soundName}' not found in Resources/Sounds!");
        }
    }
}

