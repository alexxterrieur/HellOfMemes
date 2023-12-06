using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LifeManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    public int life;
    public Image healthBar;

    public int score;
    public ScoreManager scoreManager;
    public EnemiesSpawner enemiesSpawner;
    public AudioSourceManager audioSourceScript;
    private bool isInvincible = true;
    
    Animator animator;
    public VideoSwitch videoSwitch;

    private void Start()
    {
        //healthBar = GameObject.FindWithTag("HealthBar").GetComponent<Image>();
        scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
        enemiesSpawner = GameObject.Find("EnemiesSpawner").GetComponent <EnemiesSpawner>();
        

        StartCoroutine(EnableInvincibility()); //ennemis invincible le temps quil ne tirent pas quand ils spawnent
    }

    IEnumerator EnableInvincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(2f);
        isInvincible = false;
        if(gameObject.name == "Player")
        {
            animator = gameObject.GetComponent<Animator>();
            animator.SetBool("isInvulnerable", false);
        }
        
    }

    public void TakeDamages(int damages)
    {
        if (isInvincible) return;

        life -= damages;

        if (gameObject.name == "Player")
        {
            StartCoroutine(EnableInvincibility());
            animator = gameObject.GetComponent<Animator>();
            animator.SetBool("isInvulnerable", true);
        }

        if(gameObject.tag == "Boss")
        {
            healthBar.fillAmount = life / 100f;
        }
    }

    private void Update()
    {
        Die();
    }

    public void Die()
    {
        if (life <= 0)
        {
            if (gameObject.name != "Player")
            {
                scoreManager.playerScore += score;
                enemiesSpawner.enemiesAlive.Remove(gameObject);
                Destroy(gameObject); //Desac et pull les enemies

            }
            else
            {
                //stop le temps/ video/ son de hit + activer menu gameOver/ son de mort
                Time.timeScale = 0f;
                videoSwitch = GameObject.Find("BackgroundVideo").GetComponent<VideoSwitch>();
                GameObject bossActive = GameObject.FindWithTag("Boss");
                if (bossActive != null)
                {
                    bossActive.SetActive(false);
                }
                videoSwitch.StopVideo();
                audioSourceScript.audioSourceHit.Stop();
                //audioSourceScript.PlayerDeathSound();
                gameOverPanel.SetActive(true);
                GameOverManager gameOverManager = GameObject.Find("GameOverManager").GetComponent<GameOverManager>();
                gameOverManager.DisplayScores();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Enemy" || gameObject.tag == "Boss")
        {
            if (collision.gameObject.tag == "PlayerBullet")
            {
                TakeDamages(collision.gameObject.GetComponent<Bullet>().damages);
                collision.gameObject.SetActive(false);
            }
        }
        else if (gameObject.tag == "Player")
        {
            if (collision.gameObject.tag == "EnemiesBullet")
            {
                audioSourceScript.PlayerHitSfx();
                TakeDamages(collision.gameObject.GetComponent<Bullet>().damages);
                collision.gameObject.SetActive(false);
            }
        }
    }
}
