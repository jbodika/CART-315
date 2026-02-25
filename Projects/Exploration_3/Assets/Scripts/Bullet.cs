using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    public GameObject bulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -screenBounds.x - 1)
        {
            Destroy(this.gameObject);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }

    public void shootBullet()
    {
        GameObject b = Instatiate(bulletPrefab) as GameObject;
    }
}
