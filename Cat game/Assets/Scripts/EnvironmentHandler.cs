using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnvironmentHandler : MonoBehaviour
{
    public Image dirtyBar;
    public Image cleanBar;
    public float maxDirtiness;
    public float curDirtiness;
    public float increaseRate = 1f; // Rate at which dirtiness increases per second
    public float decreaseAmount = 10f;
    public GameObject loseScreen;

    public Cat cat; // Reference to the Cat script

    public GameObject dirtPrefab;
    public List<GameObject> prefabs;
    public Dictionary<DirtyType, float> dirtValues;
    List<Dirt> dirtOnMap = new();

    public Text sickText; 

    float timer = 0;

    void Start()
    {
        curDirtiness = 0;
        dirtValues = new Dictionary<DirtyType, float>();
        dirtValues.Add(DirtyType.PEST, 5);
        dirtValues.Add(DirtyType.DIRT, 5);
        dirtValues.Add(DirtyType.FOODWASTE, 3);
        StartCoroutine(RandomSpawnDirt());
        loseScreen = GameObject.Find("Lose2");
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        CheckDirtiness();
        UpdateDirtyBar();
    }
    void UpdateDirtyBar()
    {
        dirtyBar.fillAmount = curDirtiness / maxDirtiness;
    }

    public void AdjustDirtiness()
    {
        curDirtiness = Mathf.Clamp(curDirtiness - decreaseAmount, 0f, maxDirtiness);

    }



    void SpawnDirt()
    {
        Vector3 randPos = new(Random.insideUnitCircle.x, 0, Random.insideUnitCircle.y);
        randPos += transform.position;
        //bool fit = NavMesh.SamplePosition(randPos, out NavMeshHit hit, 2, 0);
        int index = Random.Range(0, prefabs.Count);
        GameObject prefab = prefabs[index];
        Instantiate(prefab, randPos, Quaternion.identity);
    }

    void CheckDirtiness()
    {
        GameObject[] dirtObjects = GameObject.FindGameObjectsWithTag("Dirt");

         float dirtinessPercentage = curDirtiness / maxDirtiness;
        Debug.Log("Current dirtiness percentage: " + dirtinessPercentage);

        if (dirtinessPercentage >= 0.5f)
        {
            // Dirtiness exceeds 50%, set the sick flag in the Cat script
            if (cat != null)
            {
                cat.MakeSick();
                Debug.Log("Cat is getting sick!");
                sickText.gameObject.SetActive(true); // Show the sick text when the cat is sick
                cat.currentHealth -= cat.sickHealthDrainRate;
            }
        }

        if (dirtinessPercentage <= 0.5f)
        {
            sickText.gameObject.SetActive(false); // Show the sick text when the cat is sick
            Debug.Log("Cat is no longer sick");
            cat.currentHealth += cat.sickHealthDrainRate;
        }


        if (curDirtiness >= maxDirtiness)
        {
            loseScreen.SetActive(true);
        }
        else
        {
            loseScreen.SetActive(false);
        }

        foreach (GameObject dirtObj in dirtObjects)
        {
            Dirt dirt = dirtObj.GetComponent<Dirt>();
            AddToDirtOnMap(dirt);
        }
    }

    void AddToDirtOnMap(Dirt dirt)
    {
        if (dirtOnMap.Contains(dirt))
            return;

        curDirtiness += dirtValues[dirt.type];
        dirtOnMap.Add(dirt);
    }

    IEnumerator RandomSpawnDirt()
    {
        while (true)
        {
            if (timer >= 1)
            {
                timer = 0;
                SpawnDirt();
            }

            yield return new WaitForSeconds(0.2f);
            timer += 0.2f;
        }
    }

}

public enum DirtyType
{
    PEST,
    DIRT,
    FOODWASTE
}
