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

    void closealert()
    {
        alertPopup.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            alertPopup.SetActive(true);
            Invoke("closealert", 2f);
           
        }
            
    }

}
