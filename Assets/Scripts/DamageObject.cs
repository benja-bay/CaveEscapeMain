using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damage");
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
    }
}
