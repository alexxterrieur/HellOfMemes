using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public int life;
    public int score;
    
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
            Debug.Log("Player mort");

        }
    }
}
