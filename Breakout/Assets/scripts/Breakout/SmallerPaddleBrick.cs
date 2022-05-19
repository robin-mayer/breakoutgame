using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallerPaddleBrick : MonoBehaviour
{

    private bool isQuitting = false;
    private Paddle paddle;

    void Awake()
    {
        paddle = GameObject.FindGameObjectWithTag("Paddle").GetComponent<Paddle>();
    }

    void OnApplicationQuit()
    {
        isQuitting = true;
    }
    private void OnDestroy()
    {
        if(!isQuitting) {
            paddle.smallerPaddle();
        }
    }
}
