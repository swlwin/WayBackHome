using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryPage inventoryPage;
    public int inventorySize = 8;

    [SerializeField] private InventoryObject inventoryData;

    void Start()
    {
        InitInventoryPage();
        // inventoryData.Initialize();
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

    private void InitInventoryPage()
    {
        inventoryPage.InitInventory(inventoryData.Size);
        this.inventoryPage.OnDescriptionReq += HandleDescriptionReq;
        this.inventoryPage.OnItemActionReq += HandleItemActionReq;

    }

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

    private void HandleItemActionReq(int index)
    {

    }
    
}
