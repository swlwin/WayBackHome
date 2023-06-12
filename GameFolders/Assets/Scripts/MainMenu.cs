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
            
            GlobalVariableStorage.Enemy1Alive = true;
            GlobalVariableStorage.remainder = 0;
            GlobalVariableStorage.PlayerStarCount = 0;
        }
        SceneManager.LoadScene(sceneName);
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