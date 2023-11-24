using UnityEngine;

public class UserInput : MonoBehaviour
{
    public LayerMask clickableLayer;
    public GameObject water;
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

                if (clickedObject.CompareTag("Waterbowl"))
                {
                    //refill the water bowl :D
                    water.SetActive(true);
                }

                
            }
        }
    }
}