using UnityEngine;
using System.Collections;

public class PestSpawner : MonoBehaviour
{
    public GameObject mosquitoSpawn_1;
    public GameObject cockroachSpawn_1;
    public GameObject mosquitoSpawn_2;
    public GameObject cockroachSpawn_2;

    void Start()
    {
        StartCoroutine(ActivateSpawns());
/*        mosquitoSpawn_1.SetActive(true);
        cockroachSpawn_2.SetActive(true);
        mosquitoSpawn_2.SetActive(true);
        cockroachSpawn_1.SetActive(true);*/
    }

    IEnumerator ActivateSpawns()
    {
        yield return new WaitForSeconds(10f); // Wait for 10 seconds

        // Activate Mosquito spawn_1 and Cockroach spawn_2
        mosquitoSpawn_1.SetActive(true);
        cockroachSpawn_2.SetActive(true);

        yield return new WaitForSeconds(5f); // Wait for 5 seconds

        // Activate Mosquito spawn_2 and Cockroach spawn_1
        mosquitoSpawn_2.SetActive(true);
        cockroachSpawn_1.SetActive(true);

    }


}
