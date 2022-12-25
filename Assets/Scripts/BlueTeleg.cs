using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTeleg : MonoBehaviour
{
    public int health = 60;
    public GameObject bulletOriginal;

    private SpriteRenderer spriteRenderer;
    private float halfWidth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        halfWidth = spriteRenderer.bounds.size.x / 2;
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

    public void Shoot() {
        GameObject clone = Instantiate(bulletOriginal);
        clone.transform.position = transform.position;
        print("Привет");
    }
}
