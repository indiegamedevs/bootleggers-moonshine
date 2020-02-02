using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointBreak : MonoBehaviour
{
    private void OnJointBreak2D(Joint2D joint)
    {
        GameManager.instance.PlacedPiece();
        joint.connectedBody.GetComponent<Rigidbody2D>().simulated = false;
        joint.connectedBody = null;
    }
}
