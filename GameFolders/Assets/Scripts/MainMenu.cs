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
