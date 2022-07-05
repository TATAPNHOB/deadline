using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameShuffler : Minigame
{
    // Start is called before the first frame update
    bool IsTurningCard=false;

    public GameObject card1;
    System.Random rnd;
    /*public GameObject card2;
    public GameObject card3;*/
    public Sprite forCard1;
   /* public Sprite forCard2;
    public Sprite forCard3;*/

    public string[] Minigames;//список названия сцен мини-игры, которые шафлятся
    void Start()
    {

        rnd = new System.Random();
        GameObject[] uis = GameObject.FindGameObjectsWithTag("Extended UI");
        foreach (GameObject iter in uis)
        {

            iter.SetActive(true);
        }
        /*List<GameObject> temp = ObjectExtension.GetSavedObjects();
        foreach (var item in temp)
        {
            Debug.Log(item.name);
        }*/


        GameObject[] timerObjects = GameObject.FindGameObjectsWithTag("Timer");
        foreach (var iterObject in timerObjects)
        {
            Debug.Log("Нашёл 2 объекта?");
            iterObject.SetActive(true);
        }
        
    }


    public void StartShuffling()
    {
        IsTurningCard = true;
        GameObject[] uis = GameObject.FindGameObjectsWithTag("Extended UI");
        foreach (GameObject iter in uis)
        {

            iter.SetActive(false);
        }
        /* GameObject[] Cards = GameObject.FindGameObjectsWithTag("Activator");*/
        /*foreach (var iterCard in Cards)
        {
            iterCard.RunAnimation();
        }*/
    }



    // Update is called once per frame
    void Update()
    {
        base.Update_MAIN();

        if (IsTurningCard)
        {

            CardShuffling();
        }
    }
    void CardShuffling()
    {
        GameObject[] Cards = GameObject.FindGameObjectsWithTag("Activator");
        Debug.Log(Math.Truncate(Cards[0].transform.rotation.y * 100));
        foreach (var iterCard in Cards)
        {
            if (iterCard.GetComponent<SpriteRenderer>().sprite != forCard1 &&
                Math.Truncate(iterCard.transform.rotation.y * 100) > -50 && Math.Truncate(iterCard.transform.rotation.y * 100) <100 )
            {
                iterCard.GetComponentInChildren<Text>().text = Minigames[rnd.Next(Minigames.Length)];
                Debug.Log("Проверка поворота карты пройдена");
                iterCard.GetComponent<SpriteRenderer>().sprite = forCard1;
                
                /*card2.GetComponent<SpriteRenderer>().sprite = forCard2;
                card3.GetComponent<SpriteRenderer>().sprite = forCard3;*/

            }
        }
    }
}
