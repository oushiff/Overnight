﻿using UnityEngine;
using System.Collections;

public class circleWithGapController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, -30f) * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player")
			transform.parent.gameObject.AddComponent<GameOver>();
			//GameManager.Instance.RestartGame ();
		//else currentState.OnTriggerEnter(other);
	}
}
