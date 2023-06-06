using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour, IEnemy
{
    public int health;
    public float speed;
    public int positionOfPatrol;
    public Transform point;
    bool moveingRight;
    Transform player;
    public float stoppingDistance;

    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        Destroy(gameObject);
    }
}

