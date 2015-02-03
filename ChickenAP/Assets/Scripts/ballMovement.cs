using UnityEngine;
using System.Collections;

public class ballMovement : MonoBehaviour {

	public float playerSpeed = 40.0f;
	public float maxSpeed = 120.0f;
	public float decreaseFactorOnGround = 1.0f;
	public float decreaseFactorInAir = 0.1f;
	public float animationMaxSpeed = 4.0f;
	public float animationMinSpeed = 0.4f;
	public float respawnDistance = -40.0f;

	public Transform respawnPoint;

	public Animator playerAnimator;

	public Transform chickenTransform;

	private float distToGround;

	void Start () {

		distToGround = collider.bounds.extents.y;

	}

	public bool IsGrounded () {

		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

	}
	
	void FixedUpdate () {

		if(transform.position.y < respawnDistance) {

			rigidbody.velocity = Vector3.zero;
			transform.position = respawnPoint.transform.position;

		}

		if(rigidbody.velocity.magnitude > maxSpeed) {
			
			rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
			
		}

		if(IsGrounded()) {

			if(Mathf.Abs (Input.GetAxis("Vertical")) > 0.2) {

				rigidbody.AddForce(chickenTransform.forward * Input.GetAxis ("Vertical")* playerSpeed);

			}

			if(Mathf.Abs (Input.GetAxis("Horizontal")) > 0.2) {
				
				rigidbody.AddForce(chickenTransform.right * Input.GetAxis ("Horizontal")* playerSpeed);
				
			}

			if(Mathf.Abs (Input.GetAxis("Horizontal")) <= 0.2 && Mathf.Abs (Input.GetAxis("Vertical")) <= 0.2) {

				rigidbody.AddForce(Vector3.Scale(-rigidbody.velocity, new Vector3(decreaseFactorOnGround,0,decreaseFactorOnGround)));

			}


		} else {

			rigidbody.AddForce(Vector3.Scale(-rigidbody.velocity, new Vector3(decreaseFactorInAir,0,decreaseFactorInAir)));

		}

		if(rigidbody.velocity.magnitude > 1) {

			playerAnimator.SetBool ("running", true);
			playerAnimator.speed = animationMinSpeed + (animationMaxSpeed - animationMinSpeed) * rigidbody.velocity.magnitude / maxSpeed;

		} else {
			
			playerAnimator.SetBool ("running", false);
			
		}

	}
}
