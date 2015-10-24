using UnityEngine;
using System.Collections;

public class MovingHor : MonoBehaviour {

	private GameObject cameraObj;
	private Camera mainCamera;
	private float isTurningFinished;  // 0 = false, 1 = true 
	private float leftBorder = -4.1f, rightBorder = 4.6f, topBorder;
	private float step = 0.02f; // speed
	private Transform _gameObjectTransform;

	void Awake(){
		cameraObj = GameObject.FindGameObjectWithTag ("MainCamera");
		mainCamera = cameraObj.GetComponent<Camera> ();
		topBorder = gameObject.transform.position.y + mainCamera.orthographicSize;
		isTurningFinished = Random.Range (0, 1);
	}

	void Update () {
		_gameObjectTransform = gameObject.transform;
		if (mainCamera.transform.position.y < topBorder){ // is in view range?
			if (isTurningFinished == 0) { // if we going left
				if (_gameObjectTransform.position.x > leftBorder) // if we not near border
					_gameObjectTransform.position = new Vector3(_gameObjectTransform.position.x - step, _gameObjectTransform.position.y, _gameObjectTransform.position.z) ; // going left
				else 
					isTurningFinished = 1;
			}
			if (isTurningFinished == 1) { // if we going right
				if (_gameObjectTransform.position.x < rightBorder) // if we not near border
					_gameObjectTransform.position = new Vector3(_gameObjectTransform.position.x + step, _gameObjectTransform.position.y, _gameObjectTransform.position.z) ; // going right
				else
					isTurningFinished = 0;
			}

		} else // if gameObject not in view range
			Destroy (gameObject); 
	}
}
