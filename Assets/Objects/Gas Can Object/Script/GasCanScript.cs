using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCanScript : MonoBehaviour
{
    public float gas_can_value = 20;
    public float rotation_speed = 100f;

    public GasCanSpawner gas_can_script;


    private void Update()
    {
        // Rotate the gas can around its Y-axis
        transform.Rotate(Vector3.up, rotation_speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStatusScipt>().AddGas(gas_can_value);
            gas_can_script.has_spawned = false; // Reset the spawn flag in the spawner script
            Destroy(gameObject);
        }
    }
}
