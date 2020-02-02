using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGrab : MonoBehaviour
{
    Transform _parent;
    // Start is called before the first frame update
    void Start()
    {
        _parent = transform.parent;
    }

    internal void OnGrab(Transform grabber)
    {
        Transform t = _parent.transform;
        t.SetParent(grabber);
        grabber.parent.position = new Vector3(gameObject.transform.position.x -1f,transform.position.y);
       grabber.parent.localEulerAngles = transform.localEulerAngles;
        Debug.Log("OnGrab Received");
    }

    internal void OnRelease()
    {
        transform.parent.transform.SetParent(null);
    }
}
