using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coffee : Minigame
{
    public Text time_lbl;
    public Text res_lbl;
    int waitTime;
    float delayTime = 4;
    float startTime;
    public SpriteRenderer machine;
    public Sprite under_sprite;
    public Sprite over_sprite;
    float range;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetNewRandomTime",delayTime);
        switch(difficulty)
        {
            case 1:
                range = 1f;
                break;
            case 2:
                range = 0.5f;
                break;
            case 3:
                range = 0.2f;
                break;
        }
        
    }

    public void Stop_coffee(){
        float playerWaitTime = Time.time - startTime;
        float error = waitTime - playerWaitTime;
        if(error<-range)
        {
            res_lbl.text = $"Переварил {-error} секунд";
            machine.sprite = over_sprite;
            Lose($"Переварил {-error} секунд");
        }
        else if(error>range)
        {
            res_lbl.text = $"Недоварил {error} секунд";
            machine.sprite = under_sprite;
            Lose($"Недоварил {error} секунд");
        }
        else
        {
            res_lbl.text = "Спасибо за кофе!";
            Win();
        }
    }
    void SetNewRandomTime()
    {
        waitTime= Random.Range(3,10);
        time_lbl.text = $"Выключи кофе через: {waitTime}";
        startTime = Time.time;
    }
    private void Update()
    {
        if (Minigame.Timer.IsPaused) return;
        base.Update_MAIN();
    }
}