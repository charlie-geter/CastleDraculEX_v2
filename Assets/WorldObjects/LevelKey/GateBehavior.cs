using UnityEngine;
using System.Collections;

public class GateBehavior : MonoBehaviour {
	public Transform player;
	public Transform HUD;
	public string nextLevel;
	Text t;// = new Text();
	
	void Start () {
		t = HUD.GetComponent<Text>();
	}
	
	void OnTriggerEnter(Collider other) {

		if (other.name == player.name) {
			//PlayerControl pc = other.GetComponent<PlayerControl>();
			Player pc = other.GetComponent<Player>();
			if(pc.hasKey1) {
				t.displaytext = "Congratulations, you won!";
				Application.LoadLevel(nextLevel);
			}
			else {
				t.displaytext = "That is the gate. You need to get the key before you can enter.";
				
			}
		}
			
	}
}
