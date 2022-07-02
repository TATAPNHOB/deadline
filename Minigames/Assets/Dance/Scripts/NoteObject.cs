using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    //������ ��� ���������������� ��������� ��� �� �������� ��� ���� ����
    public KeyCode keyToPress;
    public bool ableToPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (ableToPressed)
            {
                gameObject.SetActive(false);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D thing)
    {
           if (thing.tag=="Activator")
        {
            ableToPressed = true;
        }
    }


    private void OnTriggerExit2D(Collider2D thing)
    {
        if (thing.tag == "Activator")
        {
            ableToPressed = false;
            gameObject.SetActive(false);
        }
    }

}
