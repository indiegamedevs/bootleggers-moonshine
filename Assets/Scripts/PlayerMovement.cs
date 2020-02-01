using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float turnForce = 1.5f;
    [SerializeField] float forwardThrust = 3f;
    [SerializeField] float maxSpeed = 7f;
    Rigidbody2D _body;

    

    // Start is called before the first frame update
    void Start()
    {
        _body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetButton("Horizontal"))
        {
            _body.AddTorque(-Input.GetAxis("Horizontal") * turnForce);
        }

        if (Input.GetButton("Vertical"))
        {
            _body.AddRelativeForce(Vector2.right * forwardThrust * Input.GetAxis("Vertical"));
            //Vector2 testForce = new Vector2(Vector2.right * forwardThrust * Input.GetAxis("Vertical"));
        }
    }
}
