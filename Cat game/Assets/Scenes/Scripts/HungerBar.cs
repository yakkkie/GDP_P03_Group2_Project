using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerBar : MonoBehaviour
{
    //float fullHunger = 124f;
    float emptyHunger = 0f;
    float hungerRate = 10f;
    float healthRate = 50f;
    float emptyHealth = 0f;

    float hungerXAxis;
    float healthXAxis;

    public UnityEngine.UI.Image hungerBarEmpty;
    public UnityEngine.UI.Image healthBarEmpty;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hungerXAxis = hungerBarEmpty.GetComponent<RectTransform>().anchoredPosition.x;//Empty Hunger starts from HungerBar

        if (hungerBarEmpty.GetComponent<RectTransform>().anchoredPosition.x > emptyHunger)//Empty Hungerbar when hungry
        {
            hungerXAxis -= 0.1f * Time.deltaTime * hungerRate;
            hungerBarEmpty.GetComponent<RectTransform>().anchoredPosition = new Vector2(hungerXAxis, hungerBarEmpty.GetComponent<RectTransform>().anchoredPosition.y);
        }

        if (hungerBarEmpty.GetComponent<RectTransform>().anchoredPosition.x <= emptyHunger)//If Hungerbar = Empty
        {
            hungerXAxis = 0f;
            hungerBarEmpty.GetComponent<RectTransform>().anchoredPosition = new Vector2(hungerXAxis, hungerBarEmpty.GetComponent<RectTransform>().anchoredPosition.y);

            healthXAxis = healthBarEmpty.GetComponent<RectTransform>().anchoredPosition.x;//Empty Health

            if (healthXAxis > emptyHealth)//If there is still Health in healthbar, Empty Health
            {
                healthXAxis -= 0.1f * Time.deltaTime * healthRate;
                healthBarEmpty.GetComponent<RectTransform>().anchoredPosition = new Vector2(healthXAxis, healthBarEmpty.GetComponent<RectTransform>().anchoredPosition.y);
            }
        }
    }
}
