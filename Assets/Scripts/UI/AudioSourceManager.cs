using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private AudioClip PlayerShot, playerHit, playerDeath, GetShield;

    public void PlayerShotSfx()
    {
        audioSource.clip = PlayerShot;
        audioSource.Play();
    }

    public void PlayerHitSfx()
    {
        audioSource.clip = playerHit;
        audioSource.Play();
    }

    public void PlayerDeathSound()
    {
        audioSource.clip = playerDeath;
        audioSource.Play();
    }

    public void GetShieldSfx()
    {
        audioSource.clip = GetShield;
        audioSource.Play();
    }
}
