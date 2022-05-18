using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBall : MonoBehaviour
{
    public float lifetime = 15f;
    private float time = 0f;

    void Update()
    {
        time += Time.deltaTime;
        if(time > lifetime) {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.Equals("BottomWall")) {
            Destroy(gameObject);
        }
    }

    
}
