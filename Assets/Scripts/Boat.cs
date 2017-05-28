using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {

	[SerializeField] private float bobAmount = 1f;
	[SerializeField] private float bobSpeed = 1f;

	void Update () {
		transform.eulerAngles = new Vector3(
			Mathf.Sin(Time.time * bobSpeed * 1.2f) * bobAmount,
			transform.eulerAngles.y,
			Mathf.Sin(Time.time * bobSpeed) * bobAmount
		);
	}
}
