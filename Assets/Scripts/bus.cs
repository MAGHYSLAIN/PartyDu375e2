using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class bus : MonoBehaviour {

	private NavMeshAgent m_agent;
	[SerializeField] float distanceThreshold = 10f;
	[SerializeField] private Transform[] waypoints;
	private int currentIndex = 0;

	void Start () {
		m_agent = GetComponent<NavMeshAgent>();

		m_agent.destination = waypoints[currentIndex].position;
	}
	
	void Update () {
		if (waypoints.Length == 0) {
			Debug.LogError("No waypoints set");
			return;
		}

		if (m_agent.remainingDistance < distanceThreshold) {
			m_agent.destination = waypoints[currentIndex++ % waypoints.Length].position;
		}
	}
}
