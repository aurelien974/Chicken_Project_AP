using UnityEngine;
using System.Collections;

public class ballMovement : MonoBehaviour {

	public float playerSpeedForce = 40.0f;
	public float maxSpeed = 100.0f;
	public float currentMaxSpeed;
	public float speedWonByGoldChicken = 16.0f;
	public float decreaseFactorOnGround = 1.0f;
	public float decreaseFactorInAir = 0.1f;
	public float animationMaxSpeed = 4.0f;
	public float animationMinSpeed = 0.4f;
	public float respawnDistance = -40.0f;

	public Transform respawnPoint;

	public Animator playerAnimator;

	public Transform chickenTransform;

	private float distToGround;

	private particlesGeneration particlesScript;

    public AudioSource collisionSound;

	void Start () {

		distToGround = collider.bounds.extents.y;
		particlesScript = GetComponent<particlesGeneration>();
		currentMaxSpeed = maxSpeed - (particlesScript.colors.Length - 1) * speedWonByGoldChicken;

	}

	public bool IsGrounded () {

		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

	}
	
	void FixedUpdate () {

		if(transform.position.y < respawnDistance) {

			rigidbody.velocity = Vector3.zero;
			transform.position = respawnPoint.transform.position;

		}

		if(rigidbody.velocity.magnitude > currentMaxSpeed) {
			
			rigidbody.velocity = rigidbody.velocity.normalized * currentMaxSpeed;
			
		}

		if(IsGrounded()) {

			if(Mathf.Abs (Input.GetAxis("Vertical")) > 0.2) {

                if ((rigidbody.velocity.magnitude > 0.5 && Input.GetAxis("Vertical") <= 0.2) || Input.GetAxis("Vertical") > 0.2)
                {
                    rigidbody.AddForce(chickenTransform.forward * Input.GetAxis("Vertical") * playerSpeedForce);

                }

			}

			if(Mathf.Abs (Input.GetAxis("Horizontal")) > 0.2) {
				
				rigidbody.AddForce(chickenTransform.right * Input.GetAxis ("Horizontal")* playerSpeedForce);
				
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

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "chicken_god colliders")
        {

            collisionSound.Play();

        }

    }
}
