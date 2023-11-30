using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBowl : Bowl
{
    public GameObject bowl; // Reference to the bowl object
    
    private bool isCollided = false;
    public AnimationCurve animationCurve;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (isCollided && transform.position.y > bowl.transform.position.y)
        {
            // Decrease y-position
            moveMesh();
            Debug.Log(transform.position.y);
            // Adjust scaling to fit within the bowl
            FitInBowl();
            Debug.Log("COLLIDED :D:D:D:D::D");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Decrease y-position
            moveMesh();
            Debug.Log(transform.position.y);
            // Adjust scaling to fit within the bowl
            FitInBowl(); 
            Debug.Log("COLLIDED :D:D:D:D::D");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cat"))
        {
            isCollided = true;
        }
    }

    public override void FitInBowl()
    {


        Vector3 localScale = transform.localScale;

        localScale.x = animationCurve.Evaluate(transform.position.y);
        localScale.z = animationCurve.Evaluate(transform.position.y);

        transform.localScale = localScale;
        isCollided = false;


        if (transform.position.y < 0.102f)
        {
            this.gameObject.SetActive(false);
        }
    }
}
