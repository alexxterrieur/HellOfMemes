using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 movementInput;
    private Vector2 fireDirection;

    [SerializeField] float speed;

    PlayerShoot playerShoot;
    [SerializeField] private GameObject pausePanel;
    VideoSwitch videoSwitch;

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

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    private void OnFire(InputValue inputValue)
    {
        fireDirection = inputValue.Get<Vector2>();
        playerShoot.Shoot(fireDirection);
    }

    private void OnEchap(InputValue inputValue)
    {
        Time.timeScale = 0f;
        videoSwitch.StopVideo();
        pausePanel.SetActive(true);
    }
}
