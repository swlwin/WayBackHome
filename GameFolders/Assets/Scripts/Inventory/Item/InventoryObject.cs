using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class InventoryObject : ScriptableObject
{
    [SerializeField] private List<InventoryItem> inventoryItems;

    [field: SerializeField] public int Size {get; private set;} = 8;

    public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;

    public void Initialize()
    {
        inventoryItems = new List<InventoryItem>();
        for(int i = 0; i< Size; i++)
        {
            inventoryItems.Add(InventoryItem.GetEmptyItem());
        }
    }

    private void InformAboutChange()
    {
        OnInventoryUpdated?.Invoke(GetCurrentInventoryState());
    }

    public int AddItem(ItemObject item, int quantity)
    {
        quantity = AddStackableItem(item, quantity);
        InformAboutChange();
        return quantity;
    }

    public void AddItem(InventoryItem item)
    {
        AddItem(item.item, item.quantity);
    }

    public void RemoveItem(int itemIndex, int amount)
    {
        if (inventoryItems.Count > itemIndex)
        {
            if (inventoryItems[itemIndex].isEmpty)
                return;
            int remainder = inventoryItems[itemIndex].quantity - amount;
            if (remainder <= 0)
                inventoryItems[itemIndex] = InventoryItem.GetEmptyItem();
            else
                inventoryItems[itemIndex] = inventoryItems[itemIndex]
                    .ChangeQuantity(remainder);

            InformAboutChange();
        }
    }

    private int AddStackableItem(ItemObject item, int quantity)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].isEmpty)
                    continue;
                if(inventoryItems[i].item.ID == item.ID)
                {
                    int amountPossibleToTake =
                        inventoryItems[i].item.MaxCount - inventoryItems[i].quantity;

                    if (quantity > amountPossibleToTake)
                    {
                        inventoryItems[i] = inventoryItems[i]
                            .ChangeQuantity(inventoryItems[i].item.MaxCount);
                        quantity -= amountPossibleToTake;
                    }
                    else
                    {
                        inventoryItems[i] = inventoryItems[i]
                            .ChangeQuantity(inventoryItems[i].quantity + quantity);
                        InformAboutChange();
                        return 0;
                    }
                }
            }
            while(quantity > 0 && IsInventoryFull() == false)
            {
                int newQuantity = Mathf.Clamp(quantity, 0, item.MaxCount);
                quantity -= newQuantity;
                AddItemToFirstFreeSlot(item, newQuantity);
            }
            return quantity;
    }

    private int AddItemToFirstFreeSlot(ItemObject item, int quantity)
    {
        InventoryItem newItem = new InventoryItem
        {
            item = item,
            quantity = quantity,
            
        };

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].isEmpty)
            {
                inventoryItems[i] = newItem;
                return quantity;
            }
        }
        return 0;
    }

    private bool IsInventoryFull() => inventoryItems.Where(item => item.isEmpty).Any() == false;

    public Dictionary<int, InventoryItem> GetCurrentInventoryState()
    {
        Dictionary<int, InventoryItem> returnVal = new Dictionary<int, InventoryItem>();
        for (int i = 0; i< inventoryItems.Count; i++)
        {
            if(inventoryItems[i].isEmpty)
                continue;
            returnVal[i] = inventoryItems[i]; 
        }
        return returnVal;
    } 

    public InventoryItem GetItemAt(int index)
    {
        return inventoryItems[index];
    }
}

[Serializable] public struct InventoryItem
{
    public int quantity;
    public ItemObject item;
    public bool isEmpty => item == null;

    public InventoryItem ChangeQuantity(int newQuantity)
    {
        return new InventoryItem
        {
            item = this.item,
            quantity = newQuantity,
        };
    }

    public static InventoryItem GetEmptyItem() => new InventoryItem
    {
        item = null,
        quantity = 0,
    };

}
