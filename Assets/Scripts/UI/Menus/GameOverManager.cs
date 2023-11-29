using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;

    [SerializeField] TMP_Text waveText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timerText;

    public void DisplayScores()
    {
        int waveCompleted = scoreManager.waveNumber - 1;
        waveText.text = "Wave: " + waveCompleted;
        scoreText.text = "Score: " + scoreManager.playerScore;
        timerText.text = "Timer: " + scoreManager.timerSting;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
