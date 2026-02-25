using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);

        float screenHeight = Camera.main.orthographicSize;
        float screenWidth = screenHeight * Camera.main.aspect;

        screenBounds = new Vector2(screenWidth, screenHeight);
    }

    void Update()
    {
        if (transform.position.x < -screenBounds.x - 1)
        {
            Destroy(gameObject);
        }
    }
}
