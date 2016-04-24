using UnityEngine;
//using CnControls;
using System.Collections;
using UnityEngine.SceneManagement;

public class CloudController : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public float MaxSpeed;
	public float speedFactor;
	private Rigidbody2D rb2d;
	public VirtualJoystick joystick;
	public HeroTransform heroTransform;
	public bool m_Grounded = true;
	//Use the two store floats to create a new Vector2 variable movement.
	private Vector2 movement;
	public GameObject cloudObject;
	public int i;
	private bool isCloud = false;
	public float ballRadius;

	private Vector3 outOfScreen;
	public PlayerController playerController;
	public Vector3 lastPosition;

    
	void Awake(){
		rb2d = GetComponent<Rigidbody2D> ();
		isCloud = false;
		outOfScreen = new Vector3 (-40f, 0f, 0f);

		Scene scene = SceneManager.GetActiveScene(); 

		if (scene.name == "Level1_TiledMap") {
			ballRadius = 0.5f;
			MaxSpeed =2f;
		}
		else {
			ballRadius = 2f;
			MaxSpeed =8f;
		}

	}

	void Start () {
		
		//rb2d.drag = 0.5f;
		m_Grounded=false;

		speed = 20f;
		speedFactor = 5f;
		i = 0;
		transform.localScale = new Vector3(ballRadius,ballRadius,0);
	}


	void FixedUpdate()
	{
		bool isBtnClick = heroTransform.isCloudTransform;

		if (isCloud)
			lastPosition = transform.position;
		
		if (isBtnClick && GameManager.Instance.isCameraFix) {
			heroTransform.isCloudTransform = false;
			isBtnClick = false;
			isCloud = !isCloud;
			if (!isCloud) {
				Debug.Log ("Cloud Disappear!!!!");
				//cloudObject.SetActive (false);
				//Destroy(cloudObject);

				GameManager.Instance.Status = "PlayerSnow";
                transform.position = outOfScreen;
				transform.FindChild("CloudTrail").GetComponent<TrailRenderer>().enabled = false;
			} else {
				Debug.Log ("Cloud re-appear!!!!");
				//GameObject cloudObject = GameObject.Find ("CloudBall");
				//cloudObject.SetActive (true);
				GameManager.Instance.Status = "PlayerCloud";
				transform.position = playerController.lastPosition;
				transform.FindChild("CloudTrail").GetComponent<TrailRenderer>().enabled = true;
				//GameObject.Instantiate(cloudObject,transform.position/* new Vector3(5.6f,12.5f,0f)*/,Quaternion.identity);
			}
			GameManager.Instance.isCameraFix = true;
			GameManager.Instance.isCameraReturn = true;
		}

		if (!isCloud) {
			transform.position = outOfScreen;
			return;
		}

		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal") * speedFactor;

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical") * speedFactor;

		movement = new Vector2 (moveHorizontal, moveVertical); 

		movement.x = joystick.Horizontal () * speedFactor;

		movement.y = joystick.Vertical () * speedFactor;

		float moveMag = movement.magnitude;

		if ( moveMag > MaxSpeed) {
			movement = movement * MaxSpeed / moveMag; 
		}

		rb2d.velocity = new Vector2 (movement.x , movement.y);


	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "minusGravityTrigger")
        {
            Debug.Log("Cloud hit the minusGravityTrigger");
            rb2d.gravityScale = -30;
        }
    }

}
