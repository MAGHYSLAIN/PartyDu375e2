using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarScoreManager : MonoBehaviour {
	public static CarScoreManager Instance { get; private set; }

    public static int coneInPlay;
    public static int chickenInPlay;
    public static int totalObstacle;
    public float timer;
    public static int arrivedUser;
    public float coneRemoved;
    public static float score;
	public static ConeSpawner[] coneSpawner;
	public static List<ConeSpawner> availableCone = new List<ConeSpawner>();
    public static GameObject[] chickenSpawner;
    public static List<GameObject> availableChicken = new List<GameObject>();
    float coneFrequency=1.5f;
    [SerializeField]
    float coneFrequencyTimer;
    float chickenFrequency =5f;
    float chickenFrequencyTimer;

	public Animator anim;

	void Awake () {
		if (Instance != null && Instance != this) {
			Destroy(this.gameObject);
		} else {
			Instance = this;
		}

		anim = GetComponent<Animator>();
	}

    void Start () {
        timer = 375;
		coneSpawner = FindObjectsOfType<ConeSpawner>();
        chickenSpawner = GameObject.FindGameObjectsWithTag("ChickenSpawner");
        coneFrequencyTimer = 0.5f;
        chickenFrequencyTimer = 5;
    }
	
	void Update () {
        timer = timer - Time.deltaTime;

        coneFrequencyTimer = coneFrequencyTimer-Time.deltaTime;
        chickenFrequencyTimer = chickenFrequencyTimer - Time.deltaTime;
        if (coneFrequencyTimer<0)
        {
            coneFrequencyTimer = Mathf.Lerp(3, 0.5f, (timer/375));
            SpawnCone();
        }

        if (chickenFrequencyTimer < 0)
        {
            chickenFrequencyTimer = chickenFrequency;
            SpawnChicken();
        }
    }

    public void SpawnCone()
    {
		availableCone.Clear();
        for (int i =0; i<coneSpawner.Length; i++)
        {
            if (!coneSpawner[i].GetComponent<ConeSpawner>().HasCone)
            {
                availableCone.Add(coneSpawner[i]);
            }
        }

		if (availableCone.Count >= 1)
		{
			int rng = Random.Range(0, availableCone.Count - 1);
			GameObject coneClone = Instantiate(Resources.Load("Cone"), availableCone[rng].transform.position, Quaternion.identity) as GameObject;
			coneClone.GetComponent<Cone>().spawner = availableCone[rng];
			availableCone[rng].GetComponent<ConeSpawner>().HasCone = true;
			coneInPlay++;
			totalObstacle++;
		}
    }

    public void SpawnChicken()
    {
        availableChicken.Clear();
        for (int o = 0; o < chickenSpawner.Length; o++)
        {
            if (!chickenSpawner[o].GetComponent<ChickenSpawner>().hasChicken)
            {
                availableChicken.Add(chickenSpawner[o]);
            }

        }

        if (availableChicken.Count >= 1)
        {
            int rng1 = Random.Range(0, availableChicken.Count - 1);
            GameObject chickenClone = Instantiate(Resources.Load("Poulet"), availableChicken[rng1].transform.position, Quaternion.identity) as GameObject;
            chickenClone.GetComponentInChildren<Chicken>().spawner = availableChicken[rng1];
            availableChicken[rng1].GetComponent<ChickenSpawner>().hasChicken = true;
            chickenInPlay++;
            totalObstacle++;
        }
    }


}
