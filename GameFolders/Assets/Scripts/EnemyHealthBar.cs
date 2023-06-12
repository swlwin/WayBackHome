// https://www.youtube.com/watch?v=iX0BEiJTjrE&list=PLjAb99vXJuCRD04EUp8p2az1ILZbq_ZfY&index=25

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealthBar : MonoBehaviour
{
    public Image fillBar;
    public float health;
    public int EnemyId;

    public void LoseHealth(int value)
    {
        health -= value;
        fillBar.fillAmount = health/100;
        if(health<=0)
        {
            GlobalVariableStorage.KillEnemy(EnemyId);
            if (EnemyId == 1)
            {
                SceneManager.LoadScene("DinoDefeated");
            }
            else if (EnemyId == 2)
            {
                SceneManager.LoadScene("DogDefeated");
            }
            else if (EnemyId == 3)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
    

    public void ResetHealth()
    {
        health = 100;
        fillBar.fillAmount = health/100;
    }

    private void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Return))
        // {
        //     LoseHealth(25);
        // }
    }
}
