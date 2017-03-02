using UnityEngine;
using System.Collections;

public class Trigger2 : MonoBehaviour {
	
	public Transform myHUD;
	public Transform player;
	Text t;

	void Start () {
		t = (Text) myHUD.GetComponent("Text");
	}
	
		void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
		t.displaytext = "That noise is getting louder. I feel like there might be something in the room with me. I should be careful.";
		}
	}
}
