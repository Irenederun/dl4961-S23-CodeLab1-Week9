using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI display;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayMoneyFromFish();
    }
    
    private Dictionary<string, int> moneyFromFish = new Dictionary<string, int>(); // initialize dictionary

    public void AddFishes(string fishType, int moneyAmount)
    {
        if (moneyFromFish.ContainsKey(fishType)) // if there already exists the key matched with fish just caught
        {
            moneyFromFish[fishType] = moneyFromFish[fishType] + moneyAmount; // update money amount
        }
        else // if not
        {
            moneyFromFish.Add(fishType, moneyAmount); // create a new key and add the amount
        }
        
        Debug.Log("You gained " + moneyFromFish[fishType] + "G from " + fishType + "fish");
    }

    private void DisplayMoneyFromFish()
    {
        display.text =
            "Money Gained From Fish: \n\n"; 
        foreach (var KeyValuePair in moneyFromFish)
        { 
            display.text += KeyValuePair.Key + " : " + moneyFromFish[KeyValuePair.Key] + "\n";
            //for every key that exists in the dictionary, print the key and the paired value. 
        }
    }
}
