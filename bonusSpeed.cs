using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusSpeed : MonoBehaviour
{
    void Start()
    {
       
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Character")
        {
            Playermovement playermovement = other.gameObject.GetComponent<Playermovement>();

            playermovement.speed = 10f;
            Destroy(gameObject);

            Debug.Log("bonus touche le joueur");

        }
    }
    
    
    

}
