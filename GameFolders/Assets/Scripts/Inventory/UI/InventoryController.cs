using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryPage inventoryPage;
    // public int inventorySize = 8;

    [SerializeField] private InventoryObject inventoryData;

    public List<InventoryItem> initialItem = new List<InventoryItem>();

    void Start()
    {
        PrepareUI();
        PrepareInventoryData();

        // InitInventoryPage();
        // inventoryData.Initialize();
    }

    private void PrepareUI()
    {
        inventoryPage.InitializeInventoryUI(inventoryData.Size);
        inventoryPage.OnDescriptionReq += HandleDescriptionReq;
        inventoryPage.OnItemActionReq += HandleItemActionReq;
    }

    private void PrepareInventoryData()
    {
        inventoryData.Initialize();
        inventoryData.OnInventoryUpdated += UpdateInventoryUI;
        foreach (InventoryItem item in initialItem)
        {
            if (item.isEmpty)
                continue;
            inventoryData.AddItem(item);
        }
    }

    private void HandleItemActionReq(int itemIndex)
    {
        InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.isEmpty)
            return;

        IItemAction itemAction = inventoryItem.item as IItemAction;
        if(itemAction != null)
        {
            itemAction.PerformAction(gameObject);
        }

        IDestroyableItem destroyableItem = inventoryItem.item as IDestroyableItem;
        if (destroyableItem != null)
        {
            inventoryData.RemoveItem(itemIndex, 1);
        }
    }

    private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
    {
        inventoryPage.ResetAllItems();
        foreach (var item in inventoryState)
        {
            inventoryPage.UpdateData(item.Key, item.Value.item.ItemImg, 
                item.Value.quantity);
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryPage.isActiveAndEnabled == true)
            {
                inventoryPage.Hide();
            }
            else
            {
                inventoryPage.Show();
                foreach (var item in inventoryData.GetCurrentInventoryState())
                {
                    inventoryPage.UpdateData(item.Key, item.Value.item.ItemImg, item.Value.quantity);
                }
            }
        }
    }

    // private void InitInventoryPage()
    // {
    //     inventoryPage.InitInventory(inventoryData.Size);
    //     this.inventoryPage.OnDescriptionReq += HandleDescriptionReq;
    //     this.inventoryPage.OnItemActionReq += HandleItemActionReq;

    // }

    private void HandleDescriptionReq(int index)
    {
        InventoryItem inventoryItem = inventoryData.GetItemAt(index);
        if(inventoryItem.isEmpty)
        {
            inventoryPage.ResetSelection();
            return;
        }
        ItemObject item = inventoryItem.item;
        inventoryPage.UpdateDescription(index, item.ItemImg, item.Name, item.Description);
    } 
    
}
