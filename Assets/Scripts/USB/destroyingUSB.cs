using UnityEngine;
using System.Collections;

public class destroyingUSB : MonoBehaviour {

	private GameObject cameraObj;
	private Camera mainCamera;
	public bool isUSBDead{ get; set; }
	private Transform _USBTransform;
	
	void Awake(){
		cameraObj = GameObject.FindGameObjectWithTag ("MainCamera");
		mainCamera = cameraObj.GetComponent<Camera> ();
		isUSBDead = false;
	}
	void Update () {
		_USBTransform = gameObject.transform;
		if (_USBTransform.position.y + _USBTransform.localScale.y / 3.1f //if not in view range
		    < mainCamera.transform.position.y - mainCamera.orthographicSize)
		{
			Destroy (gameObject);
			isUSBDead = true;
		}
	}
}
