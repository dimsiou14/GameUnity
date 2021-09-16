using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{

    public int woodMax = 5;
    public int ironMax = 2;
    public int goldMax = 3;
    [HideInInspector]
    public int storeInventoryWood = 0;
    [HideInInspector]
    public int storeInventoryIron = 0;
    [HideInInspector]
    public int storeInventoryGold = 0;

    public Text BlueWood;
    public Text BlueIron;
    public Text BlueGold;
    public Text winner;

    [HideInInspector]
    public int redInventoryWood = 0;
    [HideInInspector]
    public int redInventoryIron = 0;
    [HideInInspector]
    public int redInventoryGold = 0;

    public Text redWood;
    public Text redIron;
    public Text redGold;
    public Text redStat;


    void Update()
    {
        BlueWood.text = "Blue Team Wood: " + storeInventoryWood.ToString() + " / " + woodMax;
        BlueIron.text = "Blue Team Iron: " + storeInventoryIron.ToString() + " / " + ironMax;
        BlueGold.text = "Blue Team Gold: " + storeInventoryGold.ToString() + " / " + goldMax;

        redWood.text = "Red Team Wood: " + redInventoryWood.ToString() + " / " + woodMax;
        redIron.text = "Red Team Iron: " + redInventoryIron.ToString() + " / " + ironMax;
        redGold.text = "Red Team Gold: " + redInventoryGold.ToString() + " / " + goldMax;

        if (storeInventoryWood < woodMax && storeInventoryIron < ironMax && storeInventoryGold < goldMax)
        {
            winner.text = "";
        }
        else
        {
            if (redInventoryWood >= woodMax && redInventoryIron >= ironMax && redInventoryGold >= goldMax)
            {
                winner.text = "Red Team wins the match!";
                winner.color = Color.red;

            }

            else if (storeInventoryWood >= woodMax && storeInventoryIron >= ironMax && storeInventoryGold >= goldMax)
            {
                winner.text = "Blue Team wins the match!";
                winner.color = Color.blue;
            }
           
        }






    }
}
