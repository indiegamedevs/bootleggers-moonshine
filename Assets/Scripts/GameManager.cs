using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerGrab playerGrab;

    // Start is called before the first frame update
    void Start()
    {
        playerGrab = FindObjectOfType<PlayerGrab>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlacedPiece()
    {
        playerGrab.Grab();
        Debug.Log("PlacedPiece");
    }
}
