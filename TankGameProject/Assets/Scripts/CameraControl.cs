using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	public Camera MainCam;
	public Camera ThirdPerCamCam;
	public Camera FirstPerCam;
	public Camera TopView;

	void Start() {
		MainCam.enabled = false;
		ThirdPerCamCam.enabled = true;
		FirstPerCam.enabled = false;
		TopView.enabled = false;
	}

    void Update () {
		if (Input.GetKeyDown("1"))
		{
            // Toggle to 3rd person cam
            MainCam.enabled = false;
			ThirdPerCamCam.enabled = true;
			FirstPerCam.enabled = false;
			TopView.enabled = false;
            Debug.Log("You are on ThirdPerson Cam");
		}
		if (Input.GetKeyDown("2"))
        {
            // Toggle to 1st person cam
            MainCam.enabled = false;
			ThirdPerCamCam.enabled = false;
			FirstPerCam.enabled = true;
			TopView.enabled = false;
            Debug.Log("You are on FirstPerson Cam");
        }
		if (Input.GetKeyDown("3"))
        {
            // Toggle to top cam
            MainCam.enabled = false;
			ThirdPerCamCam.enabled = false;
			FirstPerCam.enabled = false;
			TopView.enabled = true;
            Debug.Log("You are on Top Cam");
        }
		if (Input.GetKeyDown("4"))
        {
            // Toggle to main cam
            MainCam.enabled = true;
			ThirdPerCamCam.enabled = false;
			FirstPerCam.enabled = false;
			TopView.enabled = false;
            Debug.Log("You are on Main Cam");
        }

	}

}