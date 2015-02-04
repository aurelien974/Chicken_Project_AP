using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

	public Transform ballTransform;
	public Transform chickenTransform;
	public float rotationDamping = 8.0f;
	public float cameraHeight = 1.5f;
	public float cameraMinDistance = 3.0f;
	public float cameraMaxDistance = 15.0f;
	private ballMovement ballMovementScript;
    private Quaternion wantedRot;

	// Use this for initialization
	void Start () {

		ballMovementScript = ballTransform.GetComponent<ballMovement>();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void LateUpdate () {

		// Calculate the current rotation angles
        if (ballTransform.rigidbody.velocity != Vector3.zero)
        {
            wantedRot = Quaternion.LookRotation(ballTransform.rigidbody.velocity);
        }
        else
        {
            wantedRot = chickenTransform.rotation;
        }
		
		float wantedRotationAngleY = wantedRot.eulerAngles.y;
		float wantedRotationAngleX = wantedRot.eulerAngles.x;
		float wantedRotationAngleZ = wantedRot.eulerAngles.z;

		float currentRotationAngleY = transform.eulerAngles.y;
		float currentRotationAngleX = transform.eulerAngles.x;
		float currentRotationAngleZ = transform.eulerAngles.z;
		
		// Damp the rotation around the y-axis
		currentRotationAngleY = Mathf.LerpAngle (currentRotationAngleY, wantedRotationAngleY, rotationDamping * Time.deltaTime);
		currentRotationAngleX = Mathf.LerpAngle (currentRotationAngleX, wantedRotationAngleX, rotationDamping * Time.deltaTime);
		currentRotationAngleZ = Mathf.LerpAngle (currentRotationAngleZ, wantedRotationAngleZ, rotationDamping * Time.deltaTime);

		// Convert the angle into a rotation
		Quaternion currentRotation = Quaternion.Euler (currentRotationAngleX, currentRotationAngleY, currentRotationAngleZ);
        //Quaternion currentRotation = Quaternion.Euler(wantedRotationAngleX, wantedRotationAngleY, wantedRotationAngleZ);

		transform.position = chickenTransform.position;

		transform.rotation = currentRotation;

		float cameraDistance = cameraMinDistance + (cameraMaxDistance - cameraMinDistance) * ballTransform.rigidbody.velocity.magnitude / ballMovementScript.maxSpeed;

		transform.Translate(0, cameraHeight, -cameraDistance);

	}
}
