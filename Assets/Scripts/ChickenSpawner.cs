using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawner : MonoBehaviour {

    public bool hasChicken;

	// Use this for initialization
	void Start () {
        hasChicken = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "cone", true);
    }
}
