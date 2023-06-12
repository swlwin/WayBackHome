using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoScript : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    Rigidbody2D boss;
    public bool alive;
    public float speed;
    public float range;
    public float timer;
    public float cooldown;
    public bool isFlipped;
    public bool attacking;
    public bool touching;
    public bool animating;
    public float attackTime;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        speed = 2.0f;
        // range = 4.0f;
        cooldown = 2.5f;
        attackTime = 0.5f;
        isFlipped = false;
        attacking = false;
        touching = false;
        animating = false;
        boss = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (alive)
        {
            Vector3 flipped = transform.localScale;
            flipped.z *= -1f;

            if (transform.position.x > player.position.x && isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
            }
            else if (transform.position.x < player.position.x && !isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
            }

            if (!touching && !attacking)
            {
                Vector2 target = new Vector2(player.position.x, transform.position.y);
                Vector2 newPos = Vector2.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
                boss.MovePosition(newPos);
            }
            else
            {
                if (attacking && !animating)
                {
                    animator.SetBool("attacking", true);
                    Debug.Log("Player takes enemy collision damage on stay");
                    timer = 0;
                    FindObjectOfType<HealthBar>().LoseHealth(15);
                    animating = true;
                }
                else
                {
                    if (timer > cooldown)
                    {
                        attacking = true;
                    }
                    if (animating)
                    {
                        attacking = false;
                    }
                }
            }

            if (timer > attackTime)
            {
                animating = false;
                animator.SetBool("attacking", false);
            }
        }
        //Debug.Log("Testing");
        timer += Time.deltaTime;
    }

    // NOTE: For collision damage, a box collider needs to be added to boss and isTrigger needs to be turned on

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attacking = true;
            touching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touching = false;
        }
    }
}
