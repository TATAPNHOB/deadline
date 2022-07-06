using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiano : Minigame
{
    public AudioSource[] NoteDict;//
    public UnityEngine.UI.Button[] notes;//= new GameObject[17];
    AudioSource[] SELECTED_notes = new AudioSource[1];// = new GameObject[5];
    public static UnityEngine.UI.Button[] PLAYED_notes = new UnityEngine.UI.Button[1];
    public static byte index_playing_note=0;

    public UnityEngine.UI.Text textLABEL;
    // Start is called before the first frame update
    AudioSource[] ALLaudioSources;
    void Start()
    {
         
        //заменить на unity.random
        System.Random rnd = new System.Random();

        for (int i = 0; i <SELECTED_notes.Length; i++)
        {
            SELECTED_notes[i] = NoteDict[rnd.Next(0, 17)];
        }

        StartCoroutine(Blink(1.2f));
    }




    // Update is called once per frame
    void Update()
    {
        if (Minigame.Timer.IsPaused) return;
        base.Update_MAIN();
        if (index_playing_note==SELECTED_notes.Length)
        {
            bool check = true;
            index_playing_note = 0;
            for (int i = 0; i < SELECTED_notes.Length; i++)
            {
                if (Array.IndexOf(NoteDict,SELECTED_notes[i])!= Array.IndexOf(notes, PLAYED_notes[i]))
                {
                    check = false;
                    break;
                }
            }
            Debug.Log("Дошёл до результата");
            if (check)
            {
                textLABEL.text = "УРА! Отгадал!";
                foreach (var iterNote in notes)
                {
                    iterNote.interactable = false;
                }
                Win();
            }
            else
            {
                textLABEL.text = "Не угадал! Попробуй ещё раз!";
                StartCoroutine(Blink(1f));
            }
        }
    }



    private IEnumerator Blink(float waitTime)
    {
        foreach (var iterNote in notes)
        {
            iterNote.interactable = false;
        }
        yield return new WaitForSeconds(waitTime);
        /*foreach (var audioSource in ALLaudioSources)
        {
            audioSource.mute = !audioSource.mute;
        }*/
        for (int i = 0; i < SELECTED_notes.Length; i++)
        {
            SELECTED_notes[i].Play(1);
            yield return new WaitForSeconds(waitTime);

        }
        foreach (var iterNote in notes)
        {
            iterNote.interactable = true;
        }


    }

}
