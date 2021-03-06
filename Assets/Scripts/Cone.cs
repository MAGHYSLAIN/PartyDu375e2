﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Cone : MonoBehaviour {
	
	public ConeSpawner spawner;

	private AudioSource audio;

	void Awake () {
		audio = GetComponent<AudioSource>();
	}

    void OnTriggerEnter(Collider other)
    {
        //When the player car collides with a cone, enter the IF
        if (other.gameObject.tag == "Player")
        {
			PickUp ();
        }
    }

	private void PickUp () {
		CarScoreManager.Instance.coneRemoved++;
		CarScoreManager.coneInPlay--;
		CarScoreManager.totalObstacle--;
        //CarScoreManager.Instance.score++;
        CarScoreManager.Instance.AddScore("cone");
		spawner.HasCone = false;
		CarScoreManager.Instance.anim.SetTrigger("pickup");	

		StartCoroutine(WaitToDisappear ());
	}

	private IEnumerator WaitToDisappear () {
		audio.Play();

		Destroy(GetComponent<Collider>());
		Destroy(GetComponentInChildren<SkinnedMeshRenderer>());

		while (audio.isPlaying) {
			yield return null;
		}

		Destroy(this.gameObject);
	}
}