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
    public GameObject mainPausePanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private PauseManager pauseManager;
    VideoSwitch videoSwitch;

    [SerializeField] private GameObject shield;
    [SerializeField] private Shield shieldScript;

    /// 
    public float shielTime = 0f;
    public bool canActiveShield;
    [SerializeField] GameObject shieldEnableMeme;
    private bool hasPlayCoroutine;
    ///

    public AudioSourceManager audioSourceScript;

    private void Awake()
    {
        Cursor.visible = false;

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
        //shield
        canActiveShield = false;

        if (shielTime <= 0)
        {
            shielTime = 0;
            canActiveShield = true;
            if(!hasPlayCoroutine)
            {
                StartCoroutine("GetThisManAShield");
                hasPlayCoroutine = true;
            }            
        }

        shielTime -= Time.deltaTime;  
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }

    public void OnFire1(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && !pausePanel.activeInHierarchy)
        {
            playerShoot.Shoot1();
            audioSourceScript.PlayerShotSfx();
        }
    }

    public void OnFire2(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && !pausePanel.activeInHierarchy)
        {
            playerShoot.Shoot2();
            audioSourceScript.PlayerShotSfx();
        }
    }

    public void OnEchap(InputAction.CallbackContext ctx)
    {
        Time.timeScale = 0f;
        videoSwitch.StopVideo();

        //activer menu pause
        if(ctx.canceled && !pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(true);
        }
        else
        {
            //desac menu pause
            if(ctx.canceled && !pauseManager.controlsPanel.activeInHierarchy && !pauseManager.warningPanel.activeInHierarchy)
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
                videoSwitch.ResumeVideo();
            }
            //desac controls panel
            else if(ctx.canceled && pauseManager.controlsPanel.activeInHierarchy)
            {       
                mainPausePanel.SetActive(true);
                pauseManager.controlsPanel.SetActive(false);
            }   
            //desac warning
            else if(ctx.canceled && pauseManager.warningPanel.activeInHierarchy)
            {
                mainPausePanel.SetActive(true);
                pauseManager.warningPanel.SetActive(false);
            }
            
        }        
    }

    public void OnSpace(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && canActiveShield && !pausePanel.activeInHierarchy)
        {
            shield.SetActive(true);
            audioSourceScript.ShieldSound();
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
