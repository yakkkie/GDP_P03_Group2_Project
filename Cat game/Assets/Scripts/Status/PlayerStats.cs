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
        // Assign the sliders in the Inspector or via code.
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

    // Call this method when the player eats or drinks.
    private void EatDrink()
    {
        IncreaseStats(10f, 20f, 15f); // Adjust the amounts based on your game design.
    }

    // You might call DecreaseStats based on your game logic, e.g., when the player takes damage or consumes resources.
    private void Update()
    {
        DecreaseStats();
    }
}