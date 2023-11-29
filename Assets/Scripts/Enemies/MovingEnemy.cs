using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    private float initialX;
    private float initialY;

    public bool canMoveX = false;
    public bool canMoveY = false;

    public float moveDistance = 5f;
    public float moveSpeed = 1f;

    void Start()
    {
        initialX = transform.position.x;
        initialY = transform.position.y;
    }

    void Update()
    {
        if (canMoveX)
        {
            MoveInX();
        }
        else if (canMoveY)
        {
            MoveInY();
        }
    }

    void MoveInX()
    {
        float newX = initialX + moveDistance * Mathf.Sin(Time.time * moveSpeed);
        transform.position = new Vector2(newX, transform.position.y);
    }

    void MoveInY()
    {
        float newY = initialY + moveDistance * Mathf.Sin(Time.time * moveSpeed);
        transform.position = new Vector2(transform.position.x, newY);
    }
}
