using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public Material[] materials;
    public GameObject RedAgents;
    public GameObject BlueAgents;
    public int NumberOfColumns = 10; // number of columns for the grid
    public int NumberOfRows = 10; // number of rows for the grid
    public float SeperationValueX = 0.0f; // Distance between each column
    public float SeperationValueZ = 0.0f; // Distance between each Row

    private float tempSepX = 0; // used to calculate the separation between each column
    private float tempSepZ = 0;


    void Start () {
        createGrid();
    }

    void createGrid()
    {
        string[] tileTags = new string[] { "Blank", "Gold", "Iron", "Wood"};
        System.Random random = new System.Random();
        int useTag = random.Next(tileTags.Length);
        string pickTag = tileTags[useTag];

        for (int i = 0; i < NumberOfColumns; i++)
        {//loop 1 to loop through columns
            for (int j = 0; j < NumberOfRows; j++)
            {//loop 2 to loop through rows

                GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Quad); //create a quad primitive as provided by unity

                if( i == NumberOfColumns - NumberOfColumns && j == NumberOfRows - NumberOfRows)
                {
                    GameObject redAgent1, redAgent2, redAgent3, redAgent4;
                    redAgent1 = Instantiate(RedAgents, new Vector3(0, 1, 0), transform.rotation);
                    redAgent2 = Instantiate(RedAgents, new Vector3(1, 1, 1), transform.rotation);
                    redAgent3 = Instantiate(RedAgents, new Vector3(2, 1, 2), transform.rotation);
                   // redAgent4 = Instantiate(RedAgents, new Vector3(3, 1, 3), transform.rotation);

                    redAgent1.AddComponent<Red>();
                    redAgent2.AddComponent<Red>();
                    redAgent3.AddComponent<Red>();
                  //  redAgent4.AddComponent<Red>();
                }
                if (i == NumberOfColumns - 1 && j == NumberOfRows - 1)
                {
                    GameObject agent1, agent2, agent3, agent4;
                    agent1 = Instantiate(BlueAgents, new Vector3(NumberOfColumns - 4, 1, NumberOfColumns - 4), transform.rotation);
                    agent2 = Instantiate(BlueAgents, new Vector3(NumberOfColumns - 1, 1, NumberOfColumns - 1), transform.rotation);
                    agent3 = Instantiate(BlueAgents, new Vector3(NumberOfColumns - 2, 1, NumberOfColumns - 2), transform.rotation);
                    //agent4 = Instantiate(BlueAgents, new Vector3(NumberOfColumns - 3, 1, NumberOfColumns - 3), transform.rotation);

                    agent1.AddComponent<Blue1>();
                    agent2.AddComponent<Blue2>();
                    agent3.AddComponent<Blue3>();
                }
                if (i >= NumberOfColumns - NumberOfColumns && i <= (NumberOfColumns / 3) && j <= (NumberOfRows / 3) && j >= NumberOfRows - NumberOfRows)
                {
                    plane.gameObject.tag = "BaseRed";
                    plane.gameObject.GetComponent<Renderer>().material = materials[0];
                }
                else if (i >= (2 *NumberOfColumns / 3) && i <= NumberOfColumns - 1 && j <= NumberOfRows - 1 && j >= (2 * NumberOfRows / 3))
                {
                    plane.gameObject.tag = "BaseBlue";
                    plane.gameObject.GetComponent<Renderer>().material = materials[2];
                }
                else
                {
                    plane.gameObject.tag = tileTags.RandomItem();
                    if (plane.gameObject.tag != "Blank")
                    {
                        plane.gameObject.GetComponent<Renderer>().material = materials[1];
                    }
                    if (plane.gameObject.tag == "Gold")
                    {
                        plane.gameObject.GetComponent<Renderer>().material = materials[3];
                    }
                    if (plane.gameObject.tag == "Iron")
                    {
                        plane.gameObject.GetComponent<Renderer>().material = materials[4];
                    }
                    if (plane.gameObject.tag == "Wood")
                    {
                        plane.gameObject.GetComponent<Renderer>().material = materials[5];
                    }
                }

                plane.transform.position = new Vector3(i, 0, j); //position the newly created quad accordingly
                plane.transform.eulerAngles = new Vector3(90f, 0, 0);
            }
        }
    }
}
public static class ArrayExtensions
{
    // This is an extension method. RandomItem() will now exist on all arrays.
    public static T RandomItem<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}
