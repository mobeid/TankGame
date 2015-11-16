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

    void LateUpdate()
    {

        float wantedAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;
        float myAngle = transform.eulerAngles.y;
        float myHeight = transform.position.y;

        myAngle = Mathf.LerpAngle(myAngle, wantedAngle, rotationDamping * Time.deltaTime);
        myHeight = Mathf.Lerp(myHeight, wantedHeight, heightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, myAngle, 0);

        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        transform.LookAt(target);


    }
}