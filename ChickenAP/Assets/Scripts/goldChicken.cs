using UnityEngine;
using System.Collections;

public class goldChicken : MonoBehaviour {

	public int numberOfGoldChickenFound;

	private particlesGeneration particlesScript;
	private ballMovement ballMvtScript;

	public ParticleSystem particles;

	// Use this for initialization
	void Start () {
	
		particlesScript = transform.GetComponent<particlesGeneration>();
		ballMvtScript = GetComponent<ballMovement>();

		numberOfGoldChickenFound = 0;
		particles.startColor = particlesScript.colors[numberOfGoldChickenFound];

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {

		if(col.gameObject.tag == "gold chicken") {

			if(numberOfGoldChickenFound < particlesScript.colors.Length) {

				numberOfGoldChickenFound++;

				ballMvtScript.currentMaxSpeed += ballMvtScript.speedWonByGoldChicken;

				particles.startColor = particlesScript.colors[numberOfGoldChickenFound];

			}

			col.gameObject.GetComponent<Animator>().SetBool("collected", true);
			col.gameObject.collider.enabled = false;

		}

	}
	
}
