using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 movementInput;

    [SerializeField] float speed;

    PlayerShoot playerShoot;
    [SerializeField] private GameObject pausePanel;
    VideoSwitch videoSwitch;

    [SerializeField] private GameObject shield;
    [SerializeField] private Shield shieldScript;

    /// 
    public float enableShieldTimer = 0;
    public float shielTime = 0f;
    public bool canActiveShield;
    [SerializeField] GameObject shieldEnableMeme;
    private bool hasPlayCoroutine;
    ///

    public AudioSourceManager audioSourceScript;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerShoot = GetComponent<PlayerShoot>();
        videoSwitch = GameObject.Find("BackgroundVideo").GetComponent<VideoSwitch>();
    }

    private void FixedUpdate()
    {
        rb.velocity = movementInput * speed;
    }

    private void Update()
    {
        canActiveShield = false;

        if (shielTime <= enableShieldTimer)
        {
            canActiveShield = true;
            if(!hasPlayCoroutine)
            {
                StartCoroutine("GetThisManAShield");
                hasPlayCoroutine = true;
            }            
        }

        shielTime -= Time.deltaTime;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    private void OnFire(InputValue inputValue)
    {
        playerShoot.Shoot();
        audioSourceScript.PlayerShotSfx();
    }

    private void OnEchap(InputValue inputValue)
    {
        Time.timeScale = 0f;
        videoSwitch.StopVideo();
        pausePanel.SetActive(true);
    }

    private void OnSpace(InputValue inputValue)
    {
        if(canActiveShield)
        {
            shield.SetActive(true);
            shielTime = 15;
            hasPlayCoroutine = false;
        }        
    }


    public IEnumerator GetThisManAShield()
    {
        shieldEnableMeme.SetActive(true);
        audioSourceScript.GetShieldSfx();
        yield return new WaitForSeconds(0.6f);
        shieldEnableMeme.SetActive(false);        
    }
}
