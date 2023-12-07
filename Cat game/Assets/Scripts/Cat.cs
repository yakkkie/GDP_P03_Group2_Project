using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour, IConsume
{
    public float moveSpeed;
    float timer;
    float timing;
    bool currentRoamComplete;
    bool isDead;

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

    public CatFSM catFSM;
    public CatStatusUIHandler uiHandler;
    public Transform foodBowlTrans;
    public Transform waterBowlTrans;


    //store the cat status and its priority
    public Dictionary<CatStatusName,CatStatus> catStatuses;
    public CatStatus currentPriority;
    Coroutine healthDrainCor;
    Coroutine hungerDrainCor;
    Coroutine thirstDrainCor;

    Animator animator;
    NavMeshAgent agent;

    void Start()
    {
        Initialize();
        isDead = false;
        hungerDrainCor = StartCoroutine(HungerDrain());
        thirstDrainCor = StartCoroutine(ThirstDrain());
    }

    private void Update()
    {
        catFSM.Update();

        if(timer > 3 && !isDead)
        {
            WalkRandomly();
            timer = 0;
        }

        if(currentHunger/MaxHunger < 0.5 || currentThirst/MaxThirst < 0.5)
        {
            if(healthDrainCor == null)
                healthDrainCor = StartCoroutine(HealthDrain());
        }
        else
        {
            if (healthDrainCor != null)
                StopCoroutine(healthDrainCor);
        }
            

        CheckFlags();
        CheckPriority();
        ExecutePriority();
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        catFSM.FixedUpdate();
    }

    #region Status Logic
    public IEnumerator HungerDrain()
    {
        while(currentHunger > 0)
        {
            currentHunger -= hungerDrainRate;
            currentHunger = Mathf.Clamp(currentHunger, 0, MaxHunger);
            yield return new WaitForSeconds(1);
        }
    } 
    
    public IEnumerator ThirstDrain()
    {
        while(currentThirst > 0)
        {
            currentThirst -= thirstDrainRate;
            currentThirst = Mathf.Clamp(currentThirst, 0, MaxThirst);
            yield return new WaitForSeconds(1);
        }
    }

    public IEnumerator HealthDrain()
    {
            float hungerInfluence = 1 / (currentHunger + 1);
            if (currentHunger / MaxHunger > 0.5)
                hungerInfluence = 0;

            float thirstInfluence = 1 / (currentThirst + 1);
            if (currentThirst / MaxThirst > 0.5)
                thirstInfluence = 0;

            float healthDrain = hungerInfluence + thirstInfluence;
            currentHealth -= healthDrain;
            currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);
            yield return new WaitForSeconds(1);
        

    }

    public void Consume(ConsumeType ct)
    {
        switch (ct)
        {
            case ConsumeType.FOOD:
                catFSM.ChangeState(catFSM.CatState_EAT);
                break;
            case ConsumeType.WATER:
                catFSM.ChangeState(catFSM.CatState_DRINK);
                break;
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
            Debug.Log(catStatuses[CatStatusName.HUNGRY].flag);
        }
        else if(!(currentHunger / MaxHunger < 0.5) && catStatuses[CatStatusName.HUNGRY].flag)
        {
            CatStatus s = catStatuses[CatStatusName.HUNGRY];
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
    public void WalkRandomly()
    {
        if (currentHealth > 0)
        {
            Vector3 targetDest = Random.insideUnitSphere * 3f;
            targetDest += transform.position;

            NavMeshHit hit;
            NavMesh.SamplePosition(targetDest, out hit, 3f, 1);
            MoveTowards(hit.position);
            catFSM.ChangeState(catFSM.CatState_WALK);
        }
        else
        {
            catFSM.Update();
            animator.SetBool("healthZero", true);
        }
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

    float GetRandomTiming()
    {
        return Random.Range(0f, 5f);
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

        catFSM = new(animator,agent,this);

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
        

        currentRoamComplete = true;
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
        SICK,
 
    }
}
