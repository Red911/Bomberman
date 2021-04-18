using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMoveBomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag== "Character")
        {
            Playermovement playermovement = other.gameObject.GetComponent<Playermovement>();
            playermovement.canMoveBomb = true;
        }

    }
}
