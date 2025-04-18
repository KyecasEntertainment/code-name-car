using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterfaceScript : MonoBehaviour
{


    public GameObject shop_panel;
    public GameObject exprience_panel;

    private void Start()
    {
        shop_panel.SetActive(false);
        exprience_panel.SetActive(false);
    }

    private void OpenShopPanel()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            shop_panel.SetActive(!shop_panel.activeSelf);
        }
    }
    public void WinOpenPanel()
    {
        // if all coins are collected, open the experience panel
    }

    public void LoseOpenPanel()
    {
        exprience_panel.SetActive(true);

    }


}
