using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float health;
    public int numOfHearth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public float invincibility=1f;
    private float moveInput, invincible;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask WhatIsGround;
    private Animator anim;
    private void Start(){
        invincible = invincibility;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        if (health > numOfHearth)
        {
            health = numOfHearth;
        }
        for (int i=0; i <hearts.Length; i++)
        {
            if(i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else 
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearth)
            {
                hearts[i].enabled = true;
            }
            else 
            {
                hearts[i].enabled = false;
            }
        }
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(facingRight == false && moveInput < 0)
        {
            Flip();
        }
        else if(facingRight == true && moveInput > 0)
        {
            Flip();
        }
        if(moveInput == 0)
        {
            anim.SetBool("isRunning",false);
        }
        else
        {
            anim.SetBool("isRunning",true);
        }
    }
private void Update()
    {
    isGrounded = Physics2D.OverlapCircle(feetPos.position,checkRadius,WhatIsGround);
    if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
    {
        rb.velocity = Vector2.up * jumpForce;
    anim.SetTrigger("takeOf");
    }
    if(isGrounded == true)
    {
        anim.SetBool("isJumping", false);
    }
    else 
    {
        anim.SetBool("isJumping", true);
    }
    invincible -= Time.deltaTime;
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (invincible < 0){
        if (collision.gameObject.tag == "Enemy"){
            invincible = invincibility;
        health -= 1;}
    }
    }
    }
















