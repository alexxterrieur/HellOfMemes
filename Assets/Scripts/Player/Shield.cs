using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DisableShield());
    }

    IEnumerator DisableShield()
    {        
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemiesBullet")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
