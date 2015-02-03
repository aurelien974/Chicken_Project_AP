using UnityEngine;
using System.Collections;

public class chickenMovement : MonoBehaviour {

	public Transform sphereTransform;
	public float distanceToGround = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(Vector3.Scale(sphereTransform.rigidbody.velocity, new Vector3(1,0,1)) != Vector3.zero) {

			transform.forward = Vector3.Scale(sphereTransform.rigidbody.velocity, new Vector3(1,0,1));

		}


	}

	void LateUpdate () {

		transform.position = new Vector3(sphereTransform.position.x, sphereTransform.position.y - distanceToGround, sphereTransform.position.z);

	}
}
