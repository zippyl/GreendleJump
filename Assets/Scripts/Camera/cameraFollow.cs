using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	public Camera currCamera;
	public Jump Jump;
	public GameObject Droid;
	private Transform _cameraTransform, _droidTransform;
	private float difference;

	void Awake(){
		Jump.lastY = currCamera.GetComponent<Transform> ().position.y - currCamera.orthographicSize + 1.44f;
	}
	
	public IEnumerator Up(float lastY, float Y)
	{
		while (currCamera.transform.position.y < Y - lastY) {
			_cameraTransform = currCamera.transform;
			_cameraTransform.position = Vector3.Lerp (_cameraTransform.position, new Vector3 (_cameraTransform.position.x, Y - lastY,
			        _cameraTransform.position.z), 0.06f);
			yield return null;
		}
	}


	/*public IEnumerator Fly(float stopPlace, float Speed){
		while (currCamera.transform.position.y < stopPlace - currCamera.orthographicSize) {
			Debug.Log(Speed);
			_cameraTransform = currCamera.transform;
			_cameraTransform.position = Vector3.Lerp (_cameraTransform.position, new Vector3 (_cameraTransform.position.x, stopPlace, _cameraTransform.position.z), Speed);
			//_cameraTransform.Translate(0, Mathf.Lerp(_cameraTransform.position.y, stopPlace, Speed ), 0);
			//currCamera.transform.Translate(0, Mathf.Lerp(_cameraTransform.position.y, stopPlace, Speed ), 0);
			//_cameraTransform.position = _cameraTransform.position + new Vector3(0f, 0.09f, 0f);
			//Debug.Log(currCamera.transform.position.y);
			//Debug.Log(stopPlace-currCamera.orthographicSize);

			yield return null;
		}
		Droid.GetComponent<BoxCollider> ().enabled = true;
	}

	/*public IEnumerator Flying()
	{
		difference = currCamera.transform.position.y - Droid.transform.position.y;
		while (Jump.isFly == true){
			Debug.Log("Camera fly");
			_cameraTransform = currCamera.transform;
			_droidTransform = Droid.transform;
			if (_cameraTransform.position.y - _droidTransform.position.y < difference){
				//_cameraTransform.position = new Vector3 (_cameraTransform.position.x, _droidTransform.position.y + difference, _cameraTransform.position.z); 
				//_cameraTransform.Translate(new Vector3 (_cameraTransform.position.x, _droidTransform.position.y + difference, _cameraTransform.position.z)); 
				_cameraTransform.Translate(new Vector3 (0, 0.00007f*Time.deltaTime, 0), Space.World);
			}
				yield return null;
		}

	}*/
}
