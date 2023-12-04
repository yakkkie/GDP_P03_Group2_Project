using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButtons : MonoBehaviour
{
    [SerializeField]
    UserInput userInput;


    public void OnFoodBowlButtonClick()
    {
        userInput.holdingFoodBowl = true;
        Debug.Log(userInput.holdingFoodBowl);
    }

    public void OnWaterBowlButtonClick()
    {
        Debug.Log("WaterBowl");
    }


}
