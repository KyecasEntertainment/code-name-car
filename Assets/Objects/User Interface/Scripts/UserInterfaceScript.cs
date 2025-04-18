using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterfaceScript : MonoBehaviour
{


    public GameObject shop_panel;
    public GameObject exprience_panel;

    private void Start()
    {
        shop_panel.SetActive(true);
        exprience_panel.SetActive(false);
    }

    private void FixedUpdate()
    {
     OpenShopPanel();
     OpenExperiencePanel();   
    }

    private void OpenShopPanel()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            shop_panel.SetActive(!shop_panel.activeSelf);
        }
    }
    private void OpenExperiencePanel()
    {
        // if all coins are collected, open the experience panel
    }


}
