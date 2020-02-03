using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertTrigger : MonoBehaviour
{

    public BrokenElevator0 elevatorManager;
    public GameObject currentElevator;

    public int slotNumber;
    int correctNumber = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slot"))
        {
                correctNumber++;
            GameManager.instance.PlacedPiece();
            if (correctNumber < slotNumber)
            {
                elevatorManager.pieces.Add(gameObject.transform.parent.gameObject.transform.parent.gameObject);
                Destroy(this);
            }
            else
            { 
                Complete();
            }

        }
    }

    private void Complete()
    {
        elevatorManager.Repair(currentElevator);
        gameObject.transform.parent.transform.parent.gameObject.SetActive(false);
    }
}
