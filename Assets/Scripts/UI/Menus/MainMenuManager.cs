using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;

    public void Play(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
