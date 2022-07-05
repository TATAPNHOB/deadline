using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    //список для деактивированных стрелочек для их удаления или типа того
    public KeyCode keyToPress;
    public bool ableToPressed;
    GameObject parent;
    public AudioClip noteSound;
    public AudioSource noteAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("NoteHolder");
        noteAudioSource = GameObject.Find("NoteSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (ableToPressed)
            {
                Debug.Log("Hitted");
                parent.GetComponent<BeatScroller>().inc_beatedNotes();

                noteAudioSource.PlayOneShot(noteSound);
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
