using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CarMovement : MonoBehaviour
{
    // Reference to the car's Rigidbody and Camera components
    public Rigidbody carRigidbody;
    public float speed = 50f;
    public float currentSpeed = 0f;
    public float turnSpeed = 50f;
    public float maxSpeed = 20f;

    
    // Reference to the CinemachineFreeLook component
    public CinemachineVirtualCamera cinemachineCamera;

    private void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
        carRigidbody.centerOfMass = new Vector3(0, -0.5f, 0);
    }
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MoveCar();
    }

    void MoveCar()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // Apply forward/backward force
        Vector3 force = transform.forward * moveInput * speed;
        carRigidbody.AddForce(force, ForceMode.Acceleration);

        // Turning (only when moving)
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            float turnMultiplier = moveInput > 0 ? 1f : -1f;
            Vector3 turn = transform.up * turnInput * turnSpeed * Time.deltaTime * turnMultiplier;
            carRigidbody.MoveRotation(carRigidbody.rotation * Quaternion.Euler(turn));
        }

        // Drifting logic
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 driftForce = -transform.right * turnInput * speed * 0.5f;
            carRigidbody.AddForce(driftForce, ForceMode.Acceleration);

            cinemachineCamera.m_Lens.FieldOfView = Mathf.Lerp(cinemachineCamera.m_Lens.FieldOfView, 75, Time.deltaTime * 2);
        }
        else
        {
            cinemachineCamera.m_Lens.FieldOfView = Mathf.Lerp(cinemachineCamera.m_Lens.FieldOfView, 60, Time.deltaTime * 2);
        }

        // Optional: smooth FOV for forward/reverse
        if (Input.GetKey(KeyCode.W)) {
            cinemachineCamera.m_Lens.FieldOfView = Mathf.Lerp(cinemachineCamera.m_Lens.FieldOfView, 70, Time.deltaTime * 2);
        }
        else if (Input.GetKey(KeyCode.S)) {
            cinemachineCamera.m_Lens.FieldOfView = Mathf.Lerp(cinemachineCamera.m_Lens.FieldOfView, 50, Time.deltaTime * 2);
        }
    }

}
