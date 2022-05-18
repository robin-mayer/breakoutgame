using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public int lives = 2;
    private float opacitySteps;
    private float opacity = 1.0f;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        opacitySteps = 1f / lives;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        die();
    }

    public void looseLife()
    {
        die();
    }

    private void die()
    {
        lives--;
        opacity -= opacitySteps;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, opacity);
        if(lives < 1) {
            Destroy(gameObject);
        }
    }
}
