using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    private InventoryObject inventoryData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollectableItem item = collision.GetComponent<CollectableItem>();
        if (item != null)
        {
            int remainder = inventoryData.AddItem(item.InventoryItem, item.Quantity);
            if (remainder == 0)
                item.DestroyItem();
            else
                item.Quantity = remainder;
        }
    }
}
