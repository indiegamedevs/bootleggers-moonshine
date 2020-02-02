using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    [SerializeField] GrabbedObject objectInField;
    [SerializeField] GrabbedObject grabbedObject;

    GameObject goalTrigger;

    private void Start()
    {
        
    }


    private void Update()
    {
        if(Input.GetButtonDown("Grab"))
        {
            Grab();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<GrabbedObject>() != null)
        {
            objectInField = collision.gameObject.GetComponent<GrabbedObject>();
        }
        Debug.Log(collision.gameObject.tag);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<GrabbedObject>() != null && objectInField != null)
        {
            objectInField = null;
        }
    }

    public void Grab()
    {
        if (grabbedObject == null)
        {
            if (objectInField != null)
            {
                grabbedObject = objectInField;
                grabbedObject.OnGrab(transform);             
            }
        }
        else
        {
            grabbedObject.OnRelease();
            grabbedObject = null;
        }
    }
}
