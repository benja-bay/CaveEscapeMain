using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGRound : MonoBehaviour
{
    public static bool isGrounded;
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("isGrounded true");
        }
    }
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("isGrounded false");
        }
    }
}
