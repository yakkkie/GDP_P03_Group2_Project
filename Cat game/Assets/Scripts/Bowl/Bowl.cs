using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bowl : MonoBehaviour
{
    public float decreaseValue = 0.1f; // Speed of y-position decrease
    public abstract void FitInBowl();

    public void moveMesh()
    {
        transform.position -= Vector3.up * decreaseValue;
    }
}
