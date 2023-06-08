// https://www.youtube.com/watch?v=iX0BEiJTjrE&list=PLjAb99vXJuCRD04EUp8p2az1ILZbq_ZfY&index=25

using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image fillBar;
    public float health;

    public void LoseHealth(int value)
    {
        health -= value;
        fillBar.fillAmount = health/100;
        if(health<=0)
        {
            // TODO: Player wins
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
