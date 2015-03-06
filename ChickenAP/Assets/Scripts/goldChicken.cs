using UnityEngine;
using System.Collections;

public class goldChicken : MonoBehaviour {

	public int numberOfGoldChickenFound;

	private particlesGeneration particlesScript;
	private ballMovement ballMvtScript;

	public ParticleSystem particles;

    public AudioSource chickenCrow;

	public string[] godSpotlightActivationOrder;

	private GameObject[] godChickenSpotlights;

	// Use this for initialization
	void Start () {
	
		particlesScript = transform.GetComponent<particlesGeneration>();
		ballMvtScript = GetComponent<ballMovement>();

		numberOfGoldChickenFound = 0;
		particles.startColor = particlesScript.colors[numberOfGoldChickenFound];

		godChickenSpotlights = GameObject.FindGameObjectsWithTag("chicken_god spotlight");

		foreach(GameObject spotlight in godChickenSpotlights) {

			spotlight.light.enabled = false;

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {

		if(col.gameObject.tag == "gold chicken") {

			numberOfGoldChickenFound++;

			if(numberOfGoldChickenFound < particlesScript.colors.Length) {

				ballMvtScript.currentMaxSpeed += ballMvtScript.speedWonByGoldChicken;

				particles.startColor = particlesScript.colors[numberOfGoldChickenFound];

			}

			if(numberOfGoldChickenFound <= godSpotlightActivationOrder.Length) {

				GameObject.Find ("Spotlight " + godSpotlightActivationOrder[numberOfGoldChickenFound-1]).light.enabled = true;
                GameObject.Find("Spotlight " + godSpotlightActivationOrder[numberOfGoldChickenFound - 1]).audio.Play();
			}

			col.gameObject.GetComponent<Animator>().SetBool("collected", true);
			col.gameObject.collider.enabled = false;
            chickenCrow.Play();

		}

	}
	
}
