using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float maxSpeed = 200f;
    public float initialForce = 50f;
    private Rigidbody2D rigidBody;
    private float time = 0f;


    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Vector2 speed = new Vector2(Random.Range(-25f, 25f), initialForce);
        rigidBody.AddForce(speed);
    }


    void Update()
    {
        time += Time.deltaTime;
        if(time > 10f) {
            time = 0f;
            maxSpeed += 1f;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 force = new Vector2(Random.Range(-25f, 25f), 0f);
        rigidBody.AddForce(force);

        if(collision.collider.tag.Equals("TopWall")) {
            Debug.Log("You won");
            Destroy(gameObject);
        }
    }

    
    void FixedUpdate()
    {
        if(rigidBody.velocity.magnitude > maxSpeed)
        {
            rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
        }
    }


}
