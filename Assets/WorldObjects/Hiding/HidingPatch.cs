using UnityEngine;
using System.Collections;

public class HidingPatch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
{
	var player = GameObject.FindWithTag("Player");
	Debug.Log("Patch Collision Start");
	if (other.collider == player.collider) {
		Debug.Log("Patch player detected");
		HidingPlayer playerHidingScript = (HidingPlayer) player.gameObject.GetComponent("HidingPlayer");
		playerHidingScript.hidden = true;	
	}
	
}

void OnTriggerExit(Collider other)
{
	var player = GameObject.FindWithTag("Player");
	Debug.Log("Patch End Collision");
	if (other.collider == player.collider) {
		HidingPlayer playerHidingScript = (HidingPlayer) player.gameObject.GetComponent("HidingPlayer");
		playerHidingScript.hidden = false;	
	}
}
}
