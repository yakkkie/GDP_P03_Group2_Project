using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class EnvironmentHandler : MonoBehaviour
{
    public Image dirtyBar;
    public Image cleanBar;
    public float maxDirtiness;
    public float curDirtiness;
    private float offsetAmount = 0.1f;

    public GameObject dirtPrefab;
    public List<GameObject> prefabs;
    public Dictionary<DirtyType, float> dirtValues;
    List<Dirt> dirtOnMap = new();

    float timer = 0;

    void Start()
    {
        curDirtiness = 0;
        dirtValues = new();
        dirtValues.Add(DirtyType.PEST,5);
        dirtValues.Add(DirtyType.DIRT, 5);
        dirtValues.Add(DirtyType.FOODWASTE, 3);
        StartCoroutine(RandomSpawnDirt());
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
        float currentFillAmount = curDirtiness / maxDirtiness;
        dirtyBar.fillAmount = Mathf.Clamp(currentFillAmount - offsetAmount, 0f, 1f);
    }



    void SpawnDirt()
    {
        Vector3 randPos = new( Random.insideUnitCircle.x,0,Random.insideUnitCircle.y);
        randPos += transform.position;
        //bool fit = NavMesh.SamplePosition(randPos, out NavMeshHit hit, 2, 0);
        int index = Random.Range(0, prefabs.Count);
        GameObject prefab = prefabs[index];
        Instantiate(prefab, randPos, Quaternion.identity);
    }

    void CheckDirtiness()
    {
        GameObject[] dirtObjects = GameObject.FindGameObjectsWithTag("Dirt");

        foreach(GameObject dirtObj in dirtObjects)
        {
            Dirt dirt = dirtObj.GetComponent<Dirt>();
            AddToDirtOnMap(dirt);
        }

        if(curDirtiness >= maxDirtiness)
        {
            //lose game
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
