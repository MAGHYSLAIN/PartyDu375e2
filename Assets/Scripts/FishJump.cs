using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishJump : MonoBehaviour {

	[SerializeField] private float speed = -300f;

	void Start () {
		// Give random rotation at the beginning so that fish don't all look the same
		transform.Rotate(new Vector3(0f, 0f, UnityEngine.Random.Range(0f, 360f)));
	}

	void Update () {
		transform.Rotate(new Vector3(0f, 0f, speed * Time.deltaTime));
	}
}
