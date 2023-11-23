using UnityEngine;

public class UserInput : MonoBehaviour
{
    public LayerMask clickableLayer;
    public CatController catController;
    public Camera camera;// This reference needs to be assigned in the Inspector

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (catController != null) // Check if the reference is null before using it
                {
                    // Pass the position of the clicked object to the cat controller script
                    catController.MoveToDestination(clickedObject.transform.position);
                }
                else
                {
                    Debug.LogError("CatController reference is not assigned!");
                }
            }
        }
    }
}