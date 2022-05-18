using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int lives = 2;
    public GameObject normalBrick;
    public GameObject smallerPaddleBrick;
    public GameObject strongBrick;
    public GameObject explosiveBrick;
    public GameObject secondBallBrick;


    void Start()
    {
        GameObject[] brickPositions = GameObject.FindGameObjectsWithTag("BrickPosition");
        foreach (GameObject brickPosition in brickPositions) {
            int i = Random.Range(1, 11);
            if(i <= 4) {
                Instantiate(normalBrick, brickPosition.transform.position, brickPosition.transform.rotation);
            } else if(i == 5){
                Instantiate(smallerPaddleBrick, brickPosition.transform.position, brickPosition.transform.rotation);
            } else if(i >= 6 && i <= 7) {
                Instantiate(strongBrick, brickPosition.transform.position, brickPosition.transform.rotation);
            } else if(i >= 8 && i <= 9) {
                Instantiate(explosiveBrick, brickPosition.transform.position, brickPosition.transform.rotation);
            } else {
                Instantiate(secondBallBrick, brickPosition.transform.position, brickPosition.transform.rotation);
            }
        }
    }
    
    public static void looseLive() 
    {
        Debug.Log("You Lost a life");
        lives--;
        if(lives < 1) {
            Debug.Log("You Lost");
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject ball in balls) {
                Destroy(ball);
            }
        }
    }
}
