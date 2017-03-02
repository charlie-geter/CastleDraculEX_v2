using UnityEngine;
using System.Collections;

public class health : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.tag == "Player") {
			
			//Component playerHealthScript = other.gameObject.GetComponent("PlayerControl");
			//PlayerControl pc = (PlayerControl) playerHealthScript;
			
			Component playerHealthScript = other.gameObject.GetComponent("Player");
			Player pc = (Player) playerHealthScript;
			pc.receiveHealthPack();
        	Destroy(this.gameObject);
		}
	}
}
