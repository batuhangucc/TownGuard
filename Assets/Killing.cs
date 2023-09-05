using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killing : MonoBehaviour
{
    public Transform player;
    public float movespeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    void Start()
    {
        rb =this.GetComponent<Rigidbody2D>();   
    }

  
    void Update()
    {
        Vector3 direction=player.position-transform.position;   
        float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        moveChar(movement);   
    }
    void moveChar(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position+(direction*movespeed*Time.deltaTime ));
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Bullet")
        {
            Destroy(this.gameObject);
           
            
        }
    }
}
