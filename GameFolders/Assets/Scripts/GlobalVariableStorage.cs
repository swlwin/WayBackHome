using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariableStorage : MonoBehaviour
{

    public static float PlayerHealth = 100f;

    public static float CurrentPlayerX = 0;
    public static float CurrentPlayerY = 0;

    public static bool Enemy1Alive = true;


    public static bool IsEnemyAlive(int enemyId) 
    {
        if (enemyId == 1) 
        {
            return Enemy1Alive;
        }
        else 
        {
            return true;
        }
    }

    public static void KillEnemy(int enemyId)
    {
        if (enemyId == 1) 
        {
            Enemy1Alive = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
