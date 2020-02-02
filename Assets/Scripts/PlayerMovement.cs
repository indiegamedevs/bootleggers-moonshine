using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float turnForce = 1.5f;
    [SerializeField] float forwardThrust = 3f;
    [SerializeField] float maxSpeed = 7f;
    Rigidbody2D _body;

    bool cutscene = false;
   public bool getInElevator = false;

    private void Awake()
    {
        _body = gameObject.GetComponent<Rigidbody2D>();
        EventBroker.ExitCutscene += ExitCutscene;
        EventBroker.EnterCutscene += OnCutscene;
        _body.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnDisable()
    {
        EventBroker.ExitCutscene -= ExitCutscene;
        EventBroker.EnterCutscene -= OnCutscene;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!cutscene)
        {
            //Applies inverse Torque to rotate player
            if (Input.GetButton("Horizontal"))
            {
                _body.AddTorque(-Input.GetAxis("Horizontal") * turnForce);
            }

            //Applies input relative directional force
            if (Input.GetButton("Vertical"))
            {
                _body.AddRelativeForce(Vector2.right * forwardThrust * Input.GetAxis("Vertical"));
            }
        }
        if (getInElevator)
        {
            if (transform.position.x >= 0.1f || transform.position.y >= 0.1f || transform.position.x <= -0.1f || transform.position.y <= -0.1f)
            {
                Debug.Log("Get to the choppa");
                _body.MovePosition(Vector2.zero);
            }
            else
            {
                _body.SetRotation(0);
                getInElevator = false;
            }
        }
            //Enforces Max Speed
            _body.velocity = Vector2.ClampMagnitude(_body.velocity, maxSpeed);

    }

    public void GetIn()
    {
        getInElevator = true;
    }

    void OnCutscene()
    {
        cutscene = true;
        _body.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    void ExitCutscene()
    {
        cutscene = false;
        _body.constraints = RigidbodyConstraints2D.None;
    }
}
