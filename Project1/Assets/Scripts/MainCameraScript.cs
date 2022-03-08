using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{

    public GameObject player;
    public Camera cameraView;
    public float offset = 2;

    float temp;

    private float minX, maxX, minY, maxY, objectW, objectH;
    private void Start()
    {
        temp = transform.position.x + offset;
    }
    void FixedUpdate()
    {

        if (player.transform.position.x> temp)
        {
            transform.position = new Vector3(player.transform.position.x-offset, transform.position.y, -10);
            temp = transform.position.x+offset;
        }

    }


}
