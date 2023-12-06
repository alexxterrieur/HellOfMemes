using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] SaveManager saveManager;

    [SerializeField] TMP_Text waveText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timerText;

    [SerializeField] TMP_Text bestWaveText;
    [SerializeField] TMP_Text bestScoreText;
    [SerializeField] TMP_Text bestTimerText;

    private void OnEnable()
    {
        UpdateBestScore();
        DisplayScores();
        DisplayBestScores();
    }

    public void UpdateBestScore()
    {
        //int bestWave = saveManager.GetBestScore("WaveNumber");
        //int bestScore = saveManager.GetBestScore("Score");
        //float bestTime = saveManager.GetBestScore("Time");

        int bestWave = PlayerPrefs.GetInt("BestWaveNumber");
        int bestScore = PlayerPrefs.GetInt("BestScore");
        float bestTime = PlayerPrefs.GetFloat("BestTime");


        if (bestWave < scoreManager.waveNumber)
        {
            bestWave = scoreManager.waveNumber;
            saveManager.SaveBestWaveNumber(bestWave);
        }
        if(bestScore < scoreManager.playerScore)
        {
            bestScore = scoreManager.playerScore;
            saveManager.SaveBestScore(bestScore);
        }
        if(bestTime < scoreManager.timer)
        {
            bestTime = scoreManager.timer;
            saveManager.SaveBestTime(bestTime);
        }
    }

    public void DisplayScores()
    {
        waveText.text = "Wave: " + scoreManager.waveNumber;
        scoreText.text = "Score: " + scoreManager.playerScore;
        timerText.text = "Timer: " + scoreManager.timerSting;
    }

    public void DisplayBestScores()
    {
        bestWaveText.text = "Best: " + PlayerPrefs.GetInt("BestWaveNumber");
        bestScoreText.text = "Best: " + PlayerPrefs.GetInt("BestScore");

        float bestTime = PlayerPrefs.GetFloat("BestTime");
        float minutes = Mathf.FloorToInt(bestTime / 60);
        float seconds = Mathf.FloorToInt(bestTime % 60);

        string bestTimerSting = string.Format("{0:00}:{1:00}", minutes, seconds);
        bestTimerText.text = "Best: " + bestTimerSting;
    }

    public void Retry()
    {
        SceneManager.LoadScene("LVL_1");
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
