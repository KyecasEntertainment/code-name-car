using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCanScript : MonoBehaviour
{
    public float gas_can_value = 20;
    public float rotation_speed = 100f;

    public PlayerStatusScipt player_status;
    public GasCanSpawner gas_can_spawner;

    private void Update()
    {
        // Rotate the gas can around its Y-axis
        transform.Rotate(Vector3.up, rotation_speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStatusScipt player_status = other.GetComponent<PlayerStatusScipt>();
            if (player_status != null)
            {
                player_status.AddGas(gas_can_value);
                gas_can_spawner.has_spawned = false; 
                Destroy(gameObject); 
            }
        }
    }
}
