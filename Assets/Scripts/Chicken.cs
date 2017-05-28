using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Chicken : MonoBehaviour {

	public ChickenSpawner spawner;
	private AudioSource audio;

	void Awake () {
		audio = GetComponent<AudioSource>();
	}

    void OnTriggerEnter(Collider other)
    {
        //When the player car collides with a cone, enter the IF
        if (other.gameObject.tag == "Player")
        {
            CarScoreManager.chickenInPlay--;
            CarScoreManager.totalObstacle--;
            // CarScoreManager.Instance.score++;
            CarScoreManager.Instance.AddScore("chicken");
            spawner.GetComponent<ChickenSpawner>().hasChicken = false;
			StartCoroutine(WaitToDisappear ());
        }
    }

	private IEnumerator WaitToDisappear () {
		audio.Play();

		Destroy(GetComponentInChildren<Collider>());
		Destroy(GetComponentInChildren<MeshRenderer>());

		while (audio.isPlaying) {
			yield return null;
		}

		Destroy(this.gameObject);
	}
}
