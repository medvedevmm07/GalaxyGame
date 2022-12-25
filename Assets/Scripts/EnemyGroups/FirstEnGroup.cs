using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnGroup : GroupBase
{
    
    public BlueTeleg ship1;
    public BlueTeleg ship2;
    public BlueTeleg ship3;
    public BlueTeleg ship4;
    public BlueTeleg ship5;

    private int direction = -1;
    private float speed = 0.1f;
    private List<BlueTeleg> ships = new List<BlueTeleg>(); 
    private System.Random generator = new System.Random();

    void Start()
    {
        ships.Add(ship1);
        ships.Add(ship2);
        ships.Add(ship3);
        ships.Add(ship4);
        ships.Add(ship5);

        InvokeRepeating("GroupShoot", 0.0f, 1.0f);
    }

    
    void Update()
    {
        ships.RemoveAll(item => item == null);
        
        if(ship1 == null 
        && ship2 == null 
        && ship3 == null 
        && ship4 == null 
        && ship5 == null) {
            isAlive = false;
            CancelInvoke("GroupShoot");
        }

        if(direction == -1) {
            float minX = GetLeftEdge();
            minX += speed * direction;
            if(minX <= -10) {
                direction *= -1;
            } else {
                transform.position = new Vector3(
                    transform.position.x - speed,
                    transform.position.y,
                    0
                );
            }
           
        } else {
            float maxX = GetRightEdge();
            maxX += speed * direction;
            if (maxX >= 10) {
                direction *= -1;
            } else {
                 transform.position = new Vector3(
                    transform.position.x + speed,
                    transform.position.y,
                    0
                );
            }
        }

    }

    float GetLeftEdge() {
        float minX = float.MaxValue;
        for(int i = 0; i < ships.Count; i++) {
            if(ships[i].transform.position.x < minX) {
                minX = ships[i].transform.position.x;
            }
        }
        return minX;
    }

    float GetRightEdge() {
        float maxX = float.MinValue;
        for(int i = 0; i < ships.Count; i++) {
            if(ships[i].transform.position.x > maxX) {
                maxX = ships[i].transform.position.x;
            }
        }
        return maxX;
    }

    void GroupShoot() {
        int randomIndex = generator.Next(0,ships.Count-1);
        ships[randomIndex].Shoot();
    }
}
