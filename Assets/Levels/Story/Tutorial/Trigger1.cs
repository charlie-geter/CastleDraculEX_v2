using UnityEngine;
using System.Collections;

public class Trigger1 : MonoBehaviour {
	
	public Transform myHUD;
	public Transform player;
	Text t;

	// Use this for initialization
	void Start () {
		t = (Text) myHUD.GetComponent("Text");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
		t.displaytext = "I think I hear something...";
		}
	}
}
