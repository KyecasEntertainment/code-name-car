using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public int coin_value = 1; 
    public float rotation_speed = 100f;

    public PlayerStatusScipt player_status;

    private void Update()
    {
        // Rotate the coin around its Y-axis
        transform.Rotate(Vector3.up, rotation_speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Assuming you have a PlayerStatusScipt that handles player status
            PlayerStatusScipt player_status = other.GetComponent<PlayerStatusScipt>();
            if (player_status != null)
            {
                player_status.AddCoins(coin_value); // Add coins to the player's status
                Destroy(gameObject); // Destroy the coin object after collection
            }
        }
    }
}
