using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;


public class UIItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text itemQuantity;
    [SerializeField] private Image selected;

    public event Action<UIItem> OnItemClicked, OnRightMouseBtnClcik;

    private bool empty = true;

    public void Awake()
    {
        ResetData();
        Deselect();
    }

    public void ResetData()
    {
        this.itemImage.gameObject.SetActive(false);
        empty = true;
    }

    public void Deselect()
    {
        selected.enabled = false;
    } 

    public void SetData(Sprite sprite, int quantity)
    {   
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        this.itemQuantity.text = quantity + "";
        empty  = false;
    }

    public void Selected()
    {
        selected.enabled = true;
    }

    public void OnMouseDown()
    {
        OnItemClicked?.Invoke(this);
    }

    public void OnPointerClick(BaseEventData pointerData)
    {
        PointerEventData p = (PointerEventData)pointerData;
        if (p.button == PointerEventData.InputButton.Right)
        {
            OnRightMouseBtnClcik?.Invoke(this);
        }
        else
        {
            OnItemClicked?.Invoke(this);
        }
    }


}
