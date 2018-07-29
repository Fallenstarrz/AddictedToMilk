using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player : Controller
{
    // Components
    public Transform tf;
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    public PolygonCollider2D hitBox;
    public AudioSource soundMaker;
    public Animator anim;

    //Sounds
    public AudioClip JumpSound;
    public float soundVolume;

    // Movement Variables
    public float moveSpeed;
    public float jumpForce;
    public bool isInAir;
    public int jumpCountCurrent = 1;
    public int jumpCountMax;
    public float distanceToFeet;
    public bool isMoving;
    public bool isDead;

    RaycastHit2D ground;

    // Use this for initialization
    protected override void Start()
    {
        tf = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        hitBox = GetComponent<PolygonCollider2D>();
        soundMaker = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

        if (GameManager.instance.player == null)
        {
            GameManager.instance.player = this;
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        inputHandler();
    }

    void inputHandler()
    {
        // Idle
        if (!isInAir && !isMoving && !isDead)
        {
            anim.Play("Idle");
        }

        // Movement
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            isMoving = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (!isDead)
            {
                isMoving = true;
                tf.Translate(-moveSpeed * Time.deltaTime, 0, 0);
                sprite.flipX = true;
                if (!isInAir)
                {
                    anim.Play("PlayerRun");
                }
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (!isDead)
            {
                isMoving = true;
                tf.Translate(moveSpeed * Time.deltaTime, 0, 0);
                sprite.flipX = false;
                if (!isInAir)
                {
                    anim.Play("PlayerRun");
                }
            }
        }

        // Jumping
        ground = Physics2D.Raycast(tf.position, Vector2.down, distanceToFeet);
        Debug.DrawRay(tf.position, Vector2.down * distanceToFeet, Color.red);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCountCurrent < jumpCountMax)
            {
                if (!isDead)
                {
                    jumpCountCurrent++;
                    rb.AddForce(Vector3.up * jumpForce);
                    soundMaker.PlayOneShot(JumpSound, soundVolume);
                }
            }
        }
        if (ground.collider != null)
        {
            isInAir = false;
            jumpCountCurrent = 1;
        }
        else
        {
            isInAir = true;
        }
        if (rb.velocity.y > 0)
        {
            if (!isDead)
            {
                anim.Play("PlayerJump");
            }
        }
        else if (rb.velocity.y < 0)
        {
            if (!isDead)
            {
                anim.Play("PlayerFall");
            }
        }
    }
    // player death
    public void playerDead()
    {
        isDead = true;
        anim.Play("PlayerDead");
        Destroy(this.gameObject, 2);
    }
}
