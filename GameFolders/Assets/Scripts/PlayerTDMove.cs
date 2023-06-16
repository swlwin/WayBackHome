using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTDMove : MonoBehaviour
{
    public float velocity = 4f;

    public Rigidbody2D rb;
    Vector2 movement;
    public Animator anim;
    public AudioSource sceneMusic;
    public GameObject alertPopup;
    public GameObject dialogPopup;
    public GameObject dialogPopup2;


    void Start()
    {
        sceneMusic.Play();
        FindObjectOfType<HealthBar>().UpdateHealthBar();
        rb.position = new Vector2(GlobalVariableStorage.CurrentPlayerX, GlobalVariableStorage.CurrentPlayerY);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * velocity * Time.fixedDeltaTime);
    }

    void closepopup()
    {
        alertPopup.SetActive(false);
        dialogPopup.SetActive(false);
        dialogPopup2.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            alertPopup.SetActive(true);
            Invoke("closepopup", 2f);
        }
        if(collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
            GlobalVariableStorage.PlayerStarCount++;
        }
        if(collision.gameObject.CompareTag("Family"))
        {
            Debug.Log("Collide with Family Head");
            dialogPopup2.SetActive(true);
            Invoke("closepopup", 7f);
           
        }
    } 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Door")) 
        {
            Debug.Log("Collide with Door");
            if ((GlobalVariableStorage.PlayerStarCount < 20) || (GlobalVariableStorage.Enemy1Alive == true) || (GlobalVariableStorage.Enemy2Alive == true))
            {
                Debug.Log("dialogPOPUP1 with Door");
                dialogPopup.SetActive(true);
                Invoke("closepopup", 7f);
            }
            else 
            {
                Destroy(collision.gameObject);
            }
        }
        
        if(collision.gameObject.CompareTag("Final")) 
        {
            Debug.Log("Collide with Final Door");
            if ((GlobalVariableStorage.PlayerStarCount < 40) || (GlobalVariableStorage.Enemy3Alive == true))
            {
                dialogPopup.SetActive(true);
                Invoke("closepopup", 7f);
            }
            else 
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
