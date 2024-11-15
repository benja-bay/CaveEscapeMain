using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlatform : MonoBehaviour
{
    
    public float waitTime=0.5f;
    public float respawnTime=1.5f;
    private Vector3 startPosition;
    private Rigidbody2D rBody2D;
    

    private void Start() 
    {
        rBody2D = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Fall", waitTime);
            Invoke("Respawn", respawnTime);
        }
    }

    private void Fall()
    {
        rBody2D.isKinematic = false;
    }
    private void Respawn(){
        rBody2D.velocity = Vector3.zero;
        rBody2D.isKinematic = true;
        transform.position = startPosition;
        
    }


}
