using UnityEngine;

public class WaterDecreases : MonoBehaviour
{
    public GameObject bowl; // Reference to the bowl object
    public float decreaseSpeed = 0.1f; // Speed of y-position decrease
    public float scalingSpeed = 0.1f; // Speed of scaling

    private Vector3 originalScale;
    private Vector3 originalPosition;
    private bool isCollided = false;

    private void Start()
    {
        originalScale = transform.localScale;
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (isCollided && transform.position.y > bowl.transform.position.y)
        {
            // Decrease y-position
            transform.position -= Vector3.up * decreaseSpeed * Time.deltaTime;

            // Adjust scaling to fit within the bowl
            FitInsideBowl();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cat"))
        {
            isCollided = true;
        }
    }

    private void FitInsideBowl()
    {
        Vector3 bounds = bowl.GetComponent<Renderer>().bounds.size;
        Vector3 localScale = originalScale;

        // Calculate scaling factors to fit within the bowl
        float scaleX = bounds.x / localScale.x;
        float scaleY = bounds.y / localScale.y;
        float scaleZ = bounds.z / localScale.z;

        // Choose the minimum scale factor among all axes
        float minScale = Mathf.Min(scaleX, scaleY, scaleZ);

        // Apply scaling
        transform.localScale = originalScale * minScale * scalingSpeed * Time.deltaTime;
    }
}


