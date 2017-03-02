using UnityEngine;
using System.Collections;

public class ItemFollower : MonoBehaviour {
	
	public Transform leader;
	public float speed = 3;
	public bool colliding = false;
	RaycastHit hit;
	float chase_radius = 10;
    int timer;
	//AudioSource[] myAudio = GetComponents(AudioSource);
	//AudioSource music = myAudio[0];
	//AudioSource damage = myAudio[1];
	// Use this for initialization
	void Start () {
		transform.LookAt(leader);
	}
	
	// Update is called once per frame
	void Update () {
	
		float distance = Vector3.Distance(leader.position, transform.position);
		Component playerHidingScript = leader.gameObject.GetComponent("HidingPlayer");
		HidingPlayer phs = (HidingPlayer) playerHidingScript;
		bool hidden = phs.hidden;
		//bool hidden = false;
		Component playerScript = leader.gameObject.GetComponent("Player");
		Player pc = (Player) playerScript;
		bool hasKey = pc.hasKey1;
		
		if(hasKey) {
			if(distance < chase_radius && hidden == false) { //chasing!
		   		transform.LookAt(leader);
		   		speed = 7;
				Color mycolor = transform.renderer.material.color;
				mycolor.a = 100;
		   		transform.renderer.material.color = mycolor;
	   		}
		}
	   	else { //not chasing
	   		transform.renderer.material.color = Color.grey;
			Color mycolor = transform.renderer.material.color;
			mycolor.a = 0;
	   		transform.renderer.material.color = mycolor;
	   		if (Random.Range(0, 100) <= 1)
	   		{
				transform.Rotate(0.0f,0.0f,Random.Range(30, 360), Space.World);
			}
			speed = 3;
	   	}
		
	   	
	   	if (colliding) {
   			transform.Rotate(0.0f,0.0f,Random.Range(30, 360), Space.World);
   		}
		rigidbody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);

	}

void OnTriggerEnter(Collider other)
{
	Collide(other);
}
	
void OnTriggerStay(Collider other) 
{
    Collide(other);
}

void OnTriggerExit(Collider other)
{
	//Debug.Log("End Collision");
    timer = 0;
	colliding = false;
}	
	
void Collide (Collider other) {
   if (other.name == leader.name && timer >= 2) {
        Component playerHealthScript = leader.gameObject.GetComponent("Player");
        Player pc = (Player) playerHealthScript;
        Component playerHidingScript = leader.gameObject.GetComponent("HidingPlayer");
		HidingPlayer phs = (HidingPlayer) playerHidingScript;
		
		if (!phs.hidden && pc.hasKey1) {
			pc.Health -= 4;
        	timer = 0;
		}
    	
	}
	else if (other.name == "HidingPlace") {
		transform.Rotate(0.0f,0.0f,Random.Range(90, 270), Space.World);
	}
	else if (other.name == "Gate") {}
	else if (other.name == "LevelKey") {}
	else if (other.tag == "Trigger") {}
	else {
		colliding = true;
	}	
	timer++;
}


}
