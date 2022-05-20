using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static readonly string TEXT_POINTS_TAG = "Points";
    public static readonly string TEXT_LIFES_TAG = "Lifes";
    public static readonly string TEXT_WINLOST_TAG = "WinLost";
    private static TextMeshPro textPoints;
    private static TextMeshPro textLifes;
    private static TextMeshPro textWinLost;
    private static int points = 0;
    public static int lifes = 2;
    public GameObject normalBrick;
    public GameObject smallerPaddleBrick;
    public GameObject strongBrick;
    public GameObject explosiveBrick;
    public GameObject secondBallBrick;


    void Awake()
    {
        textPoints = GameObject.FindGameObjectWithTag(TEXT_POINTS_TAG).GetComponent<TextMeshPro>();
        textPoints.text = "Points: " + points.ToString();

        textLifes = GameObject.FindGameObjectWithTag(TEXT_LIFES_TAG).GetComponent<TextMeshPro>();
        textLifes.text = "Lifes: " + lifes.ToString();

        textWinLost = GameObject.FindGameObjectWithTag(TEXT_WINLOST_TAG).GetComponent<TextMeshPro>();
    }

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

    public static void addPoint() {
        points++;
        textPoints.text = "Points: " + points.ToString();
    }

    public static void win() {
        textWinLost.text = "You won!";
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls) {
            Destroy(ball);
        }
    }
    
    public static void looseLive() 
    {
        lifes--;
        textLifes.text = "Lifes: " + lifes.ToString();
        if(lifes < 1) {
            textWinLost.text = "You lost!";
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject ball in balls) {
                Destroy(ball);
            }
        }
    }
}
