using UnityEngine;

public class UserInput : MonoBehaviour
{
    public LayerMask clickableLayer;
    public GameObject water;
    public GameObject food;
    public GameObject waterBowl;
    public GameObject foodBowl;


    private Vector3 foodBowlPos;
    private Vector3 waterBowlPos;



    public Camera camera;// This reference needs to be assigned in the Inspector


    //checks
    public bool holdingWaterBowl;
    public bool holdingFoodBowl;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

           
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
            {

                if (holdingFoodBowl && foodBowl != null)
                {
                    //foodBowlPos = hit.point;
                    //foodBowl.transform.position = foodBowlPos;
                    foodBowl.SetActive(true);

                    holdingFoodBowl = false;
                }
                else if (!holdingFoodBowl && !holdingWaterBowl)
                {
                    GameObject clickedObject = hit.collider.gameObject;

                    if (clickedObject.CompareTag("Waterbowl"))
                    {
                        //refill the water bowl :D
                        water.SetActive(true);
                    }

                    if (clickedObject.CompareTag("Foodbowl"))
                    {
                        //refill the water bowl :D
                        food.SetActive(true);
                    }
                }

            }
        }
    }

}