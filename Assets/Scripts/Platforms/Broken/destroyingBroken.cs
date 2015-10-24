using UnityEngine;
using System.Collections;

public class destroyingBroken : MonoBehaviour {

	private GameObject cameraObj;
	private Camera mainCamera;
	public bool isBrokenDead{ get; set; }
	private Transform _gameObjTransform;
	
	void Awake(){
		cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
		mainCamera = cameraObj.GetComponent<Camera> ();
		isBrokenDead = false;
	}
	void Update () {
		_gameObjTransform = gameObject.transform;
		if (_gameObjTransform.position.y + _gameObjTransform.localScale.y / 3.1f //if not in view range
		            < mainCamera.transform.position.y - mainCamera.orthographicSize)
		{
			gameObject.SetActive(false);
			isBrokenDead = true;
		}
	}
}
