using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    public int starId; 

    public void Start() 
    {
        if(!GlobalVariableStorage.IsStarAlive(starId))
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            GlobalVariableStorage.KillStar(starId);
        }
    }
}
