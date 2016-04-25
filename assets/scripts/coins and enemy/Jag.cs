using UnityEngine;
using System.Collections;

public class Jag : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collider2d)
	{
		if (collider2d.gameObject.tag == "PlayerSnow" )
		{
			GetAttacked();
		}
	}

	void OnCollisionStay2D(Collision2D collider2d)
	{
		if (collider2d.gameObject.tag == "PlayerSnow" )
		{
			GetAttacked();
		}
	}
	 

	[SerializeField]
	private float healthDecrease = 10;

	private void GetAttacked()
	{
		//GameManager.Instance.Health -= healthDecrease;
		if (GameManager.Instance.Bleeding == false) {
			
			GameManager.Instance.DecreaseHealth (healthDecrease);
			GameManager.Instance.Bleeding = true;
		}
		/*
		if (GameManager.Instance.Health <= 0) {
			//GameManager.Instance.RestartGame ();
			transform.parent.gameObject.AddComponent<GameOver>();
		}
		*/

	}
}
