using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBrick : MonoBehaviour
{
    public float distance = 5f;
    private bool isQuitting = false;
    void OnApplicationQuit()
    {
        isQuitting = true;
    }
    private void OnDestroy()
    {
        if(!isQuitting) {
            explode();
        }
    }


    private void explode() {
        GameObject[] brickPositions = GameObject.FindGameObjectsWithTag("Brick");
        foreach (GameObject obj in brickPositions){
            if(Vector2.Distance(transform.position, obj.transform.position) < distance) {
                obj.GetComponent<Brick>().looseLife();
            }
        }
    }
}
