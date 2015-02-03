using UnityEngine;
using System.Collections;

public class particlesGeneration : MonoBehaviour {

	ballMovement ballMvt;

	public float emissionRateMin = 2.0f;
	public float emissionRateMax = 20.0f;
	public float emissionStartSpeedMin = 1.0f;
	public float emissionStartSpeedMax = 6.0f;

	public ParticleSystem particles;

	public Color[] colors = new Color[6];

	// Use this for initialization
	void Start () {
	
		ballMvt = transform.GetComponent<ballMovement>();

		//colors[0] = new Color(109,79,0);
		//colors[1] = Color.red;
		//colors[2] = Color.yellow;
		//colors[3] = new Color(255,130,0);
		//colors[4] = Color.blue;
		//colors[5] = Color.magenta;

	}

	// Update is called once per frame
	void Update () {
	
		if(ballMvt.IsGrounded() && rigidbody.velocity.magnitude > 1) {

			particles.enableEmission = true;
			particles.emissionRate = emissionRateMin + (emissionRateMax - emissionRateMin) * rigidbody.velocity.magnitude / ballMvt.maxSpeed;
			particles.startSpeed = emissionStartSpeedMin + (emissionStartSpeedMax - emissionStartSpeedMin) * rigidbody.velocity.magnitude / ballMvt.maxSpeed;
			
		} else {

			particles.enableEmission = false;

		}

	}
}
