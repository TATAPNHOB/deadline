using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : Minigame
{
    public GameObject slider;
    public GameObject handle;
    public Vector3 startRotation;
    public int speed;
    float herz;
    public AudioSource music;
    public Text res_lbl;
    public AudioSource noise;

    float range;

    void Start()
    {
        handle.transform.eulerAngles = startRotation;
        herz = Random.Range(-5.852535f, 5.852535f);
        music.volume = 0.3f;
        noise.volume = Mathf.Abs(herz - slider.transform.position.x) / 100f * 8.547f;
        noise.Play();
        music.Play();

        //временно
        difficulty = 1;

        switch(difficulty)
        {
            case 1:
                range = 0.1f;
                break;
            case 2:
                range = 0.05f;
                break;
            case 3:
                range = 0.01f;
                break;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Minigame.Timer.IsPaused) return;
        base.Update_MAIN();
        if (Input.GetKey(KeyCode.Q)&&slider.transform.position.x> -5.852535f)
        {
            slider.transform.position += Vector3.left*0.003f;
            handle.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
            noise.volume = Mathf.Abs(herz-slider.transform.position.x)/100f*8.547f;
            
        }
        else if (Input.GetKey(KeyCode.E)&&slider.transform.position.x< 5.852535f)
        {
            slider.transform.position += Vector3.right*0.003f;
            handle.transform.Rotate(Vector3.back, speed * Time.deltaTime);
            noise.volume = Mathf.Abs(herz - slider.transform.position.x)/100f* 8.547f;
        }
        
        
    }
    public void btn_click()
    {
        if (Mathf.Abs(herz - slider.transform.position.x) / 100f * 8.547f < range)
        {
            res_lbl.text = "U WON ZULUL";
            Win();
        }
        else
        {
            res_lbl.text = "NEVERNO";
        }
    }
}
