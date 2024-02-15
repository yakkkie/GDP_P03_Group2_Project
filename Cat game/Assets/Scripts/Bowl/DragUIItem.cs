using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUIItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    GameObject PrefabToInstantiate;

    [SerializeField]
    RectTransform UIDragElement;

    [SerializeField]
    RectTransform Canvas;

    [SerializeField]
    LayerMask clickableLayer;

    [SerializeField]
    Inventory inventory;

    public bool pestItems;

    public Camera camera;

    private CameraMovementController cameraController;
    private Vector2 mOriginalLocalPointerPosition;
    private Vector3 mOriginalPanelLocalPosition;
    private Vector2 mOriginalPosition;

    private void Start()
    {
        mOriginalPosition = UIDragElement.localPosition;
        cameraController = Camera.main.GetComponent<CameraMovementController>();
    }

    public void OnBeginDrag(PointerEventData data)
    {
        // Check if the item is a swatter
        if (gameObject.CompareTag("Swatter"))
        {
            // Check if the swatter's quantity is greater than 0
            int swatterQuantity = inventory.GetItemQuantity(1); // Assuming swatter's itemID is 1
            if (swatterQuantity <= 0)
            {
                return; // Skip drag operation if the quantity is 0
            }
        }
        
        mOriginalPanelLocalPosition = UIDragElement.localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            Canvas,
            data.position,
            data.pressEventCamera,
            out mOriginalLocalPointerPosition);

        // Disable camera movement when dragging starts
        if (cameraController != null)
        {
            cameraController.enabled = false;
        }
    }


    public void OnDrag(PointerEventData data)
    {
        // Check if the item is a swatter
        if (gameObject.CompareTag("Swatter"))
        {
            // Check if the swatter's quantity is greater than 0
            int swatterQuantity = inventory.GetItemQuantity(1); // Assuming swatter's itemID is 1
            if (swatterQuantity <= 0)
            {
                return; // Skip drag operation if the quantity is 0
            }
        }

        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            Canvas,
            data.position,
            data.pressEventCamera,
            out localPointerPosition))
        {
            Vector3 offsetToOriginal =
                localPointerPosition -
                mOriginalLocalPointerPosition;
            UIDragElement.localPosition =
                mOriginalPanelLocalPosition +
                offsetToOriginal;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Check if the item is a swatter
        if (gameObject.CompareTag("Swatter"))
        {
            // Check if the swatter's quantity is greater than 0
            int swatterQuantity = inventory.GetItemQuantity(1); // Assuming swatter's itemID is 1
            if (swatterQuantity <= 0)
            {
                return; // Skip drag operation if the quantity is 0
            }
        }
        
        // Enable camera movement when dragging ends
        if (cameraController != null)
        {
            cameraController.enabled = true;
        }

        StartCoroutine(Coroutine_MoveUIElement(UIDragElement, mOriginalPosition, 0.5f));

        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 30f, clickableLayer))
        {
            // If the swatter is dragged onto pests
            if (pestItems)
            {
                // Destroy the pest
                Destroy(hit.collider.gameObject);

                // Use a swatter from the inventory
                inventory.UseItem(1); // Assuming swatter's itemID is 1
            }
            else
            {
                // Create an object at the hit point
                CreateObject(hit.point);
            }
        }
    }

    public IEnumerator Coroutine_MoveUIElement(RectTransform r, Vector2 targetPosition, float duration = 0.1f)
    {
        float elapsedTime = 0;
        Vector2 startingPos = r.localPosition;
        while (elapsedTime < duration)
        {
            r.localPosition =
                Vector2.Lerp(
                    startingPos,
                    targetPosition,
                    (elapsedTime / duration));

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        r.localPosition = targetPosition;
    }

    public void CreateObject(Vector3 position)
    {
        if (PrefabToInstantiate == null)
        {
            Debug.Log("No prefab to instantiate");
            return;
        }

        if (PrefabToInstantiate.activeInHierarchy)
        {
            Debug.Log("cock");
            return;
        }

        Debug.Log("Work");
        PrefabToInstantiate.transform.position = position;
        PrefabToInstantiate.SetActive(true);
    }
}
