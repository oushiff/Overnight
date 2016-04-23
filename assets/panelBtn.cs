using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class panelBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void onClickRestart(){
		Time.timeScale = 1;
		GameManager.Instance.RestartGame ();
	}
	public void onClickMenu(){
		SceneManager.LoadScene ("StartPage");
	}
}
