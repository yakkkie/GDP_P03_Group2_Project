using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Slider healthSlider;
    public Slider hungerSlider;
    public Slider thirstSlider;

    private float health = 1000f;
    private float hunger = 1000f;
    private float thirst = 1000f;

    private void Start()
    {
        // Assign the sliders in the Inspector.
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        hungerSlider = GameObject.Find("HungeSlider").GetComponent<Slider>();
        thirstSlider = GameObject.Find("ThirstSlider").GetComponent<Slider>();
    }

    private void UpdateSliders()
    {
        healthSlider.value = health;
        hungerSlider.value = hunger;
        thirstSlider.value = thirst;
    }

    private void DecreaseStats()
    {
        health -= 0.5f * Time.deltaTime;
        hunger -= 1f * Time.deltaTime;
        thirst -= 2f * Time.deltaTime;

        // Clamp values to ensure they stay within the 0-100 range.
        health = Mathf.Clamp(health, 0f, 100f);
        hunger = Mathf.Clamp(hunger, 0f, 100f);
        thirst = Mathf.Clamp(thirst, 0f, 100f);

        UpdateSliders();
    }

    private void IncreaseStats(float healthAmount, float hungerAmount, float thirstAmount)
    {
        health += healthAmount;
        hunger += hungerAmount;
        thirst += thirstAmount;

        // Clamp values to ensure they stay within the 0-100 range.
        health = Mathf.Clamp(health, 0f, 100f);
        hunger = Mathf.Clamp(hunger, 0f, 100f);
        thirst = Mathf.Clamp(thirst, 0f, 100f);

        UpdateSliders();
    }

    // Call this method when the player eats.
    private void Eat(float healthIncrease, float hungerIncrease)
    {
        IncreaseStats(healthIncrease, hungerIncrease, 5f); // Only applied when eating
    }

    // Call this method when the player drinks.
    private void Drink(float healthIncrease, float thirstIncrease)
    {
        IncreaseStats(healthIncrease, 5f, thirstIncrease); // Only applied when drinking
    }

    // You might call DecreaseStats when the player takes damage or consumes resources.
    private void Update()
    {
        DecreaseStats();
        UpdateSlidersPosition();
    }
    private void UpdateSlidersPosition()
    {
        //Set the position of each slider above the player's head.
        Vector3 offset = new Vector3(0f, 100f, 0f); // Adjust the offset.

        Vector3 playerPosition = transform.position;
        Vector3 healthSliderPosition = Camera.main.WorldToScreenPoint(playerPosition + offset + new Vector3(0f, 60f, 0f));
        Vector3 hungerSliderPosition = Camera.main.WorldToScreenPoint(playerPosition + offset + new Vector3(0f, 30f, 0f));
        Vector3 thirstSliderPosition = Camera.main.WorldToScreenPoint(playerPosition + offset + new Vector3(0f, 0f, 0f));

        healthSlider.transform.position = healthSliderPosition;
        hungerSlider.transform.position = hungerSliderPosition;
        thirstSlider.transform.position = thirstSliderPosition;
    }
}