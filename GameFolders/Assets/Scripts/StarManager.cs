using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public Text starText;

    // Update is called once per frame
    void Update()
    {
        starText.text = "Memory Shards: " + GlobalVariableStorage.PlayerStarCount.ToString();
    }
}
