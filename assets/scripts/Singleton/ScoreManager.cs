using UnityEngine;
using System.Collections;

public class ScoreManager : GlobalSingleton<ScoreManager> {

	[SerializeField]
	private float _timeConsumed;

	public float TimeConsumed
	{
		get { return _timeConsumed; }
		set { _timeConsumed = value; }
	}

	[SerializeField]
	private int _coinsGot;

	public int CoinsGot
	{
		get { return _coinsGot; }
		set { _coinsGot = value; }
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
