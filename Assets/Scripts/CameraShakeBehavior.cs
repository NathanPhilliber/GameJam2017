using UnityEngine;
using System.Collections;

public class CameraShakeBehavior : MonoBehaviour {

	private Vector3 originalLocation;

	void Start () {
	    WaveBehavior.numWaves = 0;
		originalLocation = transform.position;
	}

	void FixedUpdate(){
		if((WaveBehavior.numWaves > 5 && Random.Range(0, 50/WaveBehavior.numWaves) == 0) || WaveBehavior.numWaves > 15) {
			ShakeCamera(.2f);
		}

		if(!transform.position.Equals(originalLocation)) {
			transform.position = Vector3.MoveTowards(transform.position, originalLocation, .05f);
		}
	}

	public void ShakeCamera(float shakeMax){
		transform.Translate(new Vector3(Random.Range(-shakeMax, shakeMax), Random.Range(-shakeMax, shakeMax), 0));
	}
}
