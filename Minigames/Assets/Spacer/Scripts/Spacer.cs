using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spacer : MonoBehaviour
{
    public bool IJ;
    public GameObject res_lbl;
    public GameObject cac;
    GameObject Spawn;
    public GameObject yeet1;
    public GameObject yeet2;
    public GameObject emptygen;

    // Start is called before the first frame update
    void Start()
    {
        IJ = false;
        InvokeRepeating("start_lvl", 1, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)&&!IJ)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 7, 0);
            IJ = true;
        }
        

        yeet1.transform.position -= new Vector3(6f * Time.deltaTime, 0, 0);
        if (yeet1.transform.position.x <= -19.62f)
        {
            yeet1.transform.position = new Vector3(19.62f, yeet1.transform.position.y, 0f);
        }

        yeet2.transform.position -= new Vector3(6f * Time.deltaTime, 0, 0);
        if (yeet2.transform.position.x <= -19.62f)
        {
            yeet2.transform.position = new Vector3(19.62f, yeet2.transform.position.y, 0f);
        }
    }

    void OnCollisionEnter2D(Collision2D Coll)
    {
        if(Coll.gameObject.tag=="Finish")
        {
            IJ = false;
        }
        if (Coll.gameObject.tag == "Respawn")
        {
            res_lbl.SetActive(true);
        }
    }
    void start_lvl()
    {
        float range = Random.Range(10f, 17f);
        Spawn = Instantiate(cac, new Vector3(emptygen.transform.position.x - range, emptygen.transform.position.y, emptygen.transform.position.z), Quaternion.identity) as GameObject;

    }
}
