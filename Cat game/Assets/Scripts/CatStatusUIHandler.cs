using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CatStatusUIHandler : MonoBehaviour
{
    public Image healthBar;
    public Image hungerBar;
    public Image thirstBar;

    public Cat cat;

    void Update()
    {
        UpdateHungerBar();
    }


    void UpdateHungerBar()
    {
        hungerBar.fillAmount = cat.currentHunger/cat.MaxHunger;
    }
}
