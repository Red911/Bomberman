using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Character")
		{
			PlayerLife playerLife = other.gameObject.GetComponent<PlayerLife>();
			playerLife.isDead = true;


			Debug.Log("touche le joueur");
			//collider.gameObject.GetComponent<PlayerLife>().LoseLife();
			//Destroy(other.gameObject);
		}
		else if (other.tag == "Bomb")
		{
			other.gameObject.GetComponent<BombExplosion>().CmdExplode();
		}
	}
}
