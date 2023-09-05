using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType { Right, Left }

public class PlayerControl : MonoBehaviour
{
    private float speed=2f;
    public float HorizontalMove=1f;
    private Rigidbody2D rb;
    public Animator anim;
    public Camera cam;
    Vector2 mousepos;

    public MovementType movement;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        mousepos=cam.ScreenToWorldPoint(Input.mousePosition);
        
        

    }
    private void FixedUpdate()
    {
        rb.velocity=new Vector2(HorizontalMove*speed, rb.velocity.y);

        Walk();
        

    }

    private void LateUpdate()
    {
        
    }
    public void Walk()
    {
        if(Mathf.Abs(HorizontalMove)==0)
        {
            
            anim.SetBool("IdleBool",false);
        }
        else
        {
            anim.SetBool("IdleBool",true);
            Flip();
        }
    }
    public void Flip()
    {
        Vector3 angle = transform.eulerAngles;
        angle.z = 0;
        if (HorizontalMove < 0)
        {
            angle.y = 180f;
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, angle, 0.2f);
            movement = MovementType.Left;

        }
        else
        {
            angle.y = 0;
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, angle, 0.2f);
            movement = MovementType.Right;
        }

    }


    
}
