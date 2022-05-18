using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBallBrick : MonoBehaviour
{

    public GameObject secondBall;
    private bool isQuitting = false;
    
    void OnApplicationQuit()
    {
        isQuitting = true;
    }
    private void OnDestroy()
    {
        if(!isQuitting) {
            Instantiate(secondBall, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
