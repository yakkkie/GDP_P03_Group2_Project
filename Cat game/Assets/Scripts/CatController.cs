using UnityEngine;
using UnityEngine.AI;

public class CatController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent catAgent;
    //private Animator anim;

    private void Start()
    {
        catAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //anim = GetComponent<Animator>();
    }

    public void MoveToDestination(Vector3 destination)
    {
        // Move the cat to the clicked destination
        catAgent.SetDestination(destination);

        // Set a parameter to trigger the walking animation
        //anim.SetBool("isWalking", true);
        //anim.SetBool("notWalking", false);
    }
}