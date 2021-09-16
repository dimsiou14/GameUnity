using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red2 : RedLogic
{

    public Transform home;
    public Transform trgt;
    public int inventory = 0;

    // Use this for initialization
    void Start()
    {
        home = GameObject.FindGameObjectWithTag("BaseRed").transform;
        if (GameObject.FindGameObjectWithTag("Iron"))
        {
            trgt = GameObject.FindGameObjectWithTag("Iron").transform;
        } 
        else if(GameObject.FindGameObjectWithTag("Wood"))
        {
            trgt = GameObject.FindGameObjectWithTag("Wood").transform;
        }
        else if (GameObject.FindGameObjectWithTag("Gold"))
        {
            trgt = GameObject.FindGameObjectWithTag("Gold").transform;
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

                if (trgt.gameObject.tag != "BaseRed")
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
                    if (GameObject.FindGameObjectWithTag("Iron"))
                    {
                        GameObject.Find("Canvas").GetComponent<Scores>().redInventoryIron++;

                        trgt = GameObject.FindGameObjectWithTag("Iron").transform;
                    }
                    else if (GameObject.FindGameObjectWithTag("Wood"))
                    {
                        GameObject.Find("Canvas").GetComponent<Scores>().redInventoryWood++;

                        trgt = GameObject.FindGameObjectWithTag("Wood").transform;
                    }
                    else if (GameObject.FindGameObjectWithTag("Gold"))
                    {
                        GameObject.Find("Canvas").GetComponent<Scores>().redInventoryGold++;

                        trgt = GameObject.FindGameObjectWithTag("Gold").transform;
                    }

                    
                    

                }
            }
            else Start();
        }
    }
}