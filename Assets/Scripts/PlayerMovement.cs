using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float turnForce = 1.5f;
    [SerializeField] float forwardThrust = 3f;
    [SerializeField] float maxSpeed = 7f;
    Rigidbody2D _body;

    [SerializeField] GameObject left, right, forward, back;
    [SerializeField] AudioSource audio;

    bool cutscene = false;

    Vector3 startPosition;
   public bool getInElevator = false;

    private void Awake()
    {
        _body = gameObject.GetComponent<Rigidbody2D>();
        EventBroker.ExitCutscene += ExitCutscene;
        EventBroker.EnterCutscene += OnCutscene;
        _body.constraints = RigidbodyConstraints2D.FreezeAll;
        startPosition = new Vector3(100, 100, 0);
       
    }
    private void Start()
    {
        AirOff();
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
                if (Input.GetAxis("Horizontal") > 0f)
                {
                    Debug.Log("Turn Left");
                    left.SetActive(true);
                }
                else{
                    right.SetActive(true);
                }
                _body.AddTorque(-Input.GetAxis("Horizontal") * turnForce);
            }

            //Applies input relative directional force
            if (Input.GetButton("Vertical"))
            {
                if (Input.GetAxis("Vertical") > 0f)
                {
                    forward.SetActive(true);
                    if (!audio.isPlaying) {
                        audio.Play();
                    }
                }
                else
                {
                    back.SetActive(true);
                    if (!audio.isPlaying) {
                        audio.Play();
                    }
                }
                _body.AddRelativeForce(Vector2.right * forwardThrust * Input.GetAxis("Vertical"));
                //Enforces Max Speed
                _body.velocity = Vector2.ClampMagnitude(_body.velocity, maxSpeed);
            }
            AirOff();
        }
        if (getInElevator)
        { if (startPosition == new Vector3(100, 100, 0)) 
            {
                startPosition = transform.position;
            }
            if (transform.position.x >= 0.1f || transform.position.y >= 0.1f || transform.position.x <= -0.1f || transform.position.y <= -0.1f)
            {
                Debug.Log("Get to the choppa");
                transform.position = Vector3.zero;
                _body.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            else
            {
                _body.SetRotation(0);
                getInElevator = false;
                startPosition = new Vector3(100, 100, 0);
            }
        }
            

    }

    void AirOff()
    {
        left.SetActive(false);
        right.SetActive(false);
        forward.SetActive(false);
        back.SetActive(false);
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
