using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Playermovement : NetworkBehaviour{



    //[SerializeField]
    public float speed = 5f;
    

    Vector2 movement;


    public Rigidbody2D rb;
    [SerializeField]
    private Animator animator;
    
    public bool canMoveBomb;
    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }
    public override void OnStartLocalPlayer()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    void Update()
    {

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (!(movement.x != 0 && movement.y != 0))
            {
                animator.SetFloat("horizontal", movement.x);
                animator.SetFloat("vertical", movement.y);
                animator.SetFloat("speed", movement.sqrMagnitude);
            }
            else
            {
                animator.SetFloat("speed", 0f);
            }
        if (speed > 5f)
        {
            StartCoroutine(SpeedCoolDown());
        }
    }
    

    void FixedUpdate()
    {
 
            if (this.isLocalPlayer)
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");

                Vector2 currentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;

                float newVelocityX = 0f;
                if (moveHorizontal < 0 && currentVelocity.x <= 0)
                {
                    newVelocityX = -speed;
                    animator.SetInteger("DirectionX", -1);
                }
                else if (moveHorizontal > 0 && currentVelocity.x >= 0)
                {
                    newVelocityX = speed;
                    animator.SetInteger("DirectionX", 1);
                }
                else
                {
                    animator.SetInteger("DirectionX", 0);
                }

                float newVelocityY = 0f;
                if (moveVertical < 0 && currentVelocity.y <= 0)
                {
                    newVelocityY = -speed;
                    animator.SetInteger("DirectionY", -1);
                }
                else if (moveVertical > 0 && currentVelocity.y >= 0)
                {
                    newVelocityY = speed;
                    animator.SetInteger("DirectionY", 1);
                }
                else
                {
                    animator.SetInteger("DirectionY", 0);
                }

                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(newVelocityX, newVelocityY);
            }
        
    }
    public IEnumerator SpeedCoolDown()
    {
        yield return new WaitForSeconds(3f);
        speed = 5f;
    }
   
}