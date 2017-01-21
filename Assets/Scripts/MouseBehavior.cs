﻿using UnityEngine;
using System.Collections;

public class MouseBehavior : MonoBehaviour {

	public GameObject ring;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			Vector3 inM = Input.mousePosition;
			Vector3 inMod = new Vector3(inM.x, inM.y, 1f);
			GameObject ring = (GameObject) Instantiate(this.ring, Camera.main.ScreenToWorldPoint(inMod), Quaternion.identity);
			ring.GetComponent<WaveBehavior>().maxSize = .05f;
			ring.GetComponent<WaveBehavior>().ringWidth = .00001f;
			ring.GetComponent<WaveBehavior>().expansionSpeed = .005f;
			ring.GetComponent<WaveBehavior>().SetColor(Color.white);
		}
	}
}
