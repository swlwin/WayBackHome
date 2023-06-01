using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        speed = 2.0f;
        range = 4.0f;
        cooldown = 2.5f;
        isFlipped = false;
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

            Vector2 target = new Vector2(player.position.x, transform.position.y);
            Vector2 newPos = Vector2.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
            boss.MovePosition(newPos);

            if (Vector2.Distance(player.position, boss.position) <= range)
            {
                if (timer > cooldown)
                {
                    animator.SetBool("attacking", true);
                    Debug.Log("Attacked");
                    timer = 0;
                }
            }
            else
            {
                animator.SetBool("attacking", false);
            }
        }
        timer += Time.deltaTime;
    }
}
