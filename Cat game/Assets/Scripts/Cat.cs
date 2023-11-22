using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    public float moveSpeed;
    public float hungerValue;
    public float thirstValue;
    public float poopooValue;

    public NavMeshAgent agent;
    public Transform mouseTrans;

    public CatFSM catFSM = new CatFSM();
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        catFSM.animator = GetComponent<Animator>();
        agent.speed = moveSpeed;
        agent.updateRotation = true;

        Walk();
    }

    public void Walk()
    {
        Vector3 targetDest = new(Random.Range(-13, 9), 0, Random.Range(1, 3));
        agent.SetDestination(targetDest);
        catFSM.ChangeState(catFSM.CatState_WALK);
    }

    private void Update()
    {
    
        agent.updateRotation = true;
        agent.SetDestination(mouseTrans.position);
        
    }
}
