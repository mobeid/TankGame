using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax, zMin, zMax;
}

public class TankControl : MonoBehaviour {

	public Boundary boundary;
	public Transform turret;
	public Transform canon;
    public Transform centerOfMass;

    // For wheels
    public Transform wheelRotFL;
	public Transform wheelRotFR;
	public Transform wheelRotRL;
	public Transform wheelRotRR;
    public Transform wheelSteerLeft;
    public Transform wheelSteerRight;

    public WheelCollider wheelFL;
	public WheelCollider wheelFR;
	public WheelCollider wheelRL;
	public WheelCollider wheelRR;

    public float maxTorque;
    public float maxSteerAngle;
	public float maxSpeed = 150;
	public float maxReverseSpeed = 50;
    public float currentSpeed;
    public float brakePower = 25;

	// Use this for initialization
	void Start () {
	
	// Change the center of mass to make the tank more stable.
    GetComponent<Rigidbody>().centerOfMass = centerOfMass.localPosition;

	}

    void FixedUpdate()
    {
        TankMotion();
        AnimateTankComponents();

        // Add force to prevent tank from flipping
        //rigidbody.AddForce(-transform.up * rigidbody.velocity.magnitude);

    }


    // ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //

    // Tank motion control
    void TankMotion()
    {

        float steer = Input.GetAxis("Horizontal");                // This method will have to be changed to allow for using the arrows for something else
        float gas = Input.GetAxis("Vertical");

        // Map Boundries
        GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
                );

        // Move Tank
        wheelRL.motorTorque = maxTorque * gas;
        wheelRR.motorTorque = maxTorque * gas;
        // Steer Tank
        wheelFL.steerAngle = maxSteerAngle * steer;
        wheelFR.steerAngle = maxSteerAngle * steer;

        // Decelerate if buttons are not pressed
        if (Input.GetButton("Vertical") == false)
        {
            wheelRL.brakeTorque = brakePower;
            wheelRR.brakeTorque = brakePower;
        }
        else
        {
            wheelRL.brakeTorque = 0;
            wheelRR.brakeTorque = 0;
        }

        // Control speed limit (using the formula for calculating speed (KM/Hr): 2 * PI * Wheel Radius * RPM)
        if (currentSpeed < maxSpeed)
        {
            currentSpeed = 2 * 22 / 7 * wheelRL.radius * wheelRL.rpm * 60 / 1000;
            currentSpeed = Mathf.Round(currentSpeed);
        }
        else
        {
            wheelRR.motorTorque = 0;
            wheelRL.motorTorque = 0;
        }

    }



    // ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //

    // Tank Components and Animations
    void AnimateTankComponents()
    {

        // Turret control and animation
        float turretAllowedAngle = 0;
        if (Input.GetKey(KeyCode.K))
        {
            turretAllowedAngle = Mathf.Clamp(turretAllowedAngle -= 30, -90, 90);
            turret.Rotate(0, Time.deltaTime * turretAllowedAngle, 0);
        }

        if (Input.GetKey(KeyCode.Semicolon))
        {
            turretAllowedAngle = Mathf.Clamp(turretAllowedAngle += 30, -90, 90);
            turret.Rotate(0, Time.deltaTime * turretAllowedAngle, 0);
        }

        // Canon control and animation
        float canonAllowedAngle = 0;
        if (Input.GetKey(KeyCode.O))
        {
            canonAllowedAngle -= 10;
            //canonAllowedAngle = Mathf.Clamp(canonAllowedAngle, -90, 90);
            canon.Rotate(Time.deltaTime * canonAllowedAngle, 0, 0);
        }

        if (Input.GetKey(KeyCode.L))
        {
            canonAllowedAngle += 10;
            //canonAllowedAngle = Mathf.Clamp(canonAllowedAngle, -90, 90);
            canon.Rotate(Time.deltaTime * canonAllowedAngle, 0, 0);
        }


        //Debug.Log("Angle for canon is :" + canon.localEulerAngles.x);

        // Rotate wheels as Tank is in motion
        wheelRotFL.Rotate(wheelFL.rpm / 60 * 350 * Time.deltaTime, 0, 0);
        wheelRotFR.Rotate(wheelFR.rpm / 60 * 350 * Time.deltaTime, 0, 0);
        wheelRotRL.Rotate(wheelRL.rpm / 60 * 350 * Time.deltaTime, 0, 0);
        wheelRotRR.Rotate(wheelRR.rpm / 60 * 350 * Time.deltaTime, 0, 0);

        // Angulate wheels while steering
        float wheelSteerRotation = 0f;
        wheelSteerRotation += Input.GetAxis("Horizontal") * maxSteerAngle;
        wheelSteerLeft.localEulerAngles = new Vector3(transform.localEulerAngles.x, wheelSteerRotation, transform.localEulerAngles.z);
        wheelSteerRight.localEulerAngles = new Vector3(transform.localEulerAngles.x, wheelSteerRotation, transform.localEulerAngles.z);
    }


}
