using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerStatusScipt : MonoBehaviour
{
    public int coins = 0;
    public float gas = 50f;

    public Text coins_text;

    public float player_experience = 0f;

    public bool has_gas;

    public void FixedUpdate()
    {
        GasConsumption(); 
    }

    private void GasConsumption()
    {
        if (gas > 0f)
        {
            gas -= Time.deltaTime * 1f;
            has_gas = true; 
        }
        else
        {
            has_gas = false;
        }
    }

    public void AddCoins(int amount)
    {
        Debug.Log("Coins added: " + amount);
        coins += amount;
        coins_text.text = coins.ToString() + "x";
    }

    public void AddGas(float amount)
    {
        Debug.Log("Gas added: " + amount);
        
        if (gas + amount > 50f)
        {
            amount = 50f - gas;
        }
        if (amount < 0)
        {
            amount = 0;
        }
        gas += amount;
    }    
}
