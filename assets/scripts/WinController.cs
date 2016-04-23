using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinController : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collider){
		if (collider.gameObject.tag == "PlayerCloud" || collider.gameObject.tag == "PlayerSnow") {
			GameManager.Instance.CoinsGot = GameManager.Instance.NumCoins;
			GameManager.Instance.TimeConsumed = GameManager.Instance.TimeRemaining;
			SceneManager.LoadScene ("WinPage");
		}
	}
}
