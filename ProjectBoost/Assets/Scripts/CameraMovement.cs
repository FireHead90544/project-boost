using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform rocket;
    private Vector3 offset;
    public static int cameraMode = 0;

    private Vector3 cameraPos;

    // Update is called once per frame
    void Start()
    {
        cameraPos = transform.position;
    }
    void Update()
    {
        SwitchCameraMode();
    }

    private void SwitchCameraMode()
    {
        if (cameraMode == 0)
        {
            Vector3 offset = new Vector3(0, 2.5f, -10);
            transform.position = rocket.position + offset;
        }

        else if (cameraMode == 1)
        {
            Vector3 offset = new Vector3(15, 4.5f, -15);
            transform.position = cameraPos; // rocket.position + offset; 
        }
    }
}
