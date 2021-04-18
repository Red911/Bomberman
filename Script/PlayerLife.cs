using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerLife : NetworkBehaviour
{

	[SerializeField]
	private int numberOfLives = 3;

	[SerializeField]
	private float invulnerabilityDuration = 2;

	private bool isInvulnerable = false;

	[SerializeField]
	private GameObject playerLifeImage;

	private List<GameObject> lifeImages;

	private GameObject gameOverPanel;

	private Vector2 initialPosition;
	private int initialNumberOfLives;
	public bool isDead;
	void Start()
	{

		if (this.isLocalPlayer)
		{
			this.initialPosition = this.transform.position;
			//this.initialNumberOfLives = this.numberOfLives;
			Debug.Log("premier");





			//GameObject playerLivesGrid = GameObject.Find("PlayerLivesGrid");

			//this.lifeImages = new List<GameObject>();
			//for (int lifeIndex = 0; lifeIndex < this.numberOfLives; ++lifeIndex)
			//{
			//	GameObject lifeImage = Instantiate(playerLifeImage, playerLivesGrid.transform) as GameObject;
			//	this.lifeImages.Add(lifeImage);
			//}
		}
	}
    //public void Explode()
    //   {
    //	isDead = true;

    void Update()
    {

		if (isDead)
		{

			Debug.Log("joueur dois miurir la");
			//gameOverPanel = GameObject.Find("GameOverPanel");
			//gameOverPanel.SetActive(true);
			Destroy(gameObject);
		}
	}
    //}
    public void LoseLife()
	{
		if (!this.isInvulnerable && this.isLocalPlayer)
		{
			this.numberOfLives--;
			GameObject lifeImage = this.lifeImages[this.lifeImages.Count - 1];
			Destroy(lifeImage);
			this.lifeImages.RemoveAt(this.lifeImages.Count - 1);
			if (this.numberOfLives == 0)
			{
				Respawn();
			}
			this.isInvulnerable = true;
			Invoke("BecomeVulnerable", this.invulnerabilityDuration);
		}
	}

	private void BecomeVulnerable()
	{
		this.isInvulnerable = false;
	}

	void Respawn()
	{
		this.numberOfLives = this.initialNumberOfLives;

		GameObject playerLivesGrid = GameObject.Find("PlayerLivesGrid");

		this.lifeImages = new List<GameObject>();
		for (int lifeIndex = 0; lifeIndex < this.numberOfLives; ++lifeIndex)
		{
			GameObject lifeImage = Instantiate(playerLifeImage, playerLivesGrid.transform) as GameObject;
			this.lifeImages.Add(lifeImage);
		}

		this.transform.position = this.initialPosition;
	}

}