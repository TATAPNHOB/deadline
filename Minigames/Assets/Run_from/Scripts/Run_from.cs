using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run_from : MonoBehaviour
{
    
    public GameObject res_lbl;
    GameObject Spawn;
    public GameObject Gen;
    public GameObject Enemy;
    public GameObject Player;
    public GameObject Enemy2;
    public GameObject Enemy3;
    int diff = 3;
    float spawn_speed;

    // Start is called before the first frame update
    void Start()
    {
        switch(diff)
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
        InvokeRepeating("Spawning", 1f, spawn_speed);
    }

    // Update is called once per frame
    void Update()
    {
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
        
        if (Coll.gameObject.tag == "Finish")
        {
            res_lbl.SetActive(true);
        }
    }

    void Spawning()
    {
        float x1 = Random.Range(Player.transform.position.x-10f, Player.transform.position.x+10f);
        float x2 = Random.Range(-55f, 55f);
        int enemy = Random.Range(1, 4);
        switch (enemy)
        {
            case 1:
                Spawn = Instantiate(Enemy, new Vector3(x1, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;
                Spawn = Instantiate(Enemy3, new Vector3(x2, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;
                
                break;
            case 2:
                Spawn = Instantiate(Enemy2, new Vector3(x1, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;
                Spawn = Instantiate(Enemy, new Vector3(x2, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;
                break;
            case 3:
                Spawn = Instantiate(Enemy3, new Vector3(x1, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;
                Spawn = Instantiate(Enemy2, new Vector3(x2, Gen.transform.position.y, Gen.transform.position.z), Quaternion.identity) as GameObject;
                break;
        }
            
        
    }
}
