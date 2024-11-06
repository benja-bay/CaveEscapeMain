using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
    private Animator animator;
    void Start()
   {
      animator = GetComponent<Animator>();
   }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        animator.SetBool("OnGround", true);
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        animator.SetBool("OnGround", false);
    }
}
