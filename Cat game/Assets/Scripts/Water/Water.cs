using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    
    Vector3 originalScale;

    private void Awake()
    {
        
        originalScale = transform.localScale;
    }
    private void OnEnable()
    {
        
        transform.localScale = originalScale;
    }

  

    
}
