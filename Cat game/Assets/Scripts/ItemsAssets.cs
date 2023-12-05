using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsAssets : MonoBehaviour
{
    public static ItemsAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite aTierCatFood;
    public Sprite bTierCatFood;
    public Sprite cTierCatFood;
    public Sprite cockroachSpray;
    public Sprite electricSwatter;
    public Sprite insectRepellent;
    public Sprite lizardKiller;
    public Sprite normalSwatter;
}
