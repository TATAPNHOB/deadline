using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendButton : MonoBehaviour
{
    public UnityEngine.UI.Button thisObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPressed()
    {
        Debug.Log("Кнопка нажата");
        GamePiano.PLAYED_notes[GamePiano.index_playing_note++]=thisObj;
    }
}
