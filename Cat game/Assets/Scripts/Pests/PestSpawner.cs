using UnityEngine;
using System.Collections;

public class PestSpawner : MonoBehaviour
{
    public GameObject mosquitoSpawn_1;
    public GameObject cockroachSpawn_1;
    public GameObject mosquitoSpawn_2;
    public GameObject cockroachSpawn_2;

    private bool bowlLeftOut;
    private float timeLeftOut;

    void Start()
    {
        bowlLeftOut = false;
        timeLeftOut = 0f;
    }

    void Update()
    {
        if (bowlLeftOut)
        {
            timeLeftOut += Time.deltaTime;

            // Check if the bowl has been left out for 30 minutes
            if (timeLeftOut >= 1800f) // 1800 seconds = 30 minutes
            {
                SpawnPests();
                bowlLeftOut = false; // Reset the timer
            }
        }
    }

    void SpawnPests()
    {
        // Activate Mosquito spawn_1 and Cockroach spawn_2
        mosquitoSpawn_1.SetActive(true);
        cockroachSpawn_2.SetActive(true);

        // Activate Mosquito spawn_2 and Cockroach spawn_1
        mosquitoSpawn_2.SetActive(true);
        cockroachSpawn_1.SetActive(true);
    }

    // Call this method when the bowl is left out
    public void BowlLeftOut()
    {
        bowlLeftOut = true;
    }
}
