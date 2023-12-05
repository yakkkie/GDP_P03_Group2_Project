using UnityEngine;

public class UserInput : MonoBehaviour
{
    public LayerMask clickableLayer;
    public GameObject water;
    public GameObject food;
    public GameObject waterBowl;
    public GameObject foodBowl;

    public float startY = 0.12186f;


    private Vector3 foodPos;
    private Vector3 waterPos;


    private string foodString = "food";
    private string waterString = "water";




    public Camera camera;// This reference needs to be assigned in the Inspector


    //checks
    public bool placedWater;
    public bool placedFood;
    

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
                    if (!placedWater)
                    {
                        //refill the water bowl :D
                        SetLocation(waterString);
                        placedWater = true;

                    }
                    else
                    {
                        ResetLocation(waterString);
                        placedWater = false;
                    }
                    
                }

                if (clickedObject.CompareTag("Foodbowl"))
                {
                    if (!placedFood)
                    {
                        //refill the water bowl :D
                        SetLocation(foodString);
                        placedFood = true;
                    }
                    else
                    {
                        ResetLocation(foodString);
                        placedFood = false;
                    }
                }

                

            }
        }
    }


    private void ResetLocation(string S)
    {
        if (S == "food")
        {
            foodBowl.SetActive(false);
            foodBowl.transform.position = Vector3.zero;
            food.SetActive(false);
            food.transform.position = Vector3.zero;
        }

        if (S == "water")
        {
            waterBowl.SetActive(false);
            waterBowl.transform.position = Vector3.zero;
            water.SetActive(false);
            water.transform.position = Vector3.zero;
        }
    }


    private void SetLocation(string S)
    {
        if (S == "food")
        {
            foodPos = foodBowl.transform.position;
            foodPos.y = startY;
            food.transform.position = foodPos;
            food.SetActive(true);
        }

        if (S == "water")
        {
            waterPos = waterBowl.transform.position;
            waterPos.y = startY;

            water.transform.position = waterPos;

            water.SetActive(true);
        }
    }

}