using UnityEngine;

public class BowlConsume : MonoBehaviour
{
    public ConsumeType ct;
    public GameObject bowl; // Reference to the bowl object
    public float decreaseValue = 0.1f; // Speed of y-position decrease
    public float scalingSpeed = 0.1f; // Speed of scaling

    private Vector3 originalScale;
    private Vector3 originalPosition;
    private bool isCollided = false;
    public AnimationCurve animationCurve;
    Cat cat;

    private void Start()
    {
        originalScale = transform.localScale;
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (isCollided && transform.position.y > bowl.transform.position.y)
        {
            Decrease();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Decrease y-position
            transform.position -= Vector3.up * decreaseValue;
            Debug.Log(transform.position.y);
            // Adjust scaling to fit within the bowl
            FitInsideBowl();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cat"))
        {
            cat = other.GetComponent<Cat>();
            isCollided = true;           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cat"))
        {
            cat = null;
            isCollided = false;
        }
    }

    private void FitInsideBowl()
    {
        //Vector3 bounds = bowl.GetComponent<Renderer>().bounds.size;
        //Vector3 localScale = originalScale;

        //// Calculate scaling factors to fit within the bowl
        //float scaleX = bounds.x / localScale.x;
        //float scaleY = bounds.y / localScale.y;
        //float scaleZ = bounds.z / localScale.z;

        //// Choose the minimum scale factor among all axes
        //float minScale = Mathf.Min(scaleX, scaleY, scaleZ);

        //// Apply scaling
        //transform.localScale = originalScale * minScale * scalingSpeed * Time.deltaTime;

        Vector3 localScale = originalScale;

        localScale.x = animationCurve.Evaluate(transform.position.y);
        localScale.z = animationCurve.Evaluate(transform.position.y);

        Debug.Log(transform.position.y);
        transform.localScale = localScale;
        isCollided = false;


        if (transform.position.y < 0.02f)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Decrease()
    {
        // Decrease y-position
        transform.position -= Vector3.up * decreaseValue;
        Debug.Log(transform.position.y);

        // Adjust scaling to fit within the bowl
        FitInsideBowl();
        cat.Consume(this.ct);
    }
}

public enum ConsumeType
{
    FOOD,
    WATER
}

public interface IConsume
{
    void Consume(ConsumeType ct);
}


