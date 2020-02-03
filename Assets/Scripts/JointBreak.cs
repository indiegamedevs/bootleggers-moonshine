using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointBreak : MonoBehaviour
{
    private void OnJointBreak2D(Joint2D joint)
    {
        GameManager.instance.PlacedPiece();
        joint.connectedBody.GetComponent<Collider2D>().enabled = false;
        joint.connectedBody.AddForce(Vector2.up * 10f, ForceMode2D.Force);
        joint.connectedBody = null;
    }
}
