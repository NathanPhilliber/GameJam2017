using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverBehavior : MonoBehaviour {

	public GameObject wave;
	public Text text;

	// Use this for initialization
	void Start () {
		text.text = GameObject.FindGameObjectWithTag("ScoreSaver").GetComponent<ScoreSaverBehavior>().finalScore + "";
	}
	
	// Update is called once per frame
	void Update () {
		if(Random.Range(0, 75) == 0) {
			GameObject ring = (GameObject) Instantiate(wave, new Vector3(Random.Range(-3,3),Random.Range(-3,3),0), Quaternion.identity);
			ring.GetComponent<WaveBehavior>().maxSize = Random.Range(.3f,4);
			ring.GetComponent<WaveBehavior>().ringWidth = .00001f;
			ring.GetComponent<WaveBehavior>().expansionSpeed = .001f*Random.Range(1,8);
			ring.GetComponent<WaveBehavior>().SetColor(new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f), .1f));
			ring.GetComponent<WaveBehavior>().shake = false;
		}

		if(Input.GetButtonDown("Fire1")) {
			SceneManager.LoadScene(0, LoadSceneMode.Single);
		}
	}
}
