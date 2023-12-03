using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject creditsPanel;

    private void Start()
    {
        Cursor.visible = false;
    }
    public void Play(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void CloseCredits()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    private void OnEchap(InputValue inputValue)
    {
        if(creditsPanel.activeInHierarchy)
        {
            creditsPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
