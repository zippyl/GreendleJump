using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	private float durationTime = 5f;
	public float passed{ get; set; }

	public void Ate()
	{
		StartCoroutine(Duration (durationTime));
	}

	IEnumerator Duration(float durationTime)
	{
		while(durationTime > passed)
		{
			passed = passed + Time.deltaTime;
			yield return 0;
    	}
		passed = 0f;
		gameObject.SetActive (false);
	}
}