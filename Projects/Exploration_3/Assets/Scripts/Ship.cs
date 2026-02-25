using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("is_hit");
        GameObject e = Instantiate(explosion) as GameObject;
        e.transform.position = transform.position;
        Destroy(other.gameObject);
        this.gameObject.SetActive(false);
    }

}
