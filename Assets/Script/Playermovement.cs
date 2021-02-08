using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Playermovement : MonoBehaviour {
    public float moveSpeed = 5f;
    

    Vector2 movement;


    public Rigidbody2D rb;
    public Animator animator;
    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }
    void Update(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    if (!(movement.x != 0 && movement.y != 0)){
        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
        } else {
            animator.SetFloat("speed", 0f);
        }
    }

    private void FixedUpdate()
    {
        if (!(movement.x != 0 && movement.y != 0)){

            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
}
}