using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patern3 : MonoBehaviour
{
    public List<Transform> shapeToDraw;
    public float fireRate;

    private void Start()
    {
        InvokeRepeating("Fire", 0f, fireRate);
    }

    private void Fire()
    {
        foreach (Transform point in shapeToDraw)
        {
            GameObject bullet = BulletPool.bulletPoolInstance.GetEnnemiesBullet();

            bullet.transform.position = point.position;
            bullet.transform.rotation = point.rotation;

            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().SetMoveDirection(Vector2.down);
        }
    }
}
