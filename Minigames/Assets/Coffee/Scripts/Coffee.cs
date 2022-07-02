using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coffee : MonoBehaviour
{
    public Text time_lbl;
    public Text res_lbl;
    int waitTime;
    float delayTime = 4;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetNewRandomTime",delayTime);
        
    }

    public void Stop_coffee(){
        float playerWaitTime = Time.time - startTime;
        float error = Mathf.Abs(waitTime - playerWaitTime);
        if(error<0)
        {
            res_lbl.text = $"Переварил {error} секунд";
        }
        else if(error>0)
        {
            res_lbl.text = $"Недоварил {error} секунд";
        }
        else
        {
            res_lbl.text = "Спасибо за кофе!";
        }
    }
    void SetNewRandomTime()
    {
        waitTime= Random.Range(3,10);
        time_lbl.text = $"Выключи кофе через: {waitTime}";
        startTime = Time.time;
    }
}