using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaBounds : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckAreaBounds();
    }

    private void CheckAreaBounds()
    {
        // Handling The X-Axis
        if (transform.position.x >= 27.5f)
        {
            transform.position = new Vector3(27.5f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -15f)
        {
            transform.position = new Vector3(-15f, transform.position.y, transform.position.z);
        }

        // Handling The Y-Axis
        if (transform.position.y >= 16.5f)
        {
            transform.position = new Vector3(transform.position.x, 16.5f, transform.position.z);
        }
        /* No Need For Handling Botton Y-Axis As Collider Of Ground Will Handle It Automatically */

        // Handling The Z-Axis
        if (transform.position.z >= 0 || transform.position.z <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
}
