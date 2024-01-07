using UnityEngine;
using System.Collections;

public class PestSpawner : MonoBehaviour
{
    public GameObject[] pestPrefabs;
    

    private bool bowlLeftOut;
    private Coroutine spawnCoroutine;

    public float spawnTime = 1800f; // Time in seconds (30 minutes)
    public float initialSpawnDelay = 10f; // Delay before pests start spawning

    public GameObject waterbowl;
    public GameObject foodbowl;

    void Start()
    {
        bowlLeftOut = false;
        spawnCoroutine = null;

        Debug.Log(pestPrefabs.Length);
       
       
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

        SpawnPests();

        // Wait for spawnTime
        yield return new WaitForSeconds(spawnTime);

        // Deactivate pests after spawning time
        

        // Reset the bowlLeftOut code to false
        bowlLeftOut = false;

        spawnCoroutine = null; // Reset the coroutine to null
    }

    // Call this method when the bowl is left out
    public void BowlLeftOut()
    {
        if(waterbowl.activeInHierarchy || foodbowl.activeInHierarchy)
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
            
            
        }
    }

    void SpawnPests()
    {
        Vector3 randPos = new(Random.insideUnitCircle.x, 0, Random.insideUnitCircle.y);
        randPos += transform.position;
        //bool fit = NavMesh.SamplePosition(randPos, out NavMeshHit hit, 2, 0);
        int index = Random.Range(0, pestPrefabs.Length);
        
        GameObject prefab = pestPrefabs[index];
        Instantiate(prefab, randPos, Quaternion.identity);
    }

}
