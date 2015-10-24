using UnityEngine;
using System.Collections;

public class Borders : MonoBehaviour {

	public Control Control;

	public void LeftBoard(){
		Control.Droid.GetComponent<Transform> ().Translate(9.6f - Control.droidWeight, 0f, 0f, Space.World);
	}

	public void RightBoard(){
		Control.Droid.GetComponent<Transform> ().Translate(-9.6f + Control.droidWeight ,0f, 0f, Space.World);
	}

}
