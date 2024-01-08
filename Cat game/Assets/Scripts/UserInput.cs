using UnityEngine;

public class UserInput : MonoBehaviour
{
    public LayerMask clickableLayer;
    public GameObject water;
    public GameObject food;
    public GameObject waterBowl;
    public GameObject foodBowl;
    public GameObject faeces;
    private EnvironmentHandler environmentHandler;

    public float startY = 0.096f;


    private Vector3 foodPos;
    private Vector3 waterPos;


    private string foodString = "food";
    private string waterString = "water";
    private string faecesString = "faeces";




    public Camera camera;// This reference needs to be assigned in the Inspector


    //checks
    public bool placedWater;
    public bool placedFood;

    void Start()
    {
        GameObject environmentObject = GameObject.Find("EnvironmentHandler");
        if (environmentObject != null)
        {
            environmentHandler = environmentObject.GetComponent<EnvironmentHandler>();
        }
        faeces.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

           
            if (Physics.Raycast(ray, out hit, 30f, clickableLayer))
            {

                
                GameObject clickedObject = hit.collider.gameObject;

                Debug.Log(clickedObject.tag);

                if (clickedObject.CompareTag("Waterbowl"))
                {
                    ResetLocation(waterString);

                }

                if (clickedObject.CompareTag("Foodbowl"))
                {
                    ResetLocation(foodString);
                }

                if (hit.collider.CompareTag("Dirt"))
                {
                    Despawns(faecesString);
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
            
            Vector3 foodPos = new(0,startY,0);
            food.transform.position = foodPos;
        }

        if (S == "water")
        {
            waterBowl.SetActive(false);
            waterBowl.transform.position = Vector3.zero;
            
            Vector3 waterPos = new(0, startY, 0);
            water.transform.position = waterPos;
        }


    }
    private void Despawns(string S)
    {
        if (S == "faeces")
        {


            if (faeces.activeSelf)
            {
                GameObject[] faecesObjects = GameObject.FindGameObjectsWithTag("Dirt");

                foreach (GameObject faecesObj in faecesObjects)
                {
                    if (faecesObj.activeSelf)
                    {
                        faecesObj.SetActive(false);
                        Debug.Log("Deactivated a faeces");

                        // Pass the fillAmountDifference to AdjustDirtiness
                        environmentHandler.AdjustDirtiness();
                    }
                }
            }
            else
            {
                faeces.SetActive(true);
                environmentHandler.Update();
            }
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

    private void clearBowls(string S)
    {

    }


}