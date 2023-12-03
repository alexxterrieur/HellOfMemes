using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{
    public AudioSource audioSourceShot, audioSourceHit, audioSourceDeath, audioSourceGetShield, audioSourceShield;

    public void PlayerShotSfx()
    {
        audioSourceShot.Play();
    }

    public void PlayerHitSfx()
    {
        audioSourceHit.Play();
    }

    public void PlayerDeathSound()
    {
        audioSourceDeath.Play();
    }

    public void GetShieldSfx()
    {
        audioSourceGetShield.Play();
    }

    public void ShieldSound()
    {
        audioSourceShield.Play();
    }
}
