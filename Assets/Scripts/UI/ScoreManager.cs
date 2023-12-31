using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    EnemiesSpawner enemiesSpawner;
    [SerializeField] TMP_Text waveText;
    public int waveNumber;

    LifeManager playerLifeManager;
    [SerializeField] TMP_Text lifeText;

    public int playerScore;
    [SerializeField] TMP_Text scoreText;

    public float timer;
    [SerializeField] TMP_Text timeText;
    public string timerSting;


    private void Start()
    {
        Time.timeScale = 1f;
        playerLifeManager = GameObject.Find("Player").GetComponent<LifeManager>();
        enemiesSpawner = GameObject.Find("EnemiesSpawner").GetComponent<EnemiesSpawner>();
    }

    private void Update()
    {
        waveNumber = enemiesSpawner.waveNumber - 1;
        waveText.text = "Wave: " + waveNumber;
        lifeText.text = "Life: " + playerLifeManager.life;
        scoreText.text = "Score: " + playerScore;
        DisplayTime(timer);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timer += Time.deltaTime;
        timerSting = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeText.text = "" + timerSting;
        //timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);        
    }
}
