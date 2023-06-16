using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupMainScene : MonoBehaviour
{
    public GameObject popupPanel;
    void Start(){
        if(GlobalVariableStorage.popupopen == true)
        {
            popupPanel.SetActive(true);
        }
    }
     public void ClosePanel()
    {
        GlobalVariableStorage.popupopen = false;
        popupPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
