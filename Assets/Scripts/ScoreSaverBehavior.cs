using UnityEngine;
using System.Collections;

public class ScoreSaverBehavior : MonoBehaviour {
	
	public int finalScore;

	void Awake(){
		DontDestroyOnLoad(this);
	}

	// Use this for initialization
	void Start () {
		finalScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("escape")) {
			Application.Quit();
		}
	}
}
