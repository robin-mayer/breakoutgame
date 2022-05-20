using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public static readonly string BREAK_TRIGGER = "break";
    public static readonly string DESTROY_TRIGGER = "destroy";
    public static readonly string BALL_TAG = "Ball";
    public int lives = 2;
    private Animator animator;
    


    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.Equals(BALL_TAG)){
            die();
        }
    }

    public void looseLife()
    {
        die();
    }

    private void die()
    {
        GameController.addPoint();
        lives--;
        if(lives < 2) {
            animator.SetTrigger(BREAK_TRIGGER);
        }
        if(lives < 1) {
            animator.SetTrigger(DESTROY_TRIGGER);
            Destroy(gameObject, 1);
        }
    }
}
