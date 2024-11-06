using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{
    public float tiempoEspera;
    private Rigidbody2D  rb2D;
    public float velocidadRotacion;
    private Animator animator;
    private bool caida = false;
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)  
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Caida(other));
        }    
    }
    private IEnumerator Caida(Collision2D other)
    {
        yield return new WaitForSeconds(tiempoEspera);
        caida = true;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.transform.GetComponent<Collider2D>());
        rb2D.constraints = RigidbodyConstraints2D.None;
        Destroy(gameObject,0.5f);
    }
    
}
