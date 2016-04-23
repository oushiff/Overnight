using UnityEngine;
using System.Collections;

public class panel : MonoBehaviour {
	public CanvasGroup CG;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (GameManager.Instance.isLose) {
			showPanel ();
			GameManager.Instance.ResetLoseGame ();
		}
	}
	void showPanel(){
		Time.timeScale = 0;
		CG.alpha = 1;
		CG.interactable = true;
		CG.blocksRaycasts = true;
		CG.ignoreParentGroups = true;
	}
}
