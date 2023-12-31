using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patern1 : MonoBehaviour
{
    private Vector2 bulletDir;
    [SerializeField] private int bulletAmount = 10;
    [SerializeField] private float startAngle = 0f, endAngle = 360f;

    public float fireRate;

    private void Start()
    {
        new WaitForSeconds(15f);
        InvokeRepeating("Fire", 1f, fireRate);
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletAmount;
        float angle = startAngle;

        for(int i = 0; i < bulletAmount; i++)
        {
            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);
            bulletDir = (bulletMoveVector - transform.position).normalized;

            GameObject bullet = BulletPool.bulletPoolInstance.GetEnnemiesBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().SetMoveDirection(bulletDir);

            angle += angleStep;
        }
    }
}
