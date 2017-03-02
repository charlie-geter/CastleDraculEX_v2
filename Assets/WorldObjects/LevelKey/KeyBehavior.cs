using UnityEngine;
using System.Collections;



public class KeyBehavior : MonoBehaviour {
	
	public Transform player;
	public Transform gate;
	public Transform HUD;
	
	Text t;// = new Text();
	
	void Start () {
		t = HUD.GetComponent<Text>();
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.name == player.name) {
			t.displaytext = "It's an old, rusted key.";
			Destroy(this.gameObject);
			//transform.renderer.enabled = false; //turn off renderer
			//PlayerControl pc = other.GetComponent<PlayerControl>();
			Player pc = other.GetComponent<Player>();
			pc.hasKey1 = true;
		}
	
	}
}
