//https://www.youtube.com/playlist?list=PLjAb99vXJuCRD04EUp8p2az1ILZbq_ZfY
//https://www.youtube.com/watch?v=OcnpNIHmjAM

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{

    //Private Fields
    private Rigidbody2D rb;
    private Animator anim; 
    [SerializeField] Transform groundCollider;
    [SerializeField] LayerMask groundLayer;
    float xMovement;
    float runSpeed = 2;
    [SerializeField] bool isRunning;
    [SerializeField] bool isGrounded;
    [SerializeField] int totalJumps = 2;
    int availJumps;
    bool multiJumps;
    bool isDead = false;
        
    //Public Fields
    public float speed = 4;
    public float jumpForce = 11;
    
    //Attack
    [SerializeField] GameObject AttackPoint;
    [SerializeField] float AttackRange = 0.5f;
    [SerializeField] LayerMask EnemyLayer;
    public bool isAttacking = false;

    //Audio
    public AudioSource jumpSound;
    public AudioSource attackSound;
    
    void Awake()
    {
        availJumps = totalJumps;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        FindObjectOfType<HealthBar>().UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {

        if(CanMove() == false)
        {
            return;
        }
        //Store the horizontal value 
        xMovement = Input.GetAxisRaw("Horizontal");
       
        //If RShift is pressed, running
        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            isRunning = true;
        }
        //If RShift is not pressed, walking
        if(Input.GetKeyUp(KeyCode.RightShift))
        {
            isRunning = false;
        }

        if(Input.GetKeyDown("1") && !isAttacking)
        {
            StartCoroutine(attack());
            // isAttacking = true; 
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            // isAttacking = false;
        }

        //Space for jumping
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        
        //Set y velocity in the animator 
        anim.SetFloat("yVelocity", rb.velocity.y);
       
    }

    void FixedUpdate()
    {
        GroundCheck();

        Move(xMovement);
    }

    void GroundCheck()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCollider.position, 0.7f, groundLayer); //0.2f = radius
        if(colliders.Length > 0)
        {
            isGrounded = true;
            if(!wasGrounded)
            {
                availJumps = totalJumps;
                multiJumps = false;
            }
        }
        
        anim.SetBool("Jump", !isGrounded);
    }

    void Move(float direction)
    {
        #region Move
        float xspeed = direction * speed;
        if(transform.position.y < -11)
        {
            FindObjectOfType<HealthBar>().ResetHealth();
            transform.position = new Vector3(-72.74f,0f,0f);
        }
        if(isRunning)
        {
            xspeed *= runSpeed;
        }

        if(direction < 0) //left
        {
            rb.velocity = new Vector2(xspeed, rb.velocity.y);
            transform.localScale = new Vector2(-1,1);
        }
        else if(direction > 0) //right
        {
            rb.velocity = new Vector2(xspeed, rb.velocity.y);
            transform.localScale = new Vector2(1,1);
        }   

        //idle = 0, walking = 4, running = 8
        anim.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        #endregion
        
    }

    void Jump()
    {
   
        //if player is grounded and pressed Space, Jump
        if(isGrounded)
        {
            multiJumps = true;
            availJumps--;
            //Add JumpForce
            rb.velocity = Vector2.up * jumpForce;
            // rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            anim.SetBool("Jump", true);
            jumpSound.Play();
        }
        else
        {
            if(multiJumps && availJumps>0)
            {
                availJumps--;
                rb.velocity = Vector2.up * jumpForce;
                // rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
                anim.SetBool("Jump", true);
                jumpSound.Play();
            }
        }
 
    }

    bool CanMove()
    {
        bool can = true; 
        if(isDead)
        {
            can = false;
        }
        return can;
    }

    public void Die()
    {
        isDead = true;
        FindObjectOfType<LevelManager>().SceneChange("GameOver");
    }

    public void ResetPlayer()
    {
        transform.position = new Vector2(0f,0f);
        isDead = true;
    }

    

    IEnumerator attack()
    {
        Collider2D[] Enemies = Physics2D.OverlapCircleAll(AttackPoint.transform.position, AttackRange, EnemyLayer);
        foreach(Collider2D enemy in Enemies)
        {
            if(enemy.CompareTag("Enemies"))
            {
                FindObjectOfType<EnemyHealthBar>().LoseHealth(15);
            }
        }
        anim.SetTrigger("Attack");
        attackSound.Play();
        isAttacking = true;
        yield return new WaitForSeconds(0.6f);
        isAttacking = false;
    }

}
