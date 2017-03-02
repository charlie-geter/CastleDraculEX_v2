using UnityEngine;
using System.Collections;

public class flicker : MonoBehaviour {

	float minOnFlickerSpeed = 1.0f;
	float maxOnFlickerSpeed = 1.3f;
	float minOffFlickerSpeed = 0.1f;
	float maxOffFlickerSpeed = 0.2f;
	
	float off_screen_distance = 30;
	float nearby_distance = 10;
	
	GameObject player;
	
	void Start() {
		gameObject.light.enabled = false;	
		player = GameObject.FindWithTag("Player");	
	}
	
	float dist = 100;
	bool light_on = false;
	bool coroutine_running = false;
	void Update () {
		dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
		if (nearby () && !light_on && !coroutine_running) {
			//Debug.Log ("starting coroutine! first time");
			coroutine_running = true;
			StartCoroutine("initiateflicker");
			light_on = true;
			
		}
		
		if (!onScreen () && light_on && coroutine_running) {
			//Debug.Log("STOPPING COROUTINE!");
			coroutine_running = false;
			StopCoroutine("initiateflicker");
			gameObject.light.enabled = false;
			
		}
		
		if (onScreen() && light_on && !coroutine_running) {
			//Debug.Log ("starting coroutine - return to screen");
			coroutine_running = true;
			StartCoroutine("initiateflicker");
			
		}

	}
	
	bool onScreen() {
		return dist < off_screen_distance;	
	}
	
	bool nearby() {
		return dist < nearby_distance;
	}
	
	float wait_time;
	
	IEnumerator initiateflicker () {
		while (coroutine_running) {
			gameObject.light.enabled = true;
			float wait_time = Random.Range(minOnFlickerSpeed, maxOnFlickerSpeed );
			yield return new WaitForSeconds(wait_time);
			
			gameObject.light.enabled = false;
			wait_time = Random.Range(minOffFlickerSpeed, maxOffFlickerSpeed );
			yield return new WaitForSeconds(wait_time);
		}
	}
	
}
