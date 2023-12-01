using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patern2 : MonoBehaviour
{
    private float angle;
    private Vector2 bulletDir;
    public float fireRate;
    public int branchNumber;

    private void Start()
    {
        InvokeRepeating("Fire", 1f, fireRate);
    }

    private void Fire()
    {
        for (int i = 0; i < branchNumber; i++)
        {
            float bulletDirX = transform.position.x + Mathf.Sin(((angle + (360 / branchNumber) * i) * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos(((angle + (360 / branchNumber) * i) * Mathf.PI) / 180f);
            
            Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);  //NEW VECTOR
            bulletDir = (bulletMoveVector - transform.position).normalized;

            GameObject bullet = BulletPool.bulletPoolInstance.GetEnnemiesBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().SetMoveDirection(bulletDir);
        }

        //passer de + a - pour changer le sens de rotation
        angle += 10;


        if (angle >= 360)
        {
            angle = 0;
        }
    }
}
