using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform player;
    private Vector2 target;
    public float speed;
    public int damage = 1;

    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       target = new Vector2(player.position.x, player.position.y); 
      
       
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        Destroy(gameObject, 1f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }

        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        if (other.gameObject.tag != "Enemy") Destroy(gameObject);
        
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
