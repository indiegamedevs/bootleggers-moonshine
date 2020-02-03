using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceLooper : MonoBehaviour
{
    bool isWrappingX = false;
    bool isWrappingY = false;

    Vector3 viewportPosition;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
       
    }

    // Update is called once per frame
    void Update()
    {
        ScreenWrap();
    }

    void ScreenWrap()
    {
        viewportPosition = cam.WorldToViewportPoint(transform.position);
        var newPosition = transform.position;

        if (!isWrappingX)
        {
            if ((viewportPosition.x > 1 || viewportPosition.x < 0))
            {
                newPosition.x = -newPosition.x;

                isWrappingX = true;
            }
            else
            {
                isWrappingX = false;
            }
        }

        if (!isWrappingY)
        {
            if ((viewportPosition.y > 1 || viewportPosition.y < 0))
            {
                newPosition.y = -newPosition.y;

                isWrappingY = true;
            }
            else
            {
                isWrappingY = false;
            }
        }

        transform.position = newPosition;
    }
}
