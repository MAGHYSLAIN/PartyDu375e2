using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PitbullChase : MonoBehaviour {

	private NavMeshAgent m_agent;
	private Transform car;

	void Start () {
		m_agent = GetComponent<NavMeshAgent>();

		car = CarScoreManager.Instance.transform;
		m_agent.destination = car.position;
	}

	void Update () {
		m_agent.destination = car.position;
	}
}
