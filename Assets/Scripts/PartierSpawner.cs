using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartierSpawner : MonoBehaviour {
	// Global list of all the partiers
	public static List<Partier> partiers = new List<Partier>();

	// The minimum and maximum amount of time to wait for the next partier to spawn
	[SerializeField]
	private float waitMin = 5f;
	[SerializeField]
	private float waitMax = 10f;

	private List<GameObject> partierPrefabs = new List<GameObject>();

	void Awake () {
		// Add the partier prefabs, find them by name
		partierPrefabs.Add((GameObject)Resources.Load("Partiers/MalePartierA"));
		partierPrefabs.Add((GameObject)Resources.Load("Partiers/MalePartierB"));
		partierPrefabs.Add((GameObject)Resources.Load("Partiers/MalePartierC"));
		partierPrefabs.Add((GameObject)Resources.Load("Partiers/MalePartierD"));
		partierPrefabs.Add((GameObject)Resources.Load("Partiers/MalePartierE"));
		partierPrefabs.Add((GameObject)Resources.Load("Partiers/MalePartierF"));
		partierPrefabs.Add((GameObject)Resources.Load("Partiers/MalePartierG"));

		StartCoroutine (WaitToAddPartier());
	}

	// Adds new partiers recursively forever and ever
	private IEnumerator WaitToAddPartier () {

		// Instantiate a random partier
		GameObject partierGO = (GameObject)Instantiate(partierPrefabs[UnityEngine.Random.Range(0, partierPrefabs.Count)]);

		Partier partier = partierGO.GetComponent<Partier>();
		partier.transform.position = this.transform.position;
		// Add the partiers to the list
		partiers.Add (partier);

		yield return new WaitForSeconds(UnityEngine.Random.Range(waitMin, waitMax));

		StartCoroutine (WaitToAddPartier());
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawIcon(transform.position,"partier" , true);
	}
}
