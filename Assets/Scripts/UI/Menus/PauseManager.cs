using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject mainPausePanel;
    public GameObject pausePanel;
    public GameObject controlsPanel;
    public GameObject warningPanel;
    VideoSwitch videoSwitch;

    private void Start()
    {
        videoSwitch = GameObject.Find("BackgroundVideo").GetComponent<VideoSwitch>();
    }

    public void Resume()
    {
        videoSwitch.ResumeVideo();
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
    
    public void Controls()
    {
        controlsPanel.SetActive(true);
        mainPausePanel.SetActive(false);
    }

    public void CloseControls()
    {
        mainPausePanel.SetActive(true);
        controlsPanel.SetActive(false);
    }

    public void MenuButtonOnPausePanel()
    {
        warningPanel.SetActive(true);
        mainPausePanel.SetActive(false);
    }

    public void CancelBackToMenu()
    {
        mainPausePanel.SetActive(true);
        warningPanel.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
