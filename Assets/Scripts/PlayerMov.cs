using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
   //mov
   public float runSpeed=2;
   public float jumpSpeed=3;
   public float doubleJumpSpeed=2.5f;
   private bool canDoubleJump;
   Rigidbody2D rb2D;
   public bool doubleJump = false;
   // better jump
   public bool betterJump = false;
   public float fallMultiplayer = 0.5f;
   public float lowJumpMultiplayer = 1f;
   // animations
   private Animator animator;
   SpriteRenderer spriteRenderer;
   // check ground raycast
   [SerializeField] private LayerMask whatIsGround;
   private bool isGrounded;
   void Start()
   {
      rb2D = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();
      spriteRenderer = GetComponent<SpriteRenderer>();
   }
   private void Update() 
   {
      GroundCheck();
      if (Input.GetKeyDown("space"))
         {
            //if (CheckGRound.isGrounded)
            if (isGrounded)
            {
               canDoubleJump = true;
               rb2D.velocity= new Vector2(rb2D.velocity.x, jumpSpeed);  
               Debug.Log("jump");
            }
            else
            {
               if (Input.GetKeyDown("space")&&doubleJump)
               {
                  if (canDoubleJump)
                  {
                     rb2D.velocity= new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                     canDoubleJump = false;
                     Debug.Log("double jump");
                  }
               }
            }
         }
   }
   private void FixedUpdate()
   {
         animator.SetFloat("Horizontal", -2);

         if (Input.GetKey("d"))
         {
            //Derecha R
            rb2D.velocity = new Vector2(runSpeed , rb2D.velocity.y);
            animator.SetFloat("Horizontal", 2);
            spriteRenderer.flipX = false;
         } 
         else if (Input.GetKey("a"))
         {
            //Izquierda L
            rb2D.velocity= new Vector2(-(runSpeed) , rb2D.velocity.y);
            animator.SetFloat("Horizontal", 2);
            spriteRenderer.flipX = true;
         }
         else
         {
            rb2D.velocity= new Vector2(0,rb2D.velocity.y);
         }

         if (betterJump)
         {
            if (rb2D.velocity.y<0)
            {
                rb2D.velocity += Vector2.up*Physics2D.gravity.y*(fallMultiplayer)*Time.deltaTime;
            }
            if (rb2D.velocity.y>0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up*Physics2D.gravity.y*(lowJumpMultiplayer)*Time.deltaTime;  
            }
        }
   }
   private void GroundCheck()
   {
      float rayLength = 0.1f;
      Ray ray = new Ray(transform.position, Vector2.down);
      Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
      Debug.Log(isGrounded);
      isGrounded = Physics2D.Raycast(ray.origin, ray.direction, rayLength, whatIsGround);
   }
}
