using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private bool small = false;
    private float time = 0f;
    public static readonly string SMALLER_PADDLE = "small";

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnMouseDrag()
    {
        Vector2 touchPosition = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(touchPosition);
        rb.MovePosition(new Vector2(worldPos.x, transform.position.y));
    }

    public void smallerPaddle()
    {
        if(!small) {
            small = true;
            animator.SetBool(SMALLER_PADDLE, true);
        }else{
            time = 0f;
        }
    }

    void Update() 
    {
        if(small) {
            time += Time.deltaTime;
            if(time > 10f) {
                animator.SetBool(SMALLER_PADDLE, false);
                small = false;
                time = 0f;
            }
        }
    }

}
