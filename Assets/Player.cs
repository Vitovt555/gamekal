using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float speed;
   public float health = 6f;
   private Rigidbody2D step;
   private Vector2 moveVelocity;
    void Start()
    {
        
        step = GetComponent<Rigidbody2D>();
        step.freezeRotation = true;
    }

     void Update()
    {
       Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
       moveVelocity = moveInput.normalized*speed; 
    }
    void FixedUpdate()
    {
        step.MovePosition(step.position + moveVelocity * Time.fixedDeltaTime);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
