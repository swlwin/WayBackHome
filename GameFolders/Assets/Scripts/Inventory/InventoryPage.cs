using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryPage : MonoBehaviour
{
    [SerializeField] private UIItem itemPrefab;
    [SerializeField] private RectTransform contentPanel;

    List<UIItem> listOfItems = new List<UIItem>();

    public void InitInventory(int inventorySize)
    {
        for(int i = 0; i<inventorySize; i++)
        {
            UIItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel, false);
            listOfItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
        }
        
    }

    private void HandleItemSelection(UIItem obj)
    {
        Debug.Log(obj.name);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
