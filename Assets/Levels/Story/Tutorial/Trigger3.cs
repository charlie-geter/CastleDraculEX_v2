using UnityEngine;
using System.Collections;

public class Trigger3 : MonoBehaviour {
	
	public Transform myHUD;
	public Transform player;
	Text t;

	void Start () {
		t = (Text) myHUD.GetComponent("Text");
	}
	
		void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
		t.displaytext = "The sound is getting quieter. Maybe I can find someplace to hide next time.";
		}
	}
}
