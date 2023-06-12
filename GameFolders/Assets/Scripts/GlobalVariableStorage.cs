using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariableStorage : MonoBehaviour
{

    public static float PlayerHealth = 100f;

    public static float CurrentPlayerX = 0;
    public static float CurrentPlayerY = 0;
    public static int PlayerStarCount = 0; 

    public static bool Enemy1Alive = true;
    // public static bool Enemy2Alive = true;
    // public static bool Enemy3Alive = true;
    public static bool Star1Alive = true; 
    public static bool Star2Alive = true;
    public static bool Star3Alive = true; 
    public static bool Star4Alive = true;
    public static bool Star5Alive = true; 
    public static bool Star6Alive = true;
    public static bool Star7Alive = true; 
    public static bool Star8Alive = true;
    public static bool Star9Alive = true; 
    public static bool Star10Alive = true;
    public static bool Star11Alive = true; 
    public static bool Star12Alive = true;
    public static bool Star13Alive = true; 
    public static bool Star14Alive = true;
    public static bool Star15Alive = true; 
    public static bool Star16Alive = true;

    public static bool Potion1Collected = false;

    public static int remainder = 0;


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

    public static bool isPotionCollected(int potionID)
    {
            if (potionID == 1) 
            {
                return Potion1Collected;
            }
            else 
            {
                return false;
            }
    }

    public static void potionCollected(int potionID)
    {
        if (potionID == 1) 
        {
            Potion1Collected = true;
        }
    }

    public static void KillEnemy(int enemyId)
    {
        if (enemyId == 1) 
        {
            Enemy1Alive = false;
        }
    }

    public static bool IsStarAlive(int starId)
    {
        switch (starId) 
        {
            case 1: 
                return Star1Alive; 
            case 2: 
                return Star2Alive; 
            case 3: 
                return Star3Alive; 
            case 4: 
                return Star4Alive; 
            case 5: 
                return Star5Alive; 
            case 6: 
                return Star6Alive; 
            case 7: 
                return Star7Alive; 
            case 8: 
                return Star8Alive; 
            case 9: 
                return Star9Alive; 
            case 10: 
                return Star10Alive; 
            case 11: 
                return Star11Alive; 
            case 12: 
                return Star12Alive; 
            case 13: 
                return Star13Alive; 
            case 14: 
                return Star14Alive; 
            case 15: 
                return Star15Alive; 
            case 16: 
                return Star16Alive; 
            default:
                return true; 
        }
    }

    public static void KillStar(int starId)
    {
        switch (starId) 
        {
            case 1: 
                Star1Alive = false; 
                break; 
            case 2: 
                Star2Alive = false; 
                break; 
            case 3: 
                Star3Alive = false; 
                break; 
            case 4: 
                Star4Alive = false; 
                break; 
            case 5: 
                Star5Alive = false; 
                break; 
            case 6: 
                Star6Alive = false; 
                break; 
            case 7: 
                Star7Alive = false; 
                break; 
            case 8: 
                Star8Alive = false; 
                break; 
            case 9: 
                Star9Alive = false; 
                break; 
            case 10: 
                Star10Alive = false; 
                break; 
            case 11: 
                Star11Alive = false; 
                break; 
            case 12: 
                Star12Alive = false; 
                break; 
            case 13: 
                Star13Alive = false; 
                break; 
            case 14: 
                Star14Alive = false; 
                break; 
            case 15: 
                Star15Alive = false; 
                break; 
            case 16: 
                Star16Alive = false; 
                break; 
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
