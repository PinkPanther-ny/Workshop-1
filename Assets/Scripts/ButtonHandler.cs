using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public void ClearAllBalls()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Balls");
        foreach(GameObject ball in balls)
            GameObject.Destroy(ball);
    }

    public void SpawnNewBalls()
    {
        GameObject[] respawns = GameObject.FindGameObjectsWithTag("Respawn");
        GameObject spawnPoint = respawns[0];
        spawnPoint.GetComponent<Spawn>().SpawnBall();
    }
    
}
