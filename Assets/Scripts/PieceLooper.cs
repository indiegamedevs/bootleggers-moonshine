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
        if (isWrappingX || isWrappingY)

        {
            return;
        }
        viewportPosition = cam.WorldToViewportPoint(transform.position);
        var newPosition = transform.position;

        if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            newPosition.x = -newPosition.x;

            isWrappingX = true;
        }

        if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
        {
            newPosition.y = -newPosition.y;

            isWrappingY = true;
        }

        transform.position = newPosition;
    }
}
