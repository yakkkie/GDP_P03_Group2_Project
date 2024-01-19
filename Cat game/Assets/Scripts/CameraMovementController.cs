using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    public float swipeRotationSpeed = 2.0f;
    public Transform cat;
    public Camera camera;
    private float rotationSmoothness = 5.0f;
    private float minRotationY = -64f;   // Set minimum Y rotation limit
    private float maxRotationY = -28f;   // Set maximum Y rotation limit

    private Vector2 touchStartPos;
    private bool isSwiping = false;
    private float targetRotationY;


    public GameHandler gameHandler;
    private float time;


    void Start()
    {
        // Initialize the targetRotationY with the current Y rotation of the camera
        //targetRotationY = -60.883f;

    }

    void Update()
    {
        time = gameHandler.timePassed;

        if (time >= 5)
        {

            HandleSwipeInput();
            // SmoothRotation();
        }

        else
        {
            targetRotationY = transform.rotation.eulerAngles.y;
            AutoRotation();

        }


    }

    void HandleSwipeInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Moved:
                    if (isSwiping)
                    {
                        Vector2 distance = touch.position - touchStartPos;
                        float swipeValue = distance.x / Screen.width;

                        // Adjust target rotation based on swipe
                        targetRotationY = Mathf.Clamp(targetRotationY - swipeValue * swipeRotationSpeed,
                                                      minRotationY, maxRotationY);

                        transform.rotation = Quaternion.Euler(20.589f, targetRotationY, 1.753f);

                        Debug.Log("lol" + "\n" + transform.eulerAngles.y);

                        touchStartPos = touch.position;
                    }
                    break;

                case TouchPhase.Ended:
                    isSwiping = false;
                    break;
            }
        }
    }

    //need this to prevent the camera rotation from jumping stuttering
    void SmoothRotation()
    {
        // Smoothly rotate the camera towards the target rotation
        float smoothedRotationY = Mathf.LerpAngle(transform.eulerAngles.y, targetRotationY, rotationSmoothness * Time.deltaTime);
        transform.rotation = Quaternion.Euler(20.589f, smoothedRotationY, 1.753f);
    }

    void AutoRotation()
    {

        transform.LookAt(cat);
    }
}

