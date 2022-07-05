using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Minigame : MonoBehaviour
{

    //дл€ зачЄта общего времени
    public static class Timer
    {

        static float time;//1 unit == 1 sec

        public static bool IsActive = false;

        public static bool IsRunning { get { return time > 0; } set { } }

        static Timer()
        {
            
            Reset();//Start Time
            Stop();
        }

        public static void Start()
        {
            IsActive = true;
        }

        public static void Stop()
        {
            IsActive = false;
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
            if (!IsRunning && !IsActive) return " ";
            time -= Time.deltaTime;
            /*Debug.Log(time);*/

            return (Convert.ToString(Convert.ToInt32(time)));

        }

    }
    public UnityEngine.UI.Text label_timer;//счЄтчик таймера
    public Text result_timer;//результат ѕќЅ≈ƒџ или ѕќ–ј∆≈Ќ»я игры
    public byte difficulty;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    protected void Update_MAIN()
    {

        //(GameObject.Find("Label_Timer")).GetComponent<Text>().text = Timer.Update();
        
        /*Debug.Log(label_timer.text);*/
        if (!Timer.IsRunning) Lose("TIME IS OUT");
    }

    protected void Lose(string message)
    {
        //result_timer.text = message;
        StartCoroutine(Blink(2f));
    }
    //1 - easy, 2 - norm, 3 - hard
    protected void Win()
    {
        switch (difficulty)
        {
            case 1:
                Timer.Add_Time_For_Easy();
                break;
            case 2:
                Timer.Add_Time_For_Medium();
                break;
            case 3:
                Timer.Add_Time_For_Hard();
                break;
            default:
                break;
        }
        StartCoroutine(Blink(2f));
        
    }
    private IEnumerator Blink(float waitTime)
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Hub");


    }
}
