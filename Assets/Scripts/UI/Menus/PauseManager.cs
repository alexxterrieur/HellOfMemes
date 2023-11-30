using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject warningPanel;
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
    }

    public void CloseControls()
    {
        controlsPanel.SetActive(false);
    }

    public void MenuButtonOnPausePanel()
    {
        warningPanel.SetActive(true);
    }

    public void CancelBackToMenu()
    {
        warningPanel.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
