using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTemp;


    public bool IsStarted;
    // Start is called before the first frame update
    void Start()
    {
        beatTemp = beatTemp / 60f;
        
    }

    // Update is called once per frame
    void Update()
    {

        //Instantiate(brick);



        if (!IsStarted)
        {
            if (Input.anyKeyDown)
            {
                IsStarted=!IsStarted;
            }
        }
        else
        {
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
    
}
