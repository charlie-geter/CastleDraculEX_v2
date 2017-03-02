using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {
	
	public Transform leader;
	public float speed = 3;
	float chase_speed = 10;
	public bool colliding = false;
	RaycastHit hit;
	float chase_radius = 15;
	public AudioClip damage;
    
    //timer for first colliding.
    float timer = 1;

    //Timer for staying in collision trigger.
    float timer2 = 2;
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
		
		if(distance < chase_radius) { //chasing!
            transform.LookAt(leader);
            if (hidden == false)
            {
                speed = chase_speed;
            }
            else
            {
                if (Random.Range(0, 100) <= 1)
                {
                    transform.Rotate(0.0f, 0.0f, Random.Range(30, 360), Space.World);
                }
                transform.forward = Vector3.zero - transform.forward;
                speed = 3;
                timer++;
            }
                Color mycolor = transform.renderer.material.color;
                mycolor.a = 100;
                transform.renderer.material.color = mycolor;

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
	//Debug.Log("Collision Start");
	
	if (other.name == leader.name && timer <= 0) {
		//Debug.Break();
		//Component playerHealthScript = leader.gameObject.GetComponent("PlayerControl");
		//PlayerControl pc = (PlayerControl) playerHealthScript;
	/*	Component playerHealthScript = leader.gameObject.GetComponent("Player");
		Player pc = (Player) playerHealthScript;
        Component playerHidingScript = leader.gameObject.GetComponent("HidingPlayer");
        HidingPlayer hp = (HidingPlayer)playerHidingScript;
        if (!hp.hidden)
        {
            //pc.Health -= 40;
            //audio.PlayOneShot(damage);
            timer = 1;
        }
		//damage.Play();*/
	}
	else if (other.name == "HidingPlace") {}
	else if (other.name == "Gate") {}
	else if (other.name == "LevelKey") {}
	else if (other.tag == "Trigger") {}
	else {
		colliding = true;
	}
    timer = 0;
}

void OnTriggerStay(Collider other) 
{
    if (other.name == leader.name && timer2 <= 0) {
        Component playerHealthScript = leader.gameObject.GetComponent("Player");
        Player pc = (Player) playerHealthScript;
        Component playerHidingScript = leader.gameObject.GetComponent("HidingPlayer");
        HidingPlayer hp = (HidingPlayer)playerHidingScript;
        if (!hp.hidden)
        {
            pc.Health -= 40;
            audio.PlayOneShot(damage);
            timer2 = 0.7f;
        }
    }
    timer2 -= Time.deltaTime;
}

void OnTriggerExit(Collider other)
{
	//Debug.Log("End Collision");
    timer2 = 0.2f;
	colliding = false;
}

}
