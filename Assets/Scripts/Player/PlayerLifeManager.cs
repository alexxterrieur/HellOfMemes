using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{
    public int life = 3;

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
