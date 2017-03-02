using UnityEngine;
using System.Collections;

public class TheEnd : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Application.LoadLevel("win");
			//Debug.Log("You win!");
		}
	}
}
