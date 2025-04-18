using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{

    public Text timer_text;
    public float time_limit = 120f;
    public float timer;
    public int time_minute;
    public int time_second;
    public int time_millisecond;
    private float time_remaining;
    private bool timer_running = false;

    public PlayerStatusScipt player_status_script;
    public UserInterfaceScript user_interface_script;

    void FixedUpdate()
    {
        if(player_status_script.has_gas == true)
        {
            timer += Time.deltaTime;
            time_minute = (int)(timer / 60);
            time_second = (int)(timer % 60);
            time_millisecond = (int)((timer - (int)timer) * 1000);
            timer_text.text = string.Format("{0:D2}:{1:D2}:{2:D2}", time_minute, time_second, time_millisecond);
        }
        else if(player_status_script.has_gas == false)
        {
            Debug.Log("Gas is empty, timer stopped.");  
            user_interface_script.LoseOpenPanel();
        }
 }


}
