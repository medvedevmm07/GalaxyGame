using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed = 0.1f;
    public int damage = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y - speed, 0);
        bool check = ScreenHelpers.ObjectNah(newPos);
        if (!check) {
            Destroy(gameObject);
        } else {
            transform.position = newPos;
        }
    }
}
