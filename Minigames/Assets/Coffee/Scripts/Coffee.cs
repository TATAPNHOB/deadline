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
    public SpriteRenderer machine;
    public Sprite under_sprite;
    public Sprite over_sprite;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetNewRandomTime",delayTime);
        
    }

    public void Stop_coffee(){
        float playerWaitTime = Time.time - startTime;
        float error = waitTime - playerWaitTime;
        if(error<0)
        {
            res_lbl.text = $"Переварил {-error} секунд";
            machine.sprite = over_sprite;
        }
        else if(error>0)
        {
            res_lbl.text = $"Недоварил {error} секунд";
            machine.sprite = under_sprite;
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