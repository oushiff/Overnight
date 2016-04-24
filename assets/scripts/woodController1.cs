using UnityEngine;
using System.Collections;

public class woodController1 : MonoBehaviour {
	public float speed = 3;
	public float acceleration;
	public float maxSpeed= 3;
	// Use this for initialization
	void Start () {
		//Invoke ("Floating", 3);
		Floating();
	}


	void Floating() {
		//transform.Translate(0, speed * Time.deltaTime, 0);
		speed = -speed;
		Invoke ("Floating", 1.5f);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(0, speed * Time.deltaTime, 0);
//		if (speed >= maxSpeed) {
//			acceleration = -acceleration;
//			speed += acceleration;
//		} else if (speed <= -maxSpeed) {
//			acceleration = -acceleration;
//			speed += acceleration;
//		} else {
//			speed += acceleration;
//		}

	}
}
