using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    private Vector3 offset;
    private bool dragging = false;

    public static int socketCount;

    public string correctSocket;
    public string connectedSocket;

    public Sprite pickedUpImage;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        dragging = true;
        spriteRenderer.sprite = pickedUpImage;

        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        if (dragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos + offset;
        }
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Socket"))
        {
            Socket socket = other.GetComponent<Socket>();

            if (!socket.occupied)
            {
                transform.position = other.transform.position;

                connectedSocket = other.name;
                socket.occupied = true;

                dragging = false;
                enabled = false;

                FindObjectOfType<PuzzleManager>().CableConnected();
            }
        }
    }
    //void CheckPuzzle()
    //{
    //    Cable[] cables = FindObjectsOfType<Cable>();

    //    bool allCorrect = true;

    //    foreach (Cable c in cables)
    //    {
    //        if (c.connectedSocket != c.correctSocket)
    //        {
    //            allCorrect = false;
    //            break;
    //        }
    //    }

    //    if (allCorrect)
    //    {
    //        Debug.Log("Show CHECKMARK");
    //        FindObjectOfType<PuzzleManager>().ShowCheckmark();
    //        // shoudld exit Application.Quit();
    //    }
    //    else
    //    {
    //        Debug.Log("Show X");
    //        FindObjectOfType<PuzzleManager>().ShowX();
    //        // shoudld exit Application.Quit();

    //    }
    //}
}