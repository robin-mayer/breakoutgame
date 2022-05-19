using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool small = false;
    private float time = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDrag()
    {
        Vector2 touchPosition = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(touchPosition);
        rb.MovePosition(new Vector2(worldPos.x, transform.position.y));
    }

    public void smallerPaddle()
    {
        gameObject.transform.localScale = new Vector2(1f, 0.5f);
        small = true;
        time = 0f;
    }

    void Update() 
    {
        if(small) {
            time += Time.deltaTime;
            if(time > 10f) {
                gameObject.transform.localScale = new Vector2(1.5f, 0.5f);
                small = false;
                time = 0f;
            }
        }
    }

}
