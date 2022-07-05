using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public byte number;
    public void RunAnimation ()
    {
        Animation anim = GetComponent<Animation>();
        switch (number)
        {
            case 1:
                anim.Play("Card Animation 1");
                Debug.Log("Played 1 anim");
                break;
            case 2:
                anim.Play("Card Animation 2");
                break;
            case 3:
                anim.Play("Card Animation 3");
                break;

            default:
                Debug.Log("Wrong numbrer");
                break;
        }
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
