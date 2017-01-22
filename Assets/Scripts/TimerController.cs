using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimerController : MonoBehaviour {



    public float timeLeft = 121;

	Text text;

	public bool gameOver;
	int gameOverDelay = 45;

	private int redCounter = 20;
	private bool goingUp = true;

	public bool stopForReal = false;

	// Use this for initialization
	void Start () {
		gameOver = false;
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    timeLeft -= Time.deltaTime;
		if(timeLeft >= 0) {
			string minutes = Mathf.Floor(timeLeft / 60).ToString("0");
			string seconds = Mathf.Floor(timeLeft % 60).ToString("00");
			GetComponent<Text>().text = minutes + ":" + seconds;
		}
		else {
			gameOver = true;
			Camera.main.GetComponent<MouseBehavior>().GameOver();
		}

		if(timeLeft < 30) {

			if(timeLeft <= 11 && timeLeft >= 0) {
				Camera.main.GetComponent<SoundManager>().PlayBeep();
			}
			
			if(goingUp) {
				redCounter++;
				if(redCounter >= 100) {
					goingUp = false;
				}
				text.color = new Color(text.color.r, text.color.g - .0075f, text.color.b - 0.0075f, text.color.a);
			}
			else {
				redCounter--;
				if(redCounter <= 0) {
					goingUp = true;
					text.color = Color.white;
				}

				text.color = new Color(text.color.r, text.color.g + .0075f, text.color.b + 0.0075f, text.color.a);
			}
		}


	}



	void GameOver(){
		

		gameOverDelay--;
		Camera.main.GetComponent<SoundManager>().sourceAdrenaline.volume -= .005f;
		if(gameOverDelay <= 0 && GameObject.FindGameObjectsWithTag("Wave").Length == 0) {
			if(stopForReal == false) {
				stopForReal = true;
				gameOverDelay = 75;
			}
			else {
				SceneManager.LoadScene(2, LoadSceneMode.Single);
			}

		}

	}

	void FixedUpdate(){



		if(gameOver) {
			GameOver();
		}

	    InitialSetup set = Camera.main.GetComponent<InitialSetup>();
		if((int) timeLeft % 30 == 1 && GameObject.FindGameObjectsWithTag("Bubble").Length < 400 && timeLeft > 20){
            float randomRadius = Random.Range(0.1f, 1)/40;
            float randomX = Random.Range(-2f, 2f);
            float randomY = Random.Range(-2f, 2f);
            int randIndex = Random.Range(0, 6);
            Sprite[] sps = set.getSpriteArray();
            Color[] cs = set.getColorArray();

	        set.SpawnBubble(randomRadius, sps[randIndex], cs[randIndex], new Vector3(randomX, randomY, 0));
	    }
	}
}
