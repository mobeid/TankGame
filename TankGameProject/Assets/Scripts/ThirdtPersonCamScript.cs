using UnityEngine;
using System.Collections;

public class ThirdtPersonCamScript : MonoBehaviour {
	
	public Transform target;
	public float distance = 10.0f;
	public float height = 5.0f;
	public float rotationDamping = 3.0f;
	public float heightDamping = 2.0f;
	public float zoomRatio = 5.0f;
	private Vector3 rotationVector;
	
	void Start() {


	}
	
	void LateUpdate() {
		
		var wantedAngle = target.eulerAngles.y;
		var wantedHeight = target.position.y + height;
		var myAngle = transform.eulerAngles.y;
		var myHeight = transform.position.y;
		
		myAngle = Mathf.LerpAngle (myAngle, wantedAngle, rotationDamping * Time.deltaTime);
		myHeight = Mathf.Lerp (myHeight, wantedHeight, heightDamping * Time.deltaTime);
		
		var currentRotation = Quaternion.Euler (0, myAngle, 0);
		
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;
		
		float yPos = transform.position.y;
		yPos = myHeight;
		
		transform.LookAt (target);
		
		
	}
}