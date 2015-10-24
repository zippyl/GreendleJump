using UnityEngine;
using System.Collections;

public class destroyingStatic: MonoBehaviour {
	private GameObject cameraObj;
	private Camera mainCamera;
	private Transform _gameObjTransform;

	void Awake(){
		cameraObj = GameObject.FindGameObjectWithTag ("MainCamera");
		mainCamera = cameraObj.GetComponent<Camera> ();
	}
	void Update () {
		_gameObjTransform = gameObject.transform;
		if (_gameObjTransform.position.y + _gameObjTransform.localScale.y/3.1f< mainCamera.transform.position.y - mainCamera.orthographicSize)
			Destroy (gameObject);
	}
}

