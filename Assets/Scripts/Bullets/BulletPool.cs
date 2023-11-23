using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;

    [SerializeField] GameObject pooledBullet;
    private bool notEnoughBullets = true;
    private List<GameObject> bullets;
    [SerializeField] Transform bulletsParent;

    private void Awake()
    {
        bulletPoolInstance = this;
    }

    private void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if(bullets.Count > 0)
        {
            for(int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }
        if(notEnoughBullets)
        {
            GameObject newBullet = Instantiate(pooledBullet);
            newBullet.transform.parent = bulletsParent;
            newBullet.SetActive(false);
            bullets.Add(newBullet);
            return newBullet;
        }

        return null;        
    }
}
