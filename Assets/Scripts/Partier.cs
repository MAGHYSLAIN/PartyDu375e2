using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
public class Partier : MonoBehaviour {
	
	public Transform target { get; set; }
	private NavMeshAgent m_agent;
	private Rigidbody rb;
	private Collider coll;
	private AudioSource audio;

	private IEnumerator dazedCoroutine;

	[SerializeField]
	private float hitMultiplier = 1f;

	// Will disappear if within this threshold
	[SerializeField]
	private float distanceThreshold = 10f;

	[SerializeField]
	private float dazedTime = 4f;

	[SerializeField]
	private float fadeInSpeed = 1f;

	void Awake () {
		audio = GetComponent<AudioSource>();
	}

	IEnumerator Start () {
		m_agent = GetComponent<NavMeshAgent>();
		rb = GetComponent<Rigidbody>();
		coll = GetComponent<Collider>();
		rb.isKinematic = true;
		coll.isTrigger = true;

		yield return new WaitForSeconds(1f);

		// TODO: Temporary, use better way of finding the target
		target = GameObject.Find("Target").transform;
		if (target == null)
			Debug.LogError("Place a GameObject named \"Target\" in the scene");

		m_agent.destination = target.position;
	}

	void Update () {
		if (target == null) {
			return;
		}

		if (!m_agent.isOnNavMesh) {
			return;
		}

		m_agent.destination = target.position;

		// If partier is within radius, they're at the party. wooo!
		if (Vector3.Distance(this.transform.position, target.position) < distanceThreshold) {
			AtTheParty ();
		}
	}

	void OnDestroy () {
		// Remove this partier from the list
		PartierSpawner.partiers.Remove(this);
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "Player") {
			Dazed(coll.GetComponentInParent<Rigidbody>());

			audio.Play();
		}
	}

	private void Dazed (Rigidbody otherRb) {
		if (dazedCoroutine != null) {
			StopCoroutine(_Dazed(otherRb));
		}
		dazedCoroutine = _Dazed (otherRb);
		StartCoroutine(_Dazed(otherRb));
	}

	private IEnumerator _Dazed (Rigidbody otherRb) {
		coll.isTrigger = false;
		m_agent.enabled = false;
		rb.isKinematic = false;

		rb.velocity = otherRb.velocity * hitMultiplier;

		yield return new WaitForSeconds(dazedTime);

		coll.isTrigger = true;

		m_agent.enabled = true;
		rb.isKinematic = true;
	}

	private void AtTheParty () {
		StartCoroutine(Disappear());
	}

	// Disappear and then destroy
	private IEnumerator Disappear () {
		float targetAlpha = 0f;
		float fadeSpeed = fadeInSpeed;

		Material mat = GetComponentInChildren<MeshRenderer>().material;
		float timer = 0f;

		Color newColor = new Color (
			mat.color.r,
			mat.color.g,
			mat.color.b,
			targetAlpha
		);

		while (timer < 1f) {
			timer += Time.deltaTime * fadeSpeed;

			mat.color = Color.Lerp(mat.color, newColor, timer);
			yield return null;
		}
		mat.color = newColor;
        CarScoreManager.arrivedUser++;
        // CarScoreManager.Instance.score++;
        CarScoreManager.Instance.AddScore("arrived");
        Destroy(this.gameObject);
	}
}
