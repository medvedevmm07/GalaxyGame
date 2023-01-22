using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shipamogus : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject bullet;
    public int health = 100;

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
        Vector3 newDPos = new Vector3(transform.position.x, transform.position.y - speed, 0);
        Vector3 newUPos = new Vector3(transform.position.x, transform.position.y + speed, 0);
        Vector3 checkLPos = new Vector3(newLPos.x - halfWidth, newLPos.y, 0);
        Vector3 checkRPos = new Vector3(newRPos.x + halfWidth, newRPos.y, 0);
        Vector3 checkDPos = new Vector3(newLPos.x, newLPos.y - halfWidth, 0);
        Vector3 checkUPos = new Vector3(newRPos.x, newRPos.y + halfWidth, 0);

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
        if (Input.GetKey(KeyCode.DownArrow)) {
            bool check = ScreenHelpers.ObjectNah(checkDPos);
            if (check) {
                transform.position = newDPos; 
            }            
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            bool check = ScreenHelpers.ObjectNah(checkUPos);
            if (check) {
                transform.position = newUPos; 
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
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
                SceneManager.LoadSceneAsync(SceneIDS.looseSceneID);
                Destroy(gameObject);
            }
        }
        else
        {
            RamShip shipScript = otherObject.GetComponent<RamShip>();
            if(shipScript!=null)
            {
                Destroy(otherObject);
                SceneManager.LoadSceneAsync(SceneIDS.looseSceneID);
                Destroy(gameObject);
            }
        }
    }
}
