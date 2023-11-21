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
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        agent.updateRotation = true;

        Walk();
    }

    public void Walk()
    {
        Vector3 targetDest = new(Random.Range(-4, 4), 0, Random.Range(-4, 4));
        agent.SetDestination(new(-0.25f,0.5f,-0.07f));
        
    }

    private void Update()
    {
        agent.SetDestination(mouseTrans.position);
    }
}
