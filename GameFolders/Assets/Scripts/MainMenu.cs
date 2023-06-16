using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource starterMusic;
    public GameObject popupPanel;
    void Start()
    {
        starterMusic.Play();
    }

    public void SceneChange(string sceneName)
    {
        // If player dies, reset all global variables
        if (GlobalVariableStorage.PlayerHealth <= 0)
        {
            GlobalVariableStorage.PlayerHealth = 100;
            GlobalVariableStorage.CurrentPlayerX = 0;
            GlobalVariableStorage.CurrentPlayerY = 0;

            GlobalVariableStorage.Potion1Collected = false;
            GlobalVariableStorage.Potion2Collected = false;
            GlobalVariableStorage.Potion3Collected = false;
            GlobalVariableStorage.Potion4Collected = false;
            GlobalVariableStorage.Potion5Collected = false;
            GlobalVariableStorage.Potion6Collected = false;
            GlobalVariableStorage.Potion7Collected = false;
            GlobalVariableStorage.Potion8Collected = false;
            GlobalVariableStorage.Potion9Collected = false;
            GlobalVariableStorage.Potion10Collected = false;

            GlobalVariableStorage.Star1Alive = true;
            GlobalVariableStorage.Star2Alive = true;
            GlobalVariableStorage.Star3Alive = true;
            GlobalVariableStorage.Star4Alive = true;
            GlobalVariableStorage.Star5Alive = true;
            GlobalVariableStorage.Star6Alive = true;
            GlobalVariableStorage.Star7Alive = true;
            GlobalVariableStorage.Star8Alive = true;
            GlobalVariableStorage.Star9Alive = true;
            GlobalVariableStorage.Star10Alive = true;
            GlobalVariableStorage.Star11Alive = true;
            GlobalVariableStorage.Star12Alive = true;
            GlobalVariableStorage.Star13Alive = true;
            GlobalVariableStorage.Star14Alive = true;
            GlobalVariableStorage.Star15Alive = true;
            GlobalVariableStorage.Star16Alive = true;
            
            GlobalVariableStorage.Enemy1Alive = true;
            GlobalVariableStorage.Enemy2Alive = true;
            GlobalVariableStorage.Enemy3Alive = true;
            
            GlobalVariableStorage.remainder = 0;
            GlobalVariableStorage.PlayerStarCount = 0;

            GlobalVariableStorage.inventoryItems.Clear();
            GlobalVariableStorage.popupopen = true;
        }
        SceneManager.LoadScene(sceneName);
    }

    public void DinoDefeated()
    {
        GlobalVariableStorage.PlayerStarCount += 5;
    }
    
    public void DogDefeated()
    {
        GlobalVariableStorage.PlayerStarCount += 10;
    }

    public void EagleDefeated()
    {
        GlobalVariableStorage.PlayerStarCount += 15;
    }

    public void QuitApp()
    {
        Application.Quit();
        // Debug.log("App has been closed!");
    }

    public void InfoPanel()
    {
        popupPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        popupPanel.SetActive(false);
    }
}