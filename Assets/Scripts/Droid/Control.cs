using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
	private float h;
	public GameObject Droid;
	private Animator animator;
	public Apple Apple;
	public Borders Borders;
	public float droidWeight{ get; set; } 
	public float droidHeight{ get; set; }
	public Transform _droidTransform{ get; set;}
	private Rigidbody _droidRigidbody;

	void Awake(){
		_droidTransform = Droid.transform;
		animator = GetComponent<Animator>();
		droidWeight = _droidTransform.localScale.x;
		droidHeight = _droidTransform.localScale.y;
	}

	void Update () {
		_droidTransform = Droid.transform;
		_droidRigidbody = Droid.GetComponent<Rigidbody> ();
		h = Input.GetAxis ("Horizontal");
		if (Apple.passed != 0f)
			h = h * -1f;
		if (h < -0.0005f)
			_droidRigidbody.AddForce (-0.7f, 0, 0, ForceMode.Impulse);
		if (h > 0.0005f)
			_droidRigidbody.AddForce (0.7f, 0, 0, ForceMode.Impulse);
		animator.SetFloat ("Horizontal", h);
	
		//if (_droidTransform.position.x <= -4.835f) 
		if (_droidTransform.position.x <= -4.8f + 0.28f)  // 0.28 = Camera.Transform.pos.x
			Borders.LeftBoard();
		//if (_droidTransform.position.x >= 5.17f) 
		if (_droidTransform.position.x >= 4.8f - 0.28f) 
			Borders.RightBoard();
	}


}
