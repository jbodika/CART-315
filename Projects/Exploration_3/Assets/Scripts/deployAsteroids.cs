using System.Collections;
using UnityEngine;

public class deployAsteroids : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab);

        float screenHeight = Camera.main.orthographicSize;
        float screenWidth = screenHeight * Camera.main.aspect;

        a.transform.position = new Vector2(
            screenWidth + 1,
            Random.Range(-screenHeight, screenHeight)
        );
    }


    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
       
    }
}

