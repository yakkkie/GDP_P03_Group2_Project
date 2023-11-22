using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public UnityEngine.UI.Image healthBarEmpty;
    public GameObject gameOver;
    public string tag;
    // fullHealth = 122f;
    float emptyHealth = 0f;
    float damageRate = 50f;
    bool trigger;

    float xAxis;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xAxis = healthBarEmpty.GetComponent<RectTransform>().anchoredPosition.x;//Empty Health starts from HealthBar

        if (trigger && xAxis > emptyHealth)//If trigger is true - Health
        {
            xAxis -= 0.1f * Time.deltaTime * damageRate;
            healthBarEmpty.GetComponent<RectTransform>().anchoredPosition = new Vector2(xAxis, healthBarEmpty.GetComponent<RectTransform>().anchoredPosition.y);
        }

        if (healthBarEmpty.GetComponent<RectTransform>().anchoredPosition.x <= emptyHealth)//If Health is empty = Game End
        {
            gameOver.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Damage")//Dealing Damage to only objects tagged "Damage"
        {
            trigger = true;//If true deal damage
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Damage")//Dealing Damage to only objects tagged "Damage"
        {
            trigger = false;//If false do not deal damage
        }
    }
}