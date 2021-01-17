using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {


    [SerializeField]float rcsThrust = 100f;
    [SerializeField]float mainThrust = 100f;
    Rigidbody rb;
	AudioSource thrustingSound;
    public Rocket playerScript;
    private CameraMovement camScript;
    private static int playerCamMode;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		thrustingSound = GetComponent<AudioSource>();
        playerScript = GetComponent<Rocket>();
        camScript = GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
        CameraMode();
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 collisionMax = new Vector3(20, 20, 20);
        if (collision.collider.tag == "Obstacle")
        {
            if ((Math.Abs(collision.impulse.x) > collisionMax.x) || (Math.Abs(collision.impulse.y) > collisionMax.y) || (Math.Abs(collision.impulse.z) > collisionMax.z))
            {
                Debug.Log("Crashed");
                playerScript.enabled = false;
                thrustingSound.Stop();
            }
            else
            {
                Debug.Log("Safe");
            }
        }
        else if (collision.collider.tag == "Land_Pad")
        {
            // Quaternion landRotation = new Quaternion(1.5f, 1.5f, 1.5f, 0);
            if ((Math.Abs(this.gameObject.transform.rotation.x) <= (collision.collider.transform.rotation.x + 0.01f)) && (Math.Abs(this.gameObject.transform.rotation.z) <= (collision.collider.transform.rotation.z + 0.01f)))
            {
                Debug.Log("Landed Successfully :)");
                playerScript.enabled = false;
                thrustingSound.Stop();
            }
            else
            {
                Debug.Log("Land Properly :(");
            }
        }
    }

    private void CameraMode()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            playerCamMode = CameraMovement.cameraMode;

            if (playerCamMode == 0)
            {
                CameraMovement.cameraMode = 1;
            }
            else if (playerCamMode == 1)
            {
                CameraMovement.cameraMode = 0;
            }
        }
    }

    private void Rotate()
    {
        rb.freezeRotation = true;
        
        float rotationSpeed = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {  
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }

        rb.freezeRotation = false;
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            

            if (!thrustingSound.isPlaying)
            {
                thrustingSound.Play();
            }
        }
        else
        {
            thrustingSound.Stop();
        }
    }
}
