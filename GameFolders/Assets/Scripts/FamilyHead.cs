using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FamilyHead : MonoBehaviour
{

    bool countdown = false;
    public float timeLeft = 10f;
    public PlayerTDMove playerMovement;
    
    private void Update()
    {
        if(countdown)
        {
            CountDown();
        }
        
    }
    
    private void CountDown()
    {
        timeLeft -= Time.deltaTime;
        playerMovement.enabled = false;
        if (timeLeft < 0)
        {
            playerMovement.enabled = true;
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            countdown = true;
        }
    }
}
