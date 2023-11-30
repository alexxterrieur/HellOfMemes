using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public void Shoot()
    {
        float angleStep = (15 - (-15)) / 3;
        float angle = -10;

        for (int i = 0; i < 3; i++)
        {
            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector2 bulletDir = (bulletMoveVector - transform.position).normalized;
            GameObject bullet = BulletPool.bulletPoolInstance.GetPlayerBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, bulletDir);
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().SetMoveDirection(bulletDir);

            angle += angleStep;
        }
    }
}
