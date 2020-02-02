using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slot"))
        {
            GameManager.instance.PlacedPiece();
        }
    }
}
