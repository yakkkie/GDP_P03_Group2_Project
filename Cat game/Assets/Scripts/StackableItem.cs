using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StackableItem : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public int maxStackSize = 10;

    [SerializeField]
    private int initialQuantity = 0;

    [SerializeField]
    private Text quantityText; // Reference to a UI Text component

    private int quantity = 0;

    public int Quantity
    {
        get { return quantity; }
    }

    private void Start()
    {
        // Initialize the stackable item when the GameObject is created
        AddToStackOnStart(initialQuantity);
        UpdateQuantityUI();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        HandleItemClick();
    }

    private void HandleItemClick()
    {
        // Implement your item usage logic here
        UseItem();
    }

    public bool AddToStack(int amount = 1)
    {
        if (quantity < maxStackSize)
        {
            quantity += amount;
            UpdateQuantityUI();
            Debug.Log($"Added {amount} {itemName}(s) to the stack. Total: {quantity}");
            return true;
        }
        else
        {
            Debug.Log($"Stack full for {itemName}.");
            return false;
        }
    }

    public bool UseItem(int amount = 1)
    {
        if (quantity >= amount)
        {
            quantity -= amount;
            UpdateQuantityUI();

            if (quantity <= 0)
            {
                // Disable the GameObject when quantity reaches 0
                gameObject.SetActive(false);
                // Clear or disable the UI text
                if (quantityText != null)
                {
                    quantityText.text = "";
                    quantityText.enabled = false;
                }
            }
            Debug.Log($"Used {amount} {itemName}(s). Remaining: {quantity}");
            return true;
        }
        else
        {
            Debug.Log($"Not enough {itemName}.");
            return false;
        }
    }

    private void AddToStackOnStart(int startQuantity)
    {
        if (startQuantity > 0)
        {
            AddToStack(startQuantity);
        }
    }

    private void UpdateQuantityUI()
    {
        if (quantityText != null)
        {
            if (quantity > 0)
            {
                quantityText.text = $"{quantity}";
                quantityText.enabled = true;
            }
            else
            {
                quantityText.text = "";
                quantityText.enabled = false;
            }
        }
    }
}
