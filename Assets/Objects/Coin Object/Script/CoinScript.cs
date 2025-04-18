using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public int coinValue = 1; 
    public float rotationSpeed = 100f;

    public PlayerStatusScipt playerStatus;

    private void Update()
    {
        // Rotate the coin around its Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Assuming you have a PlayerStatusScipt that handles player status
            PlayerStatusScipt playerStatus = other.GetComponent<PlayerStatusScipt>();
            if (playerStatus != null)
            {
                playerStatus.AddCoins(coinValue); // Add coins to the player's status
                Destroy(gameObject); // Destroy the coin object after collection
            }
        }
    }
}
