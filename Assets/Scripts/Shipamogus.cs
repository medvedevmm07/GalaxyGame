using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipamogus : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject bullet;
    public int health = 50;

    private float speed = 0.1f;

    private float halfWidth;

    void Start()
    {
        halfWidth = spriteRenderer.bounds.size.x / 2;
    }

    void Update()
    {
        Vector3 newRPos = new Vector3(transform.position.x + speed, transform.position.y, 0);
        Vector3 newLPos = new Vector3(transform.position.x - speed, transform.position.y, 0);
        Vector3 checkLPos = new Vector3(newLPos.x - halfWidth, newLPos.y, 0);
        Vector3 checkRPos = new Vector3(newRPos.x + halfWidth, newRPos.y, 0);

        if (Input.GetKey(KeyCode.RightArrow)) {
            bool check = ScreenHelpers.ObjectNah(checkRPos);
            if (check) {
                transform.position = newRPos; 
            }            
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            bool check = ScreenHelpers.ObjectNah(checkLPos);
            if (check) {
                transform.position = newLPos; 
            }
        }

        if (Input.GetKey(KeyCode.Space)) {
            GameObject clone = Instantiate(bullet);
            clone.transform.position = transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider) {
        GameObject otherObject = otherCollider.gameObject;
        EnemyBullet bulletScript = otherObject.GetComponent<EnemyBullet>();
        if(bulletScript != null) {
            health -= bulletScript.damage;
            Destroy(otherObject);
            if(health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
