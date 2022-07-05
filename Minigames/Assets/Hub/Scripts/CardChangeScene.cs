using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CardChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeScene()
    {
        SceneManager.LoadScene(this.gameObject.GetComponentInChildren<Text>().text);
    }
}
