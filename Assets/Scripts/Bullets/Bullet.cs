using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;

    public int damages;

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }

    private void Start()
    {
        moveSpeed = 5f;
        damages = 1;
    }

    private void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<LifeManager>().TakeDamages(damages);
                gameObject.SetActive(false);                
            }
        }
    }
}
