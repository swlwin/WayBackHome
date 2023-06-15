// https://www.youtube.com/watch?v=iX0BEiJTjrE&list=PLjAb99vXJuCRD04EUp8p2az1ILZbq_ZfY&index=25

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;

    public void LoseHealth(int value)
    {
        GlobalVariableStorage.PlayerHealth -= value;
        UpdateHealthBar();
        if(GlobalVariableStorage.PlayerHealth<=0)
        {
            SceneManager.LoadScene("PlayerDefeated");
        }
    }

    public void RestoreHealth(int value)
    {
        GlobalVariableStorage.PlayerHealth += value;
        UpdateHealthBar();
        if(GlobalVariableStorage.PlayerHealth<=0)
        {
            SceneManager.LoadScene("PlayerDefeated");
        }
    }

    public void ResetHealth()
    {
        GlobalVariableStorage.PlayerHealth = 100;
        UpdateHealthBar();
        Debug.Log("Resetting Health");
    }

    public void UpdateHealthBar()
    {
        fillBar.fillAmount = GlobalVariableStorage.PlayerHealth/100;
    }

    private void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Return))
        // {
        //     LoseHealth(25);
        // }
    }
}
