using UnityEngine;
using System.Collections;

public class IceTop : MonoBehaviour {


	public HeroTransform heroTransform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		Debug.Log ("Ice Top Collision!!!");
		if (other.gameObject.tag == "PlayerCloud") {
			// health decrease
			heroTransform.OnClick ();
		}
		//GameManager.Instance.RestartGame ();
		//else currentState.OnTriggerEnter(other);
	}
}
