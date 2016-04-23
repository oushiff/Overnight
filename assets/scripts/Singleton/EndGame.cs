using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D collider2d)
	{
		if (collider2d.gameObject.tag == "PlayerSnow")
		{
			Debug.LogError ("hit the bottom");
			GameManager.Instance.LoseGame ();
			//transform.parent.gameObject.AddComponent<GameOver>();
			//Application.LoadLevel (Application.loadedLevel);
			//GameManager.Instance.RestartGame ();
		}
	}
}
