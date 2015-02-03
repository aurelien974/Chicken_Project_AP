using UnityEngine;
using System.Collections;

public class goldChicken : MonoBehaviour {

	private int numberOfGoldChickenFound;

	private particlesGeneration particlesScript;
	public ParticleSystem particles;


	// Use this for initialization
	void Start () {
	
		particlesScript = transform.GetComponent<particlesGeneration>();

		numberOfGoldChickenFound = 0;
		particles.startColor = particlesScript.colors[numberOfGoldChickenFound];

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {

		if(col.gameObject.tag == "goldChicken") {

			numberOfGoldChickenFound++;
			//col.gameObject.animation;
			col.gameObject.collider.enabled = false;
			Debug.Log(numberOfGoldChickenFound);


		}

	}
}
