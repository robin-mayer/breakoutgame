using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBall : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("BottomWall")) {
            GameController.looseLive();
        }
    }
}
