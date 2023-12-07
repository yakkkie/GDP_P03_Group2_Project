using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CatStatusUIHandler : MonoBehaviour
{
    public Vector3 StatusOffset;
    public Transform StatusTransform;
    public Image healthBar;
    public Image hungerBar;
    public Image thirstBar;

    public Cat cat;

    void Update()
    {
        UpdateStatus();
        FollowCat();
    }


    void UpdateStatus()
    {
        UpdateHungerBar();
        UpdateHealthBar();
        UpdateThirstBar();
    }

    void UpdateHungerBar()
    {
        hungerBar.fillAmount = cat.currentHunger/cat.MaxHunger;
    }

    void UpdateThirstBar()
    {
        thirstBar.fillAmount = cat.currentThirst / cat.MaxThirst;
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = cat.currentHealth / cat.MaxHealth;
    }

    void FollowCat()
    {
        Camera cam = Camera.main;
        Vector3 catPosToScreen = cam.WorldToScreenPoint(cat.transform.position);

        StatusTransform.position = catPosToScreen + StatusOffset;
    }
}
