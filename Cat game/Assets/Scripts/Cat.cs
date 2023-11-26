using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    public float moveSpeed;


    #region Stats
    public float MaxHealth;
    public float MaxHunger;
    public float MaxThirst;

    public float currentHealth;
    public float currentHunger;
    public float currentThirst;

    public float hungerDrainRate;
    public float thirstDrainRate;
    public float healthDrainRate;
    #endregion

    public Transform mouseTrans;
    public CatFSM catFSM;
    public CatStatusUIHandler uiHandler;

    Animator animator;
    NavMeshAgent agent;

    void Start()
    {
        #region Get Components
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        #endregion

        #region Set Values
        currentHealth = MaxHealth;
        currentHunger = MaxHunger;
        currentThirst = MaxThirst;
        #endregion

        catFSM = new(animator, agent);

        agent.speed = moveSpeed;
        agent.updateRotation = true;
        Walk();


        StartCoroutine(HungerDrain());
        StartCoroutine(ThirstDrain());
        StartCoroutine(HealthDrain());
    }

    private void Update()
    {
        //agent.SetDestination(mouseTrans.position);
        catFSM.Update();

        if (Input.GetKeyDown(KeyCode.A))
        {
            Walk();
        }
    }

    #region Status Logic
    public IEnumerator HungerDrain()
    {
        while(currentHunger > 0)
        {
            currentHunger -= hungerDrainRate;

            yield return new WaitForSeconds(1);
        }
    }

    public IEnumerator ThirstDrain()
    {
        while (currentThirst > 0)
        {
            currentThirst -= thirstDrainRate;

            yield return new WaitForSeconds(1);
        }
    }

    public IEnumerator HealthDrain()
    {
        while (currentHunger + currentThirst > 0)
        {
            currentHealth -= healthDrainRate;

            yield return new WaitForSeconds(1);
        }
    }


    #endregion

    #region Movement
    public void Walk()
    {
        Vector3 targetDest = Random.insideUnitSphere * 3f;
        targetDest += transform.position;

        NavMeshHit hit;
        NavMesh.SamplePosition(targetDest, out hit, 3f, 1);
        agent.SetDestination(hit.position);
        catFSM.ChangeState(catFSM.CatState_WALK);
    }

    #endregion
}
