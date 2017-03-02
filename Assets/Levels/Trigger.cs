using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {
	
	public string text = "";
	GameObject player;
	public Transform myHUD;
	Text t;
	
	void Start() {
		//Debug.Log ("started trigger");
		player = GameObject.FindWithTag("Player");
		t = (Text) myHUD.GetComponent("Text");
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log ("triggered");
		if (other.tag == "Player") {
			//Debug.Log ("player triggered");
			t.displaytext = text;
		}
	}
}
