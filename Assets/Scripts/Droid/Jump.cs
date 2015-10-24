using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	public GameObject Droid;
	public cameraFollow cameraFollow;
	public Control Control;
	public Apple Apple;
	public float lastY{ get; set; }
	private string _colliderTag;
	private Rigidbody _droidRigidbody;
	private Transform _droidTransform, _colliderTransform, _brokenPlatformTransform ;
	public bool isDroidDead { get; set; }
	public bool isFly{ get; set; }
	public float stoppingPlace;
	public float usbPower = 10f, bucketPower = 30f, usbSpeed = 0.0001f, bucketSpeed = 0.09f;

	void OnTriggerEnter(Collider Col){

		_colliderTag = Col.gameObject.tag;
		_droidTransform = Droid.transform;
		_droidRigidbody = Droid.GetComponent<Rigidbody> ();
		_colliderTransform = Col.transform;

		if ((_colliderTag == "Platform") || (_colliderTag=="horizontalPlatform") || (_colliderTag == "verticalPlatform") && isFly == false)
			if (_colliderTransform.position.y < _droidTransform.position.y + _droidTransform.localScale.y) {

			_droidRigidbody.isKinematic = true;   
			_droidRigidbody.isKinematic = false;             
			_droidRigidbody.AddForce (new Vector3 (0, 1, 0) * 39.5f, ForceMode.Impulse); // Jump

			if (_colliderTransform.position.y > lastY) {    //CameraUp  
				StartCoroutine (cameraFollow.Up (lastY, _colliderTransform.position.y));
			}
		}

		if ((_colliderTag == "brokenPlatform") && (isFly == false))
		if (_colliderTransform.position.y < _droidTransform.position.y + _droidTransform.localScale.y)
		{
			Col.gameObject.GetComponent<Animator> ().SetBool ("isBroken", true);
			StartCoroutine (brokenPlatformFalling (Col.gameObject));
		}

		if ((_colliderTag == "Apple") && (isFly == false))
		if (_colliderTransform.position.y < _droidTransform.position.y + _droidTransform.localScale.y) {
			_colliderTransform.position = new Vector3 (-9f, _colliderTransform.position.y, _colliderTransform.position.z);
			Apple.Ate ();
		}

		/*if ((_colliderTag == "USB") && (isFly == false))
		if (_colliderTransform.position.y < _droidTransform.position.y + _droidTransform.localScale.y)
		{
			Col.gameObject.GetComponent<Animator> ().SetBool ("isJumped", true);
			_droidRigidbody.isKinematic = true;   
			_droidRigidbody.isKinematic = false; 
			_droidRigidbody.AddForce (new Vector3 (0, 1, 0) * 70f, ForceMode.Impulse);
			StartCoroutine(cameraFollow.Fly(_colliderTransform.position.y + usbPower, usbSpeed));
		}*/

		/*if ((_colliderTag == "Bucket") && (isFly == false))
		if (_colliderTransform.position.y < _droidTransform.position.y + _droidTransform.localScale.y) 
		{
			Droid.GetComponent<BoxCollider>().enabled = false;
			_colliderTransform.position = new Vector3(_droidTransform.position.x + 0.107f, 
			     _droidTransform.position.y + 0.544f, _colliderTransform.position.z);
			_droidRigidbody.isKinematic = true;
			_droidRigidbody.isKinematic = false;
			_droidRigidbody.AddForce (new Vector3 (0, 1, 0) * 90f, ForceMode.Impulse);
			StartCoroutine(cameraFollow.Fly(_colliderTransform.position.y + bucketPower, bucketSpeed));

			stoppingPlace = _droidTransform.position.y + 30f;
			Debug.Log("col");
			isFly = true;
			StartCoroutine(droidInBucket());
			//_droidRigidbody.AddForce (new Vector3(0,1,0) * 10f, ForceMode.Impulse);
			StartCoroutine(cameraFollow.Flying());
		}*/
	}

		IEnumerator brokenPlatformFalling(GameObject brokenPlatform){
		_brokenPlatformTransform = brokenPlatform.transform;
		while (_brokenPlatformTransform.position.y>cameraFollow.currCamera.   //while obj in camera view range
		       transform.position.y - cameraFollow.currCamera.orthographicSize - _brokenPlatformTransform.localScale.y) 
		{
			_brokenPlatformTransform.position = Vector3.Lerp (_brokenPlatformTransform.position,
			           new Vector3(_brokenPlatformTransform.position.x, _brokenPlatformTransform.
			           position.y - 12f, _brokenPlatformTransform.position.z), 0.003f);
			if (brokenPlatform.GetComponent<destroyingBroken>().isBrokenDead == true)
				yield break;
			_brokenPlatformTransform = brokenPlatform.transform;
			yield return null;
		}
	}

	/*IEnumerator droidInBucket(){
		while (_droidTransform.position.y < stoppingPlace + _droidTransform.localScale.y) {
			Debug.Log("Fly");
			Debug.Log(stoppingPlace);
			Debug.Log(_droidTransform.position.y);
			//_droidRigidbody.AddForce (new Vector3(0,1,0) * 1.2f, ForceMode.Impulse);
			//_droidTransform.Translate(new Vector3 (0, 0.00007f, 0), Space.World);

		//	_droidTransform.position = Vector3.Lerp (_droidTransform.position, new Vector3 
		//    (_droidTransform.position.x, stoppingPlace, _droidTransform.position.z), 0.0007f);  

			_colliderTransform.position = Vector3.Lerp (_colliderTransform.position, new Vector3 
			(_colliderTransform.position.x, stoppingPlace, _colliderTransform.position.z), 0.0007f); 

			if (_droidTransform.position.y + 0.00007f >= stoppingPlace + _droidTransform.localScale.y){
				isFly = false;
				Debug.Log("isFly = false");
				Droid.GetComponent<BoxCollider>().enabled = true;
			}
			yield return null;
		}
	}*/
}
