using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{

    //дл€ зачЄта общего времени
    static class Timer
    {
        
        static float time;//1 unit == 1 sec

        public static bool IsRunning{ get{ return time > 0; } set{ } }

        static Timer()
        {

            Reset();//Start Time
        }
        

        public static void Reset()
        {
            time = 10;
        }


        public static void Add_Time_For_Easy ()
        {
            time += 15;
        }

        public static void Add_Time_For_Medium ()
        {
            time += 30;
        }

        public static void Add_Time_For_Hard ()
        {
            time += 45;
        }
        public static string Update()
        {
            if (!IsRunning) return " ";
            time -= Time.deltaTime;
            //Debug.Log(time);

            return (Convert.ToString(Convert.ToInt32(time)));

        }

    }
    public UnityEngine.UI.Text label_timer;//счЄтчик таймера
    public Text result_timer;//результат ѕќЅ≈ƒџ или ѕќ–ј∆≈Ќ»я игры


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    protected void Update()
    {
        
        label_timer.text = Timer.Update();
        Debug.Log(label_timer.text);
        if (!Timer.IsRunning) Lose();
    }

    protected void Lose()
    {
        result_timer.text = "YOU ARE LOSE";
    }

    protected void Win()
    {
        //
    }
}
