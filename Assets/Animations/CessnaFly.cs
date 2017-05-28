using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CessnaFly : MonoBehaviour {

	private GameObject pivot;
	[SerializeField] private float radius = 50f;
	[SerializeField] private float tilt = 24f;
	[SerializeField] private float flySpeed = 24f;

	void Start () {
		pivot = new GameObject("Airplane_pivot");
		this.transform.parent = pivot.transform;

		this.transform.localPosition = new Vector3 (this.transform.localPosition.x + radius, this.transform.localPosition.y, this.transform.localPosition.z);
		this.transform.localEulerAngles = new Vector3 (0f, 0f, tilt);
	}
	
	void Update () {
		pivot.transform.Rotate(0f, flySpeed * Time.deltaTime, 0f);
	}
}
