using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run_from : Minigame
{

    GameObject Spawn1;
    GameObject Spawn2;
    public GameObject Gen;
    public GameObject Enemy;
    public GameObject Player;
    public GameObject Enemy2;
    public GameObject Enemy3;

    float spawn_speed;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = 3;
        switch(difficulty)
        {
            case 1:
                spawn_speed = 1.5f;
                break;
            case 2:
                spawn_speed = 1.25f;
                break;
            case 3:
                spawn_speed = 1f;
                break;
        }
        //StartCoroutine("spawn");
        InvokeRepeating("Spawning", 1f, spawn_speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Minigame.Timer.IsPaused) return;
        this.Update_MAIN();
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && Player.transform.position.x >= -55.6f)
        {
            Player.transform.position -= new Vector3(20f * Time.deltaTime, 0f, 0f);
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && Player.transform.position.x <= 55.6f)
        {
            Player.transform.position += new Vector3(20f * Time.deltaTime, 0f, 0f);
        }


    }
    void OnCollisionEnter2D(Collision2D Coll)
    {
        
        if (Coll.gameObject.tag == "Respawn")
        {
            //res_lbl.SetActive(true);
            Lose("YOU LOST");
            
        }
    }

    void Spawning()
    {
        float x1 = Random.Range(Player.transform.position.x - 10f, Player.transform.position.x + 10f);
        float x2 = Random.Range(-55f, 55f);
        int enemy = Random.Range(1, 4);

        switch (enemy)
        {
            case 1:
                Spawn1 = Instantiate(Enemy, new Vector3(x1, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;
                Spawn2 = Instantiate(Enemy3, new Vector3(x2, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;

                break;
            case 2:
                Spawn1 = Instantiate(Enemy2, new Vector3(x1, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;
                Spawn2 = Instantiate(Enemy, new Vector3(x2, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;
                break;
            case 3:
                Spawn1 = Instantiate(Enemy3, new Vector3(x1, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;
                Spawn2 = Instantiate(Enemy2, new Vector3(x2, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;
                break;
        }


    }
    //IEnumerator spawn()
    //{
    //    while(true)
    //    {
    //        float x1 = Random.Range(Player.transform.position.x - 10f, Player.transform.position.x + 10f);
    //        float x2 = Random.Range(-55f, 55f);
    //        int enemy = Random.Range(1, 4);
    //        GameObject Spawn1 = null, Spawn2 = null;
    //        switch (enemy)
    //        {
    //            case 1:
    //                Spawn1 = Instantiate(Enemy, new Vector3(x1, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;
    //                Spawn2 = Instantiate(Enemy3, new Vector3(x2, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;

    //                break;
    //            case 2:
    //                Spawn1 = Instantiate(Enemy2, new Vector3(x1, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;
    //                Spawn2 = Instantiate(Enemy, new Vector3(x2, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;
    //                break;
    //            case 3:
    //                Spawn1 = Instantiate(Enemy3, new Vector3(x1, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;
    //                Spawn2 = Instantiate(Enemy2, new Vector3(x2, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;
    //                break;
    //        }
    //        yield return new WaitForSeconds(spawn_speed);
    //        Destroy(Spawn1);
    //        Destroy(Spawn2);
    //    }

    //}
}
