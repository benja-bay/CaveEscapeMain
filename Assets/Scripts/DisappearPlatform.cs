using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlatform : MonoBehaviour
{
    private Rigidbody2D rBody2D;
    public float waitTime=1.5f;

    private void Start() {
        rBody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Fall", waitTime);
        }
    }

    private void Fall(){
        rBody2D.isKinematic = false;
    }
}
