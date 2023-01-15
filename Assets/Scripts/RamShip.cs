using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamShip : MonoBehaviour
{
    public MovingDirections direction;
    private float speed = 0.1f;
    void Start()
    {
        
    }
    public void FixedUpdate()
    {
        switch(direction)
        {
            case MovingDirections.right:
                Vector3 newPosition = new Vector3(transform.position.x + speed, transform.position.y, 0);
                bool isOnScreen = ScreenHelpers.ObjectNah(newPosition);
                if(isOnScreen)
                {
                    transform.position = newPosition;
                }
                else
                {
                    direction = MovingDirections.down;
                }
                break;
            case MovingDirections.left:
                //Vector3 newPosition = new Vector3(transform.position.x - speed, transform.position.y, 0);
                break;
            case MovingDirections.up:
                //Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + speed, 0);
                break;
            case MovingDirections.down:
                //Vector3 newPosition = new Vector3(transform.position.x, transform.position.y - speed, 0);
                break;

        }
    }
}
