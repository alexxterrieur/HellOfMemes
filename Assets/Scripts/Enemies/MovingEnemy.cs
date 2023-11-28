using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public bool moveOnX;
    public bool moveOnY;

    private float initX, endX;
    private float initY, endY;

    Vector3 moveDirection;
    void Start()
    {
        initX = transform.position.x;
        initY = transform.position.y;

        endX = transform.position.x + 5;
        endX = transform.position.y + 5;

        moveDirection = new Vector3();
    }

    void Update()
    {
        if(moveOnX)
        {
            if(transform.position.x < endX)
            {
                
            }
            else
            {

            }
        }
        else if(moveOnY)
        {

        }
    }
}
