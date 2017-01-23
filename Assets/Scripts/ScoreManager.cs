using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public Text text;
	public GameObject praiseParticle;
	private int delayFrames = 10;
	private int delayCounter = 0;

	public int scoreDisplayed;
	public int totalScore;
	private SoundManager sound;
	private int goodShown = 0;

	void Start () {
		totalScore = 0;
		sound = Camera.main.GetComponent<SoundManager>();

	}
	

	void FixedUpdate () {


		if(scoreDisplayed >= 100 && goodShown == 0) {
			GameObject spawn = (GameObject) Instantiate(praiseParticle);
			Destroy(spawn, 3);
			goodShown++;
		} else if(scoreDisplayed >= 1000 && goodShown == 1) {
			GameObject spawn = (GameObject) Instantiate(praiseParticle);
			Destroy(spawn, 3);
			goodShown++;
		}else if(scoreDisplayed >= 10000 && goodShown == 2) {
			GameObject spawn = (GameObject) Instantiate(praiseParticle);
			Destroy(spawn, 3);
			goodShown++;
		}
		else if(scoreDisplayed >= 100000 && goodShown == 3) {
			GameObject spawn = (GameObject) Instantiate(praiseParticle);
			Destroy(spawn, 3);
			goodShown++;
		} else if(scoreDisplayed >= 100000 && goodShown == 4) {
			GameObject spawn = (GameObject) Instantiate(praiseParticle);
			Destroy(spawn, 3);
			goodShown++;
		}else if(scoreDisplayed >= 1000000 && goodShown == 5) {
			GameObject spawn = (GameObject) Instantiate(praiseParticle);
			Destroy(spawn, 3);
			goodShown++;
		}else if(scoreDisplayed >= 10000000 && goodShown == 6) {
			GameObject spawn = (GameObject) Instantiate(praiseParticle);
			Destroy(spawn, 3);
			goodShown++;
		}



		if(scoreDisplayed != totalScore) {
			if(totalScore - scoreDisplayed <= 10) {
				text.color = Color.white;
				delayFrames = 10;
			}else if(totalScore - scoreDisplayed <= 30) {
				text.color = new Color(1, .8f, .8f);
				delayFrames = 5;
				scoreDisplayed++;
			}else if(totalScore - scoreDisplayed <= 60) {
				text.color = new Color(1, .7f, .7f);
				delayFrames = 2;
				scoreDisplayed += 2;
			}else if(totalScore - scoreDisplayed <= 500) {
				text.color = new Color(1, .6f, .6f);
                delayFrames = 1;
                scoreDisplayed += 25;
            }else if(totalScore - scoreDisplayed <= 1000) {
				text.color = new Color(1, .5f, .5f);
                 delayFrames = 1;
                 scoreDisplayed += 50;
			} else if(totalScore - scoreDisplayed <= 10000) {
				text.color = new Color(1, .4f, .4f);
				delayFrames = 1;
				scoreDisplayed += 100;
			}else if(totalScore - scoreDisplayed <= 100000) {
				text.color = new Color(1, .4f, .4f);
				delayFrames = 1;
				scoreDisplayed += 500;
			}else if(totalScore - scoreDisplayed <= 1000000) {
				text.color = new Color(1, .3f, .3f);
				delayFrames = 1;
				scoreDisplayed += 1000;
			}else {
				text.color = new Color(1, .2f, .2f);
                delayFrames = 1;
                scoreDisplayed += 10000;
            }

			if(delayCounter >= delayFrames) {
				delayCounter = 0;
				scoreDisplayed++;
				text.text = scoreDisplayed + "";
				if(totalScore - scoreDisplayed >= 5) {
					sound.PlayScoreUp();
				}
			}
			else {
				delayCounter++;
			}

		}
	}

	public void AddScore(int score){
		totalScore += score;
	}
}
