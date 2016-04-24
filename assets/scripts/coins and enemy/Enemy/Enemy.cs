using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : Character {


	private IEnemyState currentState;
	 
	public GameObject target{get; set;} 

	public float fireSize;

	public void Awake(){
		if (SceneManager.GetActiveScene ().name == "Level1_TiledMap") {
			fireSize = 1f;
		} else {
			fireSize = 2f;
		}
	}

	// Use this for initialization
	public override void Start () {
		base.Start ();

		ChangeState (new IdleState ());
	}
	
	// Update is called once per frame
	void Update () {
		currentState.Execute ();

		LookAtTarget ();
	
	}

	private void LookAtTarget(){
		if (target != null) {
			float xDir = target.transform.position.x - transform.position.x;

			if (xDir < 0 && facingRight || xDir > 0 && !facingRight) {
				ChangeDirection ();
			}
		}
	}


	public void ChangeState(IEnemyState newState){
		if (currentState != null) { //If there already exist a state, exit it. 
			currentState.Exit ();
		}
		currentState = newState;
		currentState.Enter (this);
	}

	public void Move(){
		MyAnimator.SetFloat ("speed", 1);

		transform.Translate (new Vector3(GetDirection () * movementSpeed * Time.deltaTime, 0, 0));
	}

	public float GetDirection(){

		return facingRight ? -1f : 1f;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "PlayerSnow" || other.tag == "PlayerCloud") {
			
			if(GameManager.Instance.Bleeding == false){
				GameManager.Instance.Bleeding = true;
				GameManager.Instance.DecreaseHealth (40f);
				if (GameManager.Instance.Health <= 0) {
					//GameManager.Instance.RestartGame ();
					//transform.parent.gameObject.AddComponent<GameOver>();
					GameManager.Instance.LoseGame();
				}
			}

		}

		else currentState.OnTriggerEnter(other);
	}

	[SerializeField]
	private GameObject enemySelf;

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "PlayerSnow" || other.tag == "PlayerCloud") {
			//Debug.Log ("Enemy died");
			//Destroy (enemySelf); // the health is deducted, and enemy died
		}
	}

}
