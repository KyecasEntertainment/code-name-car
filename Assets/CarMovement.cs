using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Rigidbody carRigidbody;
    public Camera carCamera;
    public float speed = 10f;
    public float turnSpeed = 50f;
    public float maxSpeed = 20f;

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

        Vector3 forwardMovement = transform.forward * moveInput * speed * Time.deltaTime;
        Vector3 turnMovement = transform.up * turnInput * turnSpeed * Time.deltaTime;

        carRigidbody.MovePosition(carRigidbody.position + forwardMovement);
        carRigidbody.MoveRotation(carRigidbody.rotation * Quaternion.Euler(turnMovement));

        if (carRigidbody.velocity.magnitude > maxSpeed)
        {
            carCamera.fieldOfView = Mathf.Lerp(carCamera.fieldOfView, 60, Time.deltaTime * 2);
            carRigidbody.velocity = carRigidbody.velocity.normalized * maxSpeed;
        }
    }

}
