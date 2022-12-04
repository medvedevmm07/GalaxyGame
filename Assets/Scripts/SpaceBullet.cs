using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBullet : MonoBehaviour
{
    

    float speed = 0.3f;
    public int damage = 30;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y + speed, 0);
        bool check = ScreenHelpers.ObjectNah(newPos);
        if (!check) {
            Destroy(gameObject);
        } else {
            transform.position = newPos;
        }


    }
}
