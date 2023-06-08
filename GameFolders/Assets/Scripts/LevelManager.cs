using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Vector2 playerInit;
    public GameObject popupPanel;
    // public GameObject notEnoughStarsPanel;
    // public GameObject enterTunnelPanel;
    public GameObject PauseGame;
    public AudioSource forestSound;

    void Start()
    {
        forestSound.Play();
        playerInit = FindObjectOfType<PlayerControls>().transform.position;
        Time.timeScale = 0;
    }

    // public void Restart()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }

    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // public void NotEnoughStars()
    // {
    //     notEnoughStarsPanel.SetActive(true);
    // }
    
    // public void EnterTunnel()
    // {
    //     enterTunnelPanel.SetActive(true);
    // }

    public void ClosePanel()
    {
        popupPanel.SetActive(false);
        Time.timeScale = 1;
        // notEnoughStarsPanel.SetActive(false);
        // enterTunnelPanel.SetActive(false);
    }
}
