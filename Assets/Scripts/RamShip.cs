using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamShip : MonoBehaviour
{
    public MovingDirections direction;
    public SpriteRenderer shipRenderer;
    public float halfSide = 0.0f;
    public int health = 60;
    private float speed = 0.1f;
    void Start()
    {
        halfSide = shipRenderer.sprite.bounds.size.y/2;
    }
    public void FixedUpdate()
    {
        switch(direction)
        {
            case MovingDirections.right:
                Vector3 newPosition = new Vector3(transform.position.x + speed, transform.position.y, 0);
                Vector3 checkPosition = new Vector3(transform.position.x + speed + halfSide, transform.position.y, 0);
                bool isOnScreen = ScreenHelpers.ObjectNah(checkPosition);
                if(isOnScreen==true)
                {
                    transform.position = newPosition;
                }
                else
                {
                    if(transform.position.y>0)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 180);
                        direction = MovingDirections.down;
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        direction = MovingDirections.up;
                    }
                }
                break;
            case MovingDirections.left:
                newPosition = new Vector3(transform.position.x - speed, transform.position.y, 0);
                checkPosition = new Vector3(transform.position.x - speed - halfSide, transform.position.y, 0);
                isOnScreen = ScreenHelpers.ObjectNah(checkPosition);
                if(isOnScreen==true)
                {
                    transform.position = newPosition;
                }
                else
                {
                    if(transform.position.y>0)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 180);
                        direction = MovingDirections.down;
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        direction = MovingDirections.up;
                    }
                }
                break;
            case MovingDirections.up:
                newPosition = new Vector3(transform.position.x, transform.position.y + speed, 0);
                checkPosition = new Vector3(transform.position.x, transform.position.y + speed + halfSide, 0);
                isOnScreen = ScreenHelpers.ObjectNah(checkPosition);
                if(isOnScreen==true)
                {
                    transform.position = newPosition;
                }
                else
                {
                    if(transform.position.x>0)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 90);
                        direction = MovingDirections.left;
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 270);
                        direction = MovingDirections.right;
                    }
                }
                break;
            case MovingDirections.down:
                newPosition = new Vector3(transform.position.x, transform.position.y - speed, 0);
                checkPosition = new Vector3(transform.position.x, transform.position.y - speed - halfSide, 0);
                isOnScreen = ScreenHelpers.ObjectNah(checkPosition);
                if(isOnScreen==true)
                {
                    transform.position = newPosition;
                }
                else
                {
                    if(transform.position.x>0)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 90);
                        direction = MovingDirections.left;
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 270);
                        direction = MovingDirections.right;
                    }
                }
                break;

        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject othObject = collider.gameObject;
        SpaceBullet bulletScript = othObject.GetComponent<SpaceBullet>();
        if(bulletScript != null){
            health = health - bulletScript.damage;
            if(health <= 0){
                Destroy(gameObject);
            }
            Destroy(othObject);
        }
    }
}
