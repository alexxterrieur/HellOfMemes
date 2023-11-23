using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patern2 : MonoBehaviour
{
    private float angle;
    private Vector2 bulletDir;
    public float fireRate;

    private void Start()
    {
        InvokeRepeating("Fire", 0f, fireRate);
    }

    private void Fire()
    {
        for (int i = 0; i <= 1; i++)
        {
            float bulletDirX = transform.position.x + Mathf.Sin(((angle + 180 * i) * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos(((angle + 180 * i) * Mathf.PI) / 180f);
            
            Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);  //NEW VECTOR
            Vector2 bulletDir = (bulletMoveVector - transform.position).normalized;

            GameObject bullet = BulletPool.bulletPoolInstance.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().SetMoveDirection(bulletDir);
        }

        angle += 10;

        if(angle >= 360)
        {
            angle = 0;
        }
    }
}
