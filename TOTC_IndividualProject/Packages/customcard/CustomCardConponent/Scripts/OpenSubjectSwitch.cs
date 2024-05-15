using TMPro;
using UnityEngine;

public class OpenSubjectSwitch : MonoBehaviour
{
    public GameObject switchSubject;
    public TextMeshProUGUI attemptsText;

    private void Awake()
    {
        switchSubject = GameObject.Find("SwitchSubjectPanel");
    }

    /// <summary>
    /// opens the switch subject panel
    /// </summary>
    public void ActivateSwitchSubject()
    {
        if (attemptsText != null && !attemptsText.text.StartsWith("0/"))
        {
            if (switchSubject != null)
            {
                switchSubject.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Switch Subject GameObject is not assigned.", this);
            }
        }
        else
        {
            Debug.LogWarning("No attempts left or Attempts TMPro component is not assigned.", this);
        }
    }
}
