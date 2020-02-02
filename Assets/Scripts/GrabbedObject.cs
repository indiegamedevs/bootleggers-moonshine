using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbedObject : MonoBehaviour
{
    GameObject _parent, goalTrigger;

    // Start is called before the first frame update
    void Start()
    {
        _parent = transform.parent.gameObject;
        goalTrigger = transform.GetChild(0).gameObject;
        goalTrigger.SetActive(false);
    }

    public void OnGrab(Transform grabber)
    {      
        Transform t = _parent.transform;
        t.SetParent(grabber);
        t.localPosition = new Vector3(gameObject.transform.localPosition.x, 0);
        t.localEulerAngles = Vector3.zero;
        transform.SetParent(grabber);
        _parent.SetActive(false);
        goalTrigger.SetActive(true);
    }

    public void OnRelease()
    {
        goalTrigger.SetActive(false);
        _parent.SetActive(true);
        transform.SetParent(_parent.transform);
        _parent.transform.localPosition = new Vector3(_parent.transform.localPosition.x + 1f, _parent.transform.localPosition.y);
        _parent.transform.SetParent(null);
    }
}
