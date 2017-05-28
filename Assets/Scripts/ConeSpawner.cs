using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeSpawner : MonoBehaviour {
	private bool hasCone = false;
	public bool HasCone {
		get {
			return hasCone;
		}
		set {
			hasCone = value;
		}
	}

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position,"cone" , true);
    }

}
