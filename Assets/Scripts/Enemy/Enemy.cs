using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public int health;
    public float speed;
    public int positionOfPatrol;
    public Transform point;
    bool moveingRight;
    Transform player;
    public float stoppingDistance;
    private UnityEngine.Object explosion;
    bool chill = false;
    bool angry = false;
    bool goBack = false;
    private CoinDrop Droper;
    private void Start()
    {
        Droper = gameObject.GetComponent<CoinDrop>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        explosion = Resources.Load("Explosion");
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false )
        {
            chill = true;
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }

        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goBack == true)
        {
            Goback();
        }
        
        if (health <= 0)
        {
            GameObject explosionRef = (GameObject)Instantiate(explosion);
            explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Droper.CoinDroper();
            Destroy(gameObject);
        }
        

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            moveingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveingRight = true;
        }

        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

    }
    

    private void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void Goback()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
}

