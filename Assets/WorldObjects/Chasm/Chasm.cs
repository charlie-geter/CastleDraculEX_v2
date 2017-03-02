using UnityEngine;
using System.Collections;

public class Chasm : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		//Debug.Log("Is " + player.name + " == " + other.name);
		if (other.name == player.name) {
			//Debug.Log ("Found player!");
			Player pc = (Player) player.GetComponent("Player");
			pc.Health = 0;
		}
	}
}
