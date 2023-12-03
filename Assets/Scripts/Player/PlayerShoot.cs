using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerShoot : MonoBehaviour
{
    public List<GameObject> shapeToDraw;

    public void Shoot1()
    {
        float angleStep = (25 - (-45)) / 3;
        float angle = -25;

        for (int i = 0; i < 3; i++)
        {
            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector2 bulletDir = (bulletMoveVector - transform.position).normalized;
            GameObject bullet = BulletPool.bulletPoolInstance.GetPlayerBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().SetMoveDirection(bulletDir);

            angle += angleStep;
        }
    }

    public void Shoot2()
    {
        foreach(GameObject point in shapeToDraw)
        {
            GameObject bullet = BulletPool.bulletPoolInstance.GetPlayerBullet();

            bullet.transform.position = point.transform.position;
            bullet.transform.rotation = point.transform.rotation;

            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().SetMoveDirection(Vector2.up);
        }
    }

}
