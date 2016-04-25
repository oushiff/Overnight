using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.Events;

public class HeroJump : MonoBehaviour {

	public bool isClickBool = false;
	public Button btn;

	// Use this for initialization
	void Start () {
		GameObject btnObject = GameObject.Find ("JumpBtn");
		btn = btnObject.GetComponent<Button> ();
		btn.onClick.AddListener(delegate(){
			this.OnClick();
		});
	}

	public void OnClick() {
		isClickBool = !isClickBool;
		Debug.Log ("+++call OnClick!!" + isClickBool);
	}

	public void FixedUpdate(){
		if (GameManager.Instance.Status == "PlayerCloud") {
			btn.interactable = false;
		} else {
			btn.interactable = true;
		}
	}

}
