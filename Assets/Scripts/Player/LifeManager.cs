using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    public int life;
    public int score;
    public ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
        
    }

    public void TakeDamages(int damages)
    {
        life -= damages;
    }

    private void Update()
    {
        Die();
    }

    public void Die()
    {
        if(life <= 0)
        {
            if(gameObject.name != "Player")
            {
                scoreManager.playerScore += score;
                Destroy(gameObject);
            }
            else
            {
                Time.timeScale = 0f;
                gameOverPanel.SetActive(true);
                GameOverManager gameOverManager = GameObject.Find("GameOverManager").GetComponent<GameOverManager>();
                gameOverManager.DisplayScores();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "Enemy")
        {
            if (collision.gameObject.tag == "PlayerBullet")
            {
                TakeDamages(collision.gameObject.GetComponent<Bullet>().damages);
                collision.gameObject.SetActive(false);
                Debug.Log("contact playerBullet");
            }
        }
        else if(gameObject.tag == "Player")
        {
            if(collision.gameObject.tag == "EnemiesBullet")
            {
                TakeDamages(collision.gameObject.GetComponent<Bullet>().damages);
                collision.gameObject.SetActive(false);
                Debug.Log("contact EnemyBullet");
            }
        }
    }
}
