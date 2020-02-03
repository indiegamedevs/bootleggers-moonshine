using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenElevator0 : MonoBehaviour
{
    public GameObject whole;
    public GameObject broken0;
    public GameObject broken1;
    public Transform socket;

    public List<GameObject> pieces = new List<GameObject>();
    public void Detatch(GameObject activate)
    {
        whole.SetActive(false);
        activate.SetActive(true);
    }

    public void Repair(GameObject activate)
    {
        foreach (GameObject obj in pieces)
        {
            pieces.Remove(obj);
            obj.SetActive(false);
        }
        whole.SetActive(true);
        activate.SetActive(false);
    }


}
