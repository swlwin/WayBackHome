using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryPage inventoryPage;
    public int inventorySize = 8;

    void Start()
    {
        inventoryPage.InitInventory(inventorySize);
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
            }
        }
    }
}
