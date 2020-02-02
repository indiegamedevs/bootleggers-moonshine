using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSpin : MonoBehaviour
{
    [SerializeField] float rotDirection = 10f;
    bool isSpinning = false;

    // Start is called before the first frame update
    void Start()
    {
        EventBroker.StartElevator += StartSpin;
        EventBroker.StopElevator += StopSpin;
    }

    private void OnDisable()
    {
        EventBroker.StartElevator -= StartSpin;
        EventBroker.StopElevator -= StopSpin;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpinning)
        { 
            transform.Rotate(Vector3.forward * GameManager.instance.gameSpeed *20f * rotDirection * Time.deltaTime);
        }
    }

    void StartSpin()
    {
        isSpinning = true;

    }

    void StopSpin()
    {
        isSpinning = false;
    }
}
