using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackround : MonoBehaviour {

    SpriteRenderer _sprite;
    Rigidbody2D _body;
    float trackHeight;

    bool move = false;

	// Use this for initialization
	void Start ()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _body = GetComponent<Rigidbody2D>();
        _body.constraints = RigidbodyConstraints2D.FreezeAll;

        EventBroker.StartElevator += MoveElevator;
        EventBroker.StopElevator += StopElevator;

        trackHeight = _sprite.size.y *transform.localScale.y;     
	}

    private void OnDisable()
    {
        EventBroker.StartElevator -= MoveElevator;
        EventBroker.StopElevator -= StopElevator;
    }

    // Update is called once per frame
    void Update ()
    {
        if (transform.position.y > trackHeight)
        {
            RepositionBackground();
        }

        if (move)
        {
            transform.Translate(new Vector3(0, Time.deltaTime / 10 * GameManager.instance.gameSpeed));
        }
	}

     void MoveElevator()
    {
        move = true;
        _body.constraints = RigidbodyConstraints2D.None;
        Debug.Log("Scroll Called");
    }

   void StopElevator()
    {
        move = false;
        _body.constraints = RigidbodyConstraints2D.FreezeAll;
        
    }
    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(0, -trackHeight *2);
        transform.position = (Vector2)transform.position + groundOffset;
    }

}
