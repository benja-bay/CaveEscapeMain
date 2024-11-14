using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDoublejump : MonoBehaviour
{   
    PlayerMov playerMov;
    void Start()
    {
        playerMov = FindAnyObjectByType<PlayerMov>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.CompareTag("Player"))
         {
            Debug.Log("double jump enabled");
            playerMov.doubleJump = true;
            Destroy(gameObject,0.5f);
         }
    }
}
