using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomrotation : MonoBehaviour
{
	void Start()
	{
		Vector3 euler = transform.eulerAngles;
		euler.y = Random.Range (0f, 360f);
		transform.eulerAngles = euler;

		//transform.rotation = Random.rotation;
	}
}