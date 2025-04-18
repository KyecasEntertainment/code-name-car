using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CarMovement : MonoBehaviour
{
    // Reference to the car's Rigidbody and Camera components
    public Rigidbody car_rigidbody;
    public float speed = 50f;
    public float current_speed = 0f;
    public float turn_speed = 50f;
    public float max_speed = 20f;

    public bool is_on_ground;

    public PlayerStatusScipt player_status;

    // Reference to the CinemachineFreeLook component
    public CinemachineVirtualCamera cinemachine_camera;

    private void Start()
    {
        car_rigidbody = GetComponent<Rigidbody>();
        car_rigidbody.centerOfMass = new Vector3(0, -0.5f, 0);
    }

    private void FixedUpdate()
    {
        MoveCar();
    }

    void MoveCar()
    {
        float move_input = Input.GetAxis("Vertical");
        float turn_input = Input.GetAxis("Horizontal");

        if (!is_on_ground || !player_status.has_gas)
        {
            return; // Prevent movement if not on ground
        }
        else
        {
            Vector3 force = transform.forward * move_input * speed;
            car_rigidbody.AddForce(force, ForceMode.Force);

            // Turning (only when moving)
            if (Mathf.Abs(move_input) > 0.1f)
            {
                float turn_multiplier = move_input > 0 ? 1f : -1f;
                Vector3 turn = transform.up * turn_input * turn_speed * Time.deltaTime * turn_multiplier;
                car_rigidbody.MoveRotation(car_rigidbody.rotation * Quaternion.Euler(turn));
            }

            // Drifting logic
            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 drift_force = -transform.right * turn_input * speed * 0.5f;
                car_rigidbody.AddForce(drift_force, ForceMode.Acceleration);

                cinemachine_camera.m_Lens.FieldOfView = Mathf.Lerp(cinemachine_camera.m_Lens.FieldOfView, 75, Time.deltaTime * 2);
            }
            else
            {
                cinemachine_camera.m_Lens.FieldOfView = Mathf.Lerp(cinemachine_camera.m_Lens.FieldOfView, 60, Time.deltaTime * 2);
            }

            // Optional: smooth FOV for forward/reverse
            if (Input.GetKey(KeyCode.W))
            {
                cinemachine_camera.m_Lens.FieldOfView = Mathf.Lerp(cinemachine_camera.m_Lens.FieldOfView, 70, Time.deltaTime * 2);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                cinemachine_camera.m_Lens.FieldOfView = Mathf.Lerp(cinemachine_camera.m_Lens.FieldOfView, 50, Time.deltaTime * 2);
            }
            else
            {
                cinemachine_camera.m_Lens.FieldOfView = Mathf.Lerp(cinemachine_camera.m_Lens.FieldOfView, 60, Time.deltaTime * 2);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            is_on_ground = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            is_on_ground = false;
        }
    }
}
