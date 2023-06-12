using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPage : MonoBehaviour
{
    [SerializeField] private UIItem itemPrefab;
    [SerializeField] private RectTransform contentPanel;
    [SerializeField] private InventoryDescription itemDesc;

    public event Action<int> OnDescriptionReq, OnItemActionReq;
    
    List<UIItem> listOfItems = new List<UIItem>();

    private void Awake()
    {
        Hide();
        itemDesc.ResetDescription();
    }

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

    public void UpdateData(int index, Sprite itemImg, int itemQuan)
    {
        if(listOfItems.Count > index)
        {
            listOfItems[index].SetData(itemImg, itemQuan);
        }
    }

    internal void UpdateDescription(int index, Sprite itemImage, string name, string description)
    {
        itemDesc.SetDescription(itemImage, name, description);
        DeselectAllItems();
        listOfItems[index].Selected();
    }

    private void HandleShowItemAction(UIItem itemUI)
    {

    }

    private void HandleItemSelection(UIItem itemUI)
    {
        int index = listOfItems.IndexOf(itemUI);
        if(index == -1)
            return;
        OnDescriptionReq?.Invoke(index);
       
    }

    public void Show()
    {
        gameObject.SetActive(true);
        itemDesc.ResetDescription();
        ResetSelection();
    }

    public void ResetSelection()
    {
        itemDesc.ResetDescription();
        DeselectAllItems();
    }

    private void DeselectAllItems()
    {
        foreach(UIItem item in listOfItems)
        {
            item.Deselect();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
