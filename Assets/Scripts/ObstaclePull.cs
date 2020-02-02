using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePull : MonoBehaviour
{
    [SerializeField] ObstacleGrab objectInField;
    [SerializeField] ObstacleGrab grabbedObject;

    GameObject goalTrigger;

    private void Update()
    {
        if (Input.GetButtonDown("Grab"))
        {
            Grab();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ObstacleGrab>() != null)
        {
            objectInField = collision.gameObject.GetComponent<ObstacleGrab>();
        }
        Debug.Log(collision.gameObject.tag);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ObstacleGrab>() != null && objectInField != null)
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
                transform.parent.GetComponent<Rigidbody2D>().simulated = false;
                grabbedObject.OnGrab(transform);
                transform.parent.GetComponent<Rigidbody2D>().simulated = true;
            }
        }
        else
        {
            grabbedObject.OnRelease();
            grabbedObject = null;
        }
    }
}
