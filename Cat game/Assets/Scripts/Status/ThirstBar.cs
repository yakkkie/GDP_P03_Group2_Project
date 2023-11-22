using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirstBar : MonoBehaviour
{
    //fullThirst = 122f;
    float emptyThirst = 0f;
    float thirstRate = 20f;
    float healthRate = 50f;
    float emptyHealth = 0f;

    float thirstXAxis;
    float healthXAxis;

    public UnityEngine.UI.Image thirstBarEmpty;
    public UnityEngine.UI.Image healthBarEmpty;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        thirstXAxis = thirstBarEmpty.GetComponent<RectTransform>().anchoredPosition.x;//Empty Thirst starts from ThirsthBar

        if (thirstBarEmpty.GetComponent<RectTransform>().anchoredPosition.x > emptyThirst)//Empty ThirstBar when thirsty
        {
            if (Input.GetButtonDown("Run"))
            {
                thirstRate = thirstRate * 20f;
            }

            if (Input.GetButtonUp("Run"))
            {
                thirstRate = thirstRate / 20f;
            }

            thirstXAxis -= 0.1f * Time.deltaTime * thirstRate;
            thirstBarEmpty.GetComponent<RectTransform>().anchoredPosition = new Vector2(thirstXAxis, thirstBarEmpty.GetComponent<RectTransform>().anchoredPosition.y);
        }

        if (thirstBarEmpty.GetComponent<RectTransform>().anchoredPosition.x <= emptyThirst)//If ThirstBar = Empty
        {
            thirstXAxis = 0f;
            thirstBarEmpty.GetComponent<RectTransform>().anchoredPosition = new Vector2(thirstXAxis, thirstBarEmpty.GetComponent<RectTransform>().anchoredPosition.y);
            healthXAxis = healthBarEmpty.GetComponent<RectTransform>().anchoredPosition.x;//Empty Health

            if (healthXAxis > emptyHealth)//If there is still Health in healthbar, Empty Health
            {
                healthXAxis -= 0.1f * Time.deltaTime * healthRate;
                healthBarEmpty.GetComponent<RectTransform>().anchoredPosition = new Vector2(healthXAxis, healthBarEmpty.GetComponent<RectTransform>().anchoredPosition.y);
            }
        }
    }
}