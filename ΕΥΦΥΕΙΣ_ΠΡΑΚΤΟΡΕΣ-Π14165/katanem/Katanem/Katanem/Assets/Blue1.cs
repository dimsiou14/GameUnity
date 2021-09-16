using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue1 : BlueLogic
{

    public Transform home;
    public Transform trgt;
    public int inventory = 0;

    // Use this for initialization
    void Start()
    {
        home = GameObject.FindGameObjectWithTag("BaseBlue").transform;
        if (GameObject.FindGameObjectWithTag("Wood"))
        {
            trgt = GameObject.FindGameObjectWithTag("Wood").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Canvas").GetComponent<Scores>().winner.text == "")
        {
            if (transform.position != trgt.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, trgt.position, Time.deltaTime * speed);
            }
            else if (transform.position == trgt.position && trgt.gameObject.tag != "Blank")
            {
                inventory = 1;

                if (trgt.gameObject.tag != "BaseBlue")
                {
                    trgt.gameObject.tag = "Blank";
                    trgt.gameObject.GetComponent<Renderer>().material = GameObject.Find("GameObject").GetComponent<Grid>().materials[6];
                }
            }

            if (inventory == 1)
            {
                trgt = home;
                if (transform.position == trgt.position)
                {
                    inventory = 0;

                    if (GameObject.FindGameObjectWithTag("Wood"))
                    {
                        GameObject.Find("Canvas").GetComponent<Scores>().storeInventoryWood++;

                        trgt = GameObject.FindGameObjectWithTag("Wood").transform;
                    }
                }
            }
            else Start();
        }
        else trgt = home;
    }
}