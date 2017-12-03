using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public BoolValue Sound;
    public GameObject soundText;
    public GameObject introPanel;

    private bool showingIntro = false;

    private void Start()
    {
        showingIntro = false;

        if (Sound.Value)
        {
            soundText.GetComponent<TextMeshProUGUI>().text = "Music is on";
        }
        else
        {
            soundText.GetComponent<TextMeshProUGUI>().text = "Music is off";
        }
    }

    private void Update()
    {
        if (showingIntro)
        {
            if (Input.anyKey)
            {
                StartGame();
            }
        }
    }

    public void ShowIntro()
    {
        showingIntro = true;
        introPanel.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ToggleSound()
    {
        Sound.Value = !Sound.Value;
        if (Sound.Value)
        {
            soundText.GetComponent<TextMeshProUGUI>().text = "Music is on";
        }
        else
        {
            soundText.GetComponent<TextMeshProUGUI>().text = "Music is off";
        }
    }
}
