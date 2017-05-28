using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class WaterMove : MonoBehaviour {

	[SerializeField] private float speed = 0.11f;
	[SerializeField] private float scale = 46f;

	private Renderer rend;

	void Start() {
		rend = GetComponent<Renderer>();
	}

	void Update() {
		float scaleX = (Mathf.Cos(Time.time * speed) * 0.5F + 1) * scale;
		float scaleY = (Mathf.Sin(Time.time * speed) * 0.5F + 1) * scale;
		rend.material.mainTextureScale = new Vector2(scaleX, scaleY);
	}
}
