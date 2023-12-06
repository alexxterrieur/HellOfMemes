using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void SaveBestWaveNumber(int waveNumber)
    {
        PlayerPrefs.SetInt("BestWaveNumber", waveNumber);
    }

    public void SaveBestScore(int score)
    {
        PlayerPrefs.SetInt("BestScore", score);
    }

    public void SaveBestTime(float timeInGame)
    {
        PlayerPrefs.SetFloat("BestTime", timeInGame);
    }
}
