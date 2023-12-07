using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDie : MonoBehaviour
{
    public Cat cat; // Reference to the Cat script
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        cat = GetComponent<Cat>(); // Fetch the Cat component
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cat.HealthDrain();// Reduce health over time for demonstration purposes

        if (cat.currentHealth < 0)
        {
            animator.SetBool("healthZero", true);
        }
        else
        {
            animator.SetBool("healthZero", false);
        }
    }
}

