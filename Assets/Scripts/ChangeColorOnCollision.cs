using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChangeColorOnCollision : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float bumpSpeed = 450;
    public int lower = 5, upper = 10;
    public GameObject smallerSpwanObject;
    public Boolean isSmall;
    public float life = 10f;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        gameObject.GetComponent<Renderer>().material.color = new Color(
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f)
        );
        InvokeRepeating(nameof(CheckAltitude), 2f, 1f);
        Invoke(nameof(DestroyAfterTime), life);

    }

    void OnCollisionEnter(Collision collision)
    {
        // Find the component 'Renderer', and change the color of the Material accordingly:
        gameObject.GetComponent<Renderer>().material.color = new Color(
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f)
        );
        
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.CompareTag("speed_wall"))
        {
            // Throw(gameObject);
            if (!isSmall)
            {
                SplitBalls();
                Destroy(gameObject);
            }
            
        }
        
    }
    
    private void Throw(GameObject ball, Rigidbody ballRigidbody)
    {
        
        ball.GetComponent<Transform>().eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        Vector3 force = transform.forward;
        force = new Vector3(force.x, 1, force.z);
        ballRigidbody.AddForce(force * bumpSpeed );
    }

    public void CheckAltitude()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void SplitBalls()
    {
        int splitNum = Random.Range(lower, upper);
        for(int i = 0; i < splitNum; i++)
        {
            var instantiated = Instantiate(smallerSpwanObject, transform.position, Quaternion.identity);

            Throw(instantiated, instantiated.GetComponent<Rigidbody>());
        }
    }

    private void DestroyAfterTime()
    {
        Destroy(gameObject);
    }
}
