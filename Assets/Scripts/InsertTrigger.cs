using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertTrigger : MonoBehaviour
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slot"))
        {
            gameManager.PlacedPiece();
        }
    }
}
