using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    public GameObject slider;
    public GameObject handle;
    public Vector3 startRotation;
    public int speed;
    float herz;
    public AudioSource music;
    public Text res_lbl;
    public AudioSource noise;

    void Start()
    {
        handle.transform.eulerAngles = startRotation;
        herz = Random.Range(-5.852535f, 5.852535f);
        music.volume = 0.3f;
        noise.volume = Mathf.Abs(herz - slider.transform.position.x) / 100f * 8.547f;
        noise.Play();
        music.Play();
        
    }
    // Update is called once per frame
    void Update()
    {
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
        if (Mathf.Abs(herz - slider.transform.position.x) / 100f * 8.547f < 0.01f)
        {
            res_lbl.text = "U WON ZULUL";
        }
        else
        {
            res_lbl.text = "NEVERNO";
        }
    }
}
