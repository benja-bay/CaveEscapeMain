using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlatform : MonoBehaviour
{
    //public GameObject sprite1;
    public float waitTime=0.5f;
    public float respawnTime=1.5f;
    private Vector3 startPosition;
    private Rigidbody2D rBody2D;
    //private SpriteRenderer spr1;

    private void Start() 
    {
        rBody2D = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        //spr1 = sprite1.GetComponent<SpriteRenderer>();
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
        // soft animaton respawn 
        //Color c1 = spr1.material.color;
        //c1.a = 0f;
        //spr1.material.color = c1;
        //StartCoroutine("FadeIn");
    }

    //IEnumerator FadeIn()
    //{
    //    for (float f = 0.0f;f <= 1; f+= 0.1f)
    //    {
    //        Color c1 = spr1.material.color;
    //        c1.a = f;
    //        spr1.material.color = c1;
    //        yield return new WaitForSeconds(0.025f);
    //    }
    //}
}
