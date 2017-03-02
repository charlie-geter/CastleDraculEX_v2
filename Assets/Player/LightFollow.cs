using UnityEngine;
using System.Collections;

public class LightFollow : MonoBehaviour {
	
	public Transform target;
	
	void Update () {
		transform.position =  target.position;
	}
}
