using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cac : MonoBehaviour
{
    // Start is called before the first frame update
    int diff = 1;
    float speed;
    void Start()
    {
        switch(diff)
        {
            case 1:
                speed = 4f;
                break;
            case 2:
                speed = 8f;
                break;
            case 3:
                speed = 12f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
