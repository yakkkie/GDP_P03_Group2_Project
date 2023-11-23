using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    public float moveSpeed;

    //test edit
    #region Stats
    public float MaxHealth;
    public float MaxHunger;
    public float MaxThirst;

    public float currentHealth;
    public float currentHunger;
    public float currentThirst;

    public float hungerDrainRate;
    public float thirstDrainRate;
    #endregion

    public Transform mouseTrans;
    public CatFSM catFSM;
    public CatStatusUIHandler uiHandler;
    public Transform foodBowlTrans;
    public Transform waterBowlTrans;


    //store the cat status and its priority
    public Dictionary<CatStatusName,CatStatus> catStatuses;
    public CatStatus currentPriority;
    

    Animator animator;
    NavMeshAgent agent;

    void Start()
    {
        Initialize();

        Walk();

        StartCoroutine(HungerDrain());
    }

    private void Update()
    {
        //agent.SetDestination(mouseTrans.position);
        catFSM.Update();

        if (Input.GetKeyDown(KeyCode.A))
        {
            Walk();
        }

        CheckFlags();
        CheckPriority();
        ExecutePriority();
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

    public void CheckPriority()
    {
        CatStatus highestPriority = catStatuses[CatStatusName.IDLE];
        foreach(var item in catStatuses.Values)
        {


            if(item.priority > highestPriority.priority && item.flag)
            {
                Debug.Log("priority switched");
                highestPriority = item;
            }
        }

        currentPriority = highestPriority;
        Debug.Log(currentPriority.statusName.ToString());

    }

    public void CheckFlags()
    {
        ///check if cat is hungry or not hungry
        if(currentHunger/MaxHunger < 0.5 && !catStatuses[CatStatusName.HUNGRY].flag)
        {
            CatStatus s = catStatuses[CatStatusName.HUNGRY];
            s.flag = true;
            catStatuses[CatStatusName.HUNGRY] = s;
            Debug.Log("cat is hungry");
            Debug.Log(catStatuses[CatStatusName.HUNGRY].flag);
        }
        else if(!(currentHunger / MaxHunger < 0.5) && catStatuses[CatStatusName.HUNGRY].flag)
        {
            CatStatus s = catStatuses[CatStatusName.HUNGRY];
            Debug.Log("cat is NOT hungry");
            s.flag = false;
            catStatuses[CatStatusName.HUNGRY] = s;
        }

        //check if cat is thirsty or not thirst
        if(currentThirst/MaxThirst < 0.5 && !catStatuses[CatStatusName.THIRSTY].flag)
        {
            CatStatus s = catStatuses[CatStatusName.THIRSTY];
            s.flag = true;
            catStatuses[CatStatusName.THIRSTY] = s;
        }
        else if (!(currentThirst / MaxThirst < 0.5) && catStatuses[CatStatusName.THIRSTY].flag)
        {
            CatStatus s = catStatuses[CatStatusName.THIRSTY];
            s.flag = false;
            catStatuses[CatStatusName.THIRSTY] = s;
        }


        //check if cat is sick or not sick
        if(currentHealth/MaxHealth < 0.5 && !catStatuses[CatStatusName.SICK].flag)
        {
            CatStatus s = catStatuses[CatStatusName.SICK];
            s.flag = true;
            catStatuses[CatStatusName.SICK] = s;
        }
        else if (!(currentHealth / MaxHealth < 0.5) && catStatuses[CatStatusName.SICK].flag)
        {
            CatStatus s = catStatuses[CatStatusName.SICK];
            s.flag = false;
            catStatuses[CatStatusName.SICK] = s;
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

    public void MoveTowards(Vector3 target)
    {
        agent.SetDestination(target);
    }

    public void ExecutePriority()
    {
        switch (currentPriority.statusName)
        {
            case (CatStatusName.IDLE):
                //move randomly


                break;
            case (CatStatusName.HUNGRY):
                //move to food bowl

                Debug.Log("going food");
                MoveTowards(foodBowlTrans.position);
                break;
            case (CatStatusName.THIRSTY):
                //move to water

                Debug.Log("going water");
                MoveTowards(waterBowlTrans.position);

                break;
            case (CatStatusName.SICK):
                //not sure yet


                break;
        }
    }

    void GetRandomRoam()
    {

        Vector3 targetDest = Random.insideUnitSphere * 3f;

    }
    #endregion



    private void Initialize()
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

        catStatuses = new();
        CatStatus idle = new(CatStatusName.IDLE, -1);
        CatStatus hungry = new(CatStatusName.HUNGRY, 0);
        CatStatus thirsty = new(CatStatusName.THIRSTY, 1);
        CatStatus sick = new(CatStatusName.SICK, 2);

        catStatuses.Add(CatStatusName.IDLE,idle);
        catStatuses.Add(CatStatusName.HUNGRY, hungry);
        catStatuses.Add(CatStatusName.THIRSTY, thirsty);
        catStatuses.Add(CatStatusName.SICK, sick);

    }

    public struct CatStatus
    {
        public  int priority;
        public CatStatusName statusName;
        public bool flag;

        public CatStatus(CatStatusName name, int prio)
        {
            statusName = name;
            priority = prio;
            flag = false;
        }
    }

    public enum CatStatusName
    {
        IDLE,
        HUNGRY,
        THIRSTY,
        SICK
    }
}
