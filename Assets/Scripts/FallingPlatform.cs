using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float tiempoEspera;
    public float tiempoDestruccion;
    public float velocidadRotacion;
    private Rigidbody2D rb2D;
    private bool caida = false;

    private void Start() 
    {
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    private void Update() {
        if (caida)
        {
            transform.Rotate(new Vector3(0,0,velocidadRotacion * Time.deltaTime));
        }
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
        caida = true;
        yield return new WaitForSeconds(tiempoEspera);
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), other.transform.GetComponent<Collider2D>());
        rb2D.constraints = RigidbodyConstraints2D.None;
        rb2D.AddForce(new Vector2(0.1f, 0));
        Destroy(gameObject, tiempoDestruccion);
    }
}
