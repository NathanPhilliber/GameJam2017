using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenuButtonBehavior : MonoBehaviour {

	public GameObject ring;
	public GameObject logo;
    public bool logoFade = false;

    private Rigidbody2D rb;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }


    void OnTriggerEnter2D(Collider2D other){
        Camera.main.GetComponent<ScreenTransitionImageEffect>().isFading = true;
		if(other.CompareTag("Wave")) {
			other.GetComponent<WaveBehavior>().maxSize = 0;
			Pop();
		}
    }

    void Pop(){
		for(int i = 0; i < 3; i++) {
			GameObject ring = (GameObject)Instantiate(this.ring, transform.position, Quaternion.identity);
			ring.GetComponent<WaveBehavior>().maxSize = 20.5f;
			ring.GetComponent<WaveBehavior>().shake = false;
			ring.GetComponent<WaveBehavior>().ringWidth = .00001f;
			ring.GetComponent<WaveBehavior>().expansionSpeed = .049f - i*.005f;
			ring.GetComponent<WaveBehavior>().SetColor(new Color(0f, .9f, .7f));
			ring.GetComponent<WaveBehavior>().comboCounter = 0;
		}

		Camera.main.GetComponent<ScreenTransitionImageEffect>().activated = true;

		Destroy(gameObject);
	}
}
