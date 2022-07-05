using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : Minigame
{
    public float beatTemp;
    public GameObject[] Arrows;
    public int beatedNotes;
    

    // Start is called before the first frame update
    void Start()
    {
        beatTemp = beatTemp / 60f;
        beatedNotes = 0;
    }

    public void inc_beatedNotes()
    {
        beatedNotes++;
    }

    System.Random rnd = new System.Random();
    float time_by_second;
    // Update is called once per frame
    void Update()
    {
        base.Update_MAIN();
        //Instantiate(brick);
        if (beatedNotes>=10)
        {
            this.Win();
        }
        
        
            
            time_by_second -= Time.deltaTime;

            if (time_by_second <= 0)
            {
                var newOBJ = Instantiate(Arrows[rnd.Next(0, 4)]).transform;

                newOBJ.SetParent(this.transform);

                time_by_second = 0.7f;
            }

            Transform[] Childs = GetComponentsInChildren<Transform>();

            foreach (var child in Childs)
            {
                switch (child.tag)
                {
                    case "Up":
                        child.transform.position -= new Vector3(0f, beatTemp * Time.deltaTime, 0f);
                        break;
                    case "Down":
                        child.transform.position += new Vector3(0f, beatTemp * Time.deltaTime, 0f);
                        break;
                    case "Left":
                        child.transform.position += new Vector3(beatTemp * Time.deltaTime, 0f, 0f);
                        break;
                    case "Right":
                        child.transform.position -= new Vector3(beatTemp * Time.deltaTime, 0f, 0f);
                        break;
                    default:
                        break;
                }
            }

            
            

        

    }
    
}
