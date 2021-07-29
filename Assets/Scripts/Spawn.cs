using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public float repeatTime = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBall), 0, repeatTime);
    }

    public void SpawnBall()
    {
        Vector3 spawnPoint = transform.position;
        spawnPoint.x += Random.Range(-5f, 5f);
        spawnPoint.y += Random.Range(0f, 1f);
        spawnPoint.z += Random.Range(-5f, 5f);
        
        Instantiate(prefab, spawnPoint, Quaternion.identity);
    }
    
    
}
