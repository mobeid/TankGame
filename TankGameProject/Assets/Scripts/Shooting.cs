using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	
	public Rigidbody shell;
	public float shootForce;
	public Transform shootPosition;

    // Use this for initialization
    void Start () {
        
		
	}
	
	void Update() {

		// Shooting Shells
		if(Input.GetButtonDown("Jump"))
		{
			// Fire
			Rigidbody initShell = Instantiate(shell, shootPosition.position, shootPosition.rotation)as Rigidbody;
			initShell.velocity = transform.TransformDirection (new Vector3(0, 0, shootForce));
		}
		
		
	}
}
