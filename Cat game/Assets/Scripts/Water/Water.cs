using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    Vector3 originalPos;
    Vector3 originalScale;

    private void Awake()
    {
        originalPos = transform.position;
        originalScale = transform.localScale;
    }
    private void OnEnable()
    {
        transform.position = originalPos;
        transform.localScale = originalScale;
    }

  

    
}
