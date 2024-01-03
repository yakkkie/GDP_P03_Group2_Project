using UnityEngine;
using System.Collections;

public class PestSpawner : MonoBehaviour
{
    public GameObject mosquitoSpawn_1;
    public GameObject cockroachSpawn_1;
    public GameObject mosquitoSpawn_2;
    public GameObject cockroachSpawn_2;

    private bool bowlLeftOut;
    private Coroutine spawnCoroutine;

    public float spawnTime = 1800f; // Time in seconds (30 minutes)
    public float initialSpawnDelay = 10f; // Delay before pests start spawning

    public BowlConsume waterbowl;
    public BowlConsume foodbowl;

    void Start()
    {
        bowlLeftOut = false;
        spawnCoroutine = null;

        // Deactivate pests
        DeactivatePests();
    }

    void Update()
    {
        BowlLeftOut();
        
        // Check if the bowl has been left out
        if (bowlLeftOut && spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(ActivateSpawns());
            Debug.Log("COCK");
        }
    }


    IEnumerator ActivateSpawns()
    {
        // Delay before pests start spawning
        yield return new WaitForSeconds(initialSpawnDelay);

        // Instantiate Mosquito spawn_1 and Mosquito spawn_2
        GameObject mosquito1 = Instantiate(mosquitoSpawn_1, transform.position, Quaternion.identity);
        GameObject mosquito2 = Instantiate(mosquitoSpawn_2, transform.position, Quaternion.identity);

        // Instantiate Cockroach spawn_1 and Cockroach spawn_2
        GameObject cockroach1 = Instantiate(cockroachSpawn_1, transform.position, Quaternion.identity);
        GameObject cockroach2 = Instantiate(cockroachSpawn_2, transform.position, Quaternion.identity);

        // Wait for spawnTime
        yield return new WaitForSeconds(spawnTime);

        // Deactivate pests after spawning time
        Destroy(mosquito1);
        Destroy(cockroach2);
        Destroy(mosquito2);
        Destroy(cockroach1);

        // Reset the bowlLeftOut code to false
        bowlLeftOut = false;

        spawnCoroutine = null; // Reset the coroutine to null
    }

    // Deactivate all pests
    void DeactivatePests()
    {
        mosquitoSpawn_1.SetActive(false);
        cockroachSpawn_1.SetActive(false);
        mosquitoSpawn_2.SetActive(false);
        cockroachSpawn_2.SetActive(false);
    }

    // Call this method when the bowl is left out
    public void BowlLeftOut()
    {
        if(waterbowl.gameObject.active || foodbowl.gameObject.active)
            bowlLeftOut = true;
    }

    // Call this method to cancel the spawning if the bowl is no longer left out
    public void BowlNotLeftOut()
    {
        bowlLeftOut = false;
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
            // Deactivate pests if the coroutine is stopped early
            DeactivatePests();
        }
    }
}
