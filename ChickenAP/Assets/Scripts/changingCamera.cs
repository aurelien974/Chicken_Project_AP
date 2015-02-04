using UnityEngine;
using System.Collections;

public class changingCamera : MonoBehaviour {

	public Camera mainCamera;
	public Camera camera2;
	public Camera camera3;

	// Use this for initialization
	void Start () {
	
		mainCamera.enabled = true;
        mainCamera.GetComponent<AudioListener>().enabled = true;

		camera2.enabled = false;
        camera2.GetComponent<AudioListener>().enabled = false;

		camera3.enabled = false;
        camera3.GetComponent<AudioListener>().enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.F)) {

			mainCamera.enabled = true;
            mainCamera.GetComponent<AudioListener>().enabled = true;

			camera2.enabled = false;
            camera2.GetComponent<AudioListener>().enabled = false;

			camera3.enabled = false;
            camera3.GetComponent<AudioListener>().enabled = false;

		} else if(Input.GetKeyDown(KeyCode.G)) {
			
			mainCamera.enabled = false;
            mainCamera.GetComponent<AudioListener>().enabled = false;

			camera2.enabled = true;
            camera2.GetComponent<AudioListener>().enabled = true;

			camera3.enabled = false;
            camera3.GetComponent<AudioListener>().enabled = false;
			
		} else if(Input.GetKeyDown(KeyCode.H)) {
			
			mainCamera.enabled = false;
            mainCamera.GetComponent<AudioListener>().enabled = false;

			camera2.enabled = false;
            camera2.GetComponent<AudioListener>().enabled = false;

			camera3.enabled = true;
            camera3.GetComponent<AudioListener>().enabled = true;
			
		}

	}
}
