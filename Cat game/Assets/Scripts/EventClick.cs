using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private bool canInteract = false;

    public void OnPointerDown(PointerEventData eventData)
    {
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (canInteract)
        {
            HandleClick();
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    private void HandleClick()
    {
        // Implement logic for the click
        Debug.Log("Cockroach clicked!");

        // Add more logic here, such as destroying the cockroach GameObject
        Destroy(gameObject);
    }

    public void SetCanInteract(bool value)
    {
        canInteract = value;
    }
}
