using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;
	Vector3 offset  = new Vector3 (0, 0, -1000);
	

	
	void Update () {
		transform.position =  target.position + offset;
	}
	
}
