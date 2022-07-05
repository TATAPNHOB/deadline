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

        public static bool IsPaused = false;

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
            time = 60;
        }


        public static void Add_Time_For_Easy ()
        {
            time += 15;
            Debug.Log("Added for easy");
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
    public byte difficulty=1;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    protected void Update_MAIN()
    {

        (GameObject.Find("Label_Timer")).GetComponent<Text>().text = Timer.Update();
        
        /*Debug.Log(label_timer.text);*/
        if (!Timer.IsRunning) Total_Lose();
    }

    protected void Lose(string message)
    {
        (GameObject.Find("Result")).GetComponent<Text>().text = message;
        //result_timer.text = message;
        StartCoroutine(Blink(2f));

    }
    protected void Total_Lose()
    {
        (GameObject.Find("Result")).GetComponent<Text>().text = "Time is Out";
        //result_timer.text = message;

        GameObject.Find("Pause_Menu_Instance").GetComponent<MenuController>().For_total_lose();
        Timer.Stop();
    }
    //1 - easy, 2 - norm, 3 - hard
    protected void Win()
    {
        (GameObject.Find("Result")).GetComponent<Text>().text = "YOU WIN";
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
        (GameObject.Find("Result")).GetComponent<Text>().text = "";
        SceneManager.LoadScene("Hub");


    }
}
