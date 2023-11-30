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
    public float time = 15;
    public float enableShieldTimer = 15f;
    public bool canActiveShield;
    ///

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

        if (time >= enableShieldTimer)
        {
            canActiveShield = true;
        }

        time += Time.deltaTime;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    private void OnFire(InputValue inputValue)
    {
        playerShoot.Shoot();
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
            time = 0;
        }        
    }
}
