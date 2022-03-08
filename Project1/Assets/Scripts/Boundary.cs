using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private float minX, maxX, minY, maxY, objectW, objectH;

    void Start()
    {
        // If you want the min max values to update if the resolution changes 
        // set them in update else set them in Start

/*        objectH = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;*/
    }

    void Update()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;
        objectW = transform.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
        // Get current position
        Vector3 pos = transform.position;

        // Horizontal contraint
        if (pos.x < minX + objectW) pos.x = minX+objectW;
        if (pos.x > maxX - objectW) pos.x = maxX-objectW;

        // vertical contraint
/*        if (pos.y < minY + objectW) pos.y = minY +objectH;
        if (pos.y > maxY - objectW) pos.y = maxY - objectH;*/

        // Update position
        transform.position = pos;
    }
}
