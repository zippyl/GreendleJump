using UnityEngine;
using System.Collections;

public class Visible : MonoBehaviour {
	public bool isInvisible{ get; set; }


	void OnBecameInvisible()
	{
		gameObject.transform.parent.gameObject.SetActive (false);
	}
	
}
