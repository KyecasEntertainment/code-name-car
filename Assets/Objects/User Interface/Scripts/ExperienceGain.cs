using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceGain : MonoBehaviour
{
    // UI elements
    public Text level_text;
    public Text experience_text;

    // Game variables
    public float experience_gain;
    public TimerScript timer_script;
    
    // Json Reference
    public TextAsset player_stat_json;
    public int player_level;  
    public float player_current_experience;
    public float player_experience_to_next_level;

    [System.Serializable]
    public class PlayerStat
    {
        public int level;
        public float current_experience;
        public float experience_to_next_level;
    }
    void Start()
    {
        PlayerStat player_stat = JsonUtility.FromJson<PlayerStat>(player_stat_json.text);
        player_level = player_stat.level;
        player_current_experience = player_stat.current_experience;
        player_experience_to_next_level = player_stat.experience_to_next_level;
        CalculateExperience(timer_script.timer);
    }

    PlayerStat player_stat = new PlayerStat();  


    public void CalculateExperience(float time){
        float time_factor = 10f;

        float time_experience = (20 / Mathf.Max(time, 1)) * time_factor;

        GainExperience(time_experience);

    }
    public void GainExperience(float amount)
    {
        experience_gain += amount;
        int experience_int = (int)experience_gain;
        player_current_experience += experience_int;
        int current = (int)player_current_experience;
        Debug.Log(current);

        experience_text.text = experience_int.ToString() + " EXP";



    }

    

     




}