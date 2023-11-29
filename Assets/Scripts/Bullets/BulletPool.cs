using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;
    [SerializeField] Transform bulletsParent;

    public List<GameObject> enemiesBulletPrefabs;
    private List<GameObject> enemiesBullets;
    private bool notEnoughEnemiesBullets = true;

    [SerializeField] GameObject playerBullet;
    private List<GameObject> playerBullets;
    private bool notEnoughPlayerBullets = true;



    private void Awake()
    {
        bulletPoolInstance = this;
    }
    
    private void Start()
    {
        enemiesBullets = new List<GameObject>();
        playerBullets = new List<GameObject>();
    }

    public GameObject GetEnnemiesBullet()
    {
        if(enemiesBullets.Count > 0)
        {
            for(int i = 0; i < enemiesBullets.Count; i++)
            {
                if (!enemiesBullets[i].activeInHierarchy)
                {
                    return enemiesBullets[i];
                }
            }
        }
        if(notEnoughEnemiesBullets)
        {
            for(int i = 0; i < enemiesBulletPrefabs.Count; i++)
            {
                GameObject bulletPrefab = enemiesBulletPrefabs[Random.Range(0, enemiesBulletPrefabs.Count)];

                GameObject newBullet = Instantiate(bulletPrefab);
                newBullet.transform.parent = bulletsParent;
                newBullet.SetActive(false);
                enemiesBullets.Add(newBullet);
                return newBullet;
            }
            
        }

        return null;        
    }

    public GameObject GetPlayerBullet()
    {
        if(playerBullets.Count > 0)
        {
            for(int i = 0; i < playerBullets.Count; i++)
            {
                if (!playerBullets[i].activeInHierarchy)
                {
                    return playerBullets[i];
                }
            }
        }
        if(notEnoughPlayerBullets)
        {
            GameObject newBullet = Instantiate(playerBullet);
            newBullet.transform.parent = bulletsParent;
            newBullet.SetActive(false);
            playerBullets.Add(newBullet);
            return newBullet;
        }

        return null;
    }
}
