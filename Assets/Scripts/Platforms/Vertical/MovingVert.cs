using UnityEngine;
using System.Collections;

public class MovingVert : MonoBehaviour {
	private GameObject cameraObj;
	private Camera mainCamera;
	private float isTurningFinished; // 0 = false, 1 = true 
	private float topBorder, bottomBorder;
	private float step = 0.02f, range = 2.79f, platformSizeY;
	private Transform _gameObjTransform, _cameraTransform;

	void Awake(){
		_gameObjTransform = gameObject.transform;
		cameraObj = GameObject.FindGameObjectWithTag ("MainCamera");
		mainCamera = cameraObj.GetComponent<Camera> ();
		topBorder = _gameObjTransform.position.y;  
		bottomBorder = _gameObjTransform.position.y - range;
		isTurningFinished = Random.Range (0, 1);
		platformSizeY = _gameObjTransform.localScale.y;
	}
	void Update () {
		_gameObjTransform = gameObject.transform;
		_cameraTransform = mainCamera.transform;
		if ((_cameraTransform.position.y - mainCamera.orthographicSize - 0.5810521f > bottomBorder) && 
		    (_cameraTransform.position.y - mainCamera.orthographicSize < topBorder) && (topBorder - bottomBorder > _gameObjTransform.localScale.y * 3f)) {
			bottomBorder = _cameraTransform.position.y - mainCamera.orthographicSize  - 0.5810521f;
		}
		if (_cameraTransform.position.y - mainCamera.orthographicSize - 0.5810521f< 
		    _gameObjTransform.position.y) {
			if (isTurningFinished == 0) {
				if (_gameObjTransform.position.y < topBorder)
					_gameObjTransform.position = new Vector3 (_gameObjTransform.position.x, _gameObjTransform.position.y + step, _gameObjTransform.position.z); // going up
				else
					isTurningFinished = 1;
			}
			if (isTurningFinished == 1) {
				if (_gameObjTransform.position.y - platformSizeY > bottomBorder)
					_gameObjTransform.position = new Vector3 (_gameObjTransform.position.x, _gameObjTransform.position.y - step, _gameObjTransform.position.z); // going down
				else
					isTurningFinished = 0;
			}
		} else
			Destroy (gameObject);

	}
}
