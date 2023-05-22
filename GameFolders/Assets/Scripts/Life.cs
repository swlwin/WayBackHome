// https://www.youtube.com/watch?v=iX0BEiJTjrE&list=PLjAb99vXJuCRD04EUp8p2az1ILZbq_ZfY&index=25

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public Image[] lives;
    public int livesCount;

    public void LoseLife()
    {
        if(livesCount == 0)
        {
            return;
        }
        
        livesCount--;
        lives[livesCount].enabled = false;
        if(livesCount==0)
        {
            FindObjectOfType<PlayerControls>().Die();
        }
    }

    private void Update()
    {
        
    }

}
