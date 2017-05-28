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
    public static float speedPowerUpDown;
    public float coneRemoved;
    public float score;
	public static ConeSpawner[] coneSpawners;
	public static List<ConeSpawner> availableCones = new List<ConeSpawner>();
	public static ChickenSpawner[] chickenSpawners;
	public static List<ChickenSpawner> availableChickens = new List<ChickenSpawner>();
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
		coneSpawners = FindObjectsOfType<ConeSpawner>();
		chickenSpawners = FindObjectsOfType<ChickenSpawner>();
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
            if (speedPowerUpDown > 1)
                            {
                speedPowerUpDown -= 0.1f;
                Mathf.Clamp(speedPowerUpDown, 1, 2);
                            }
                        else if (speedPowerUpDown < 1)
                            {
                speedPowerUpDown += 0.1f;
                Mathf.Clamp(speedPowerUpDown, 0, 0.8f);
                           }
        }

        if (chickenFrequencyTimer < 0)
        {
            chickenFrequencyTimer = chickenFrequency;
            SpawnChicken();
        }
    }

    public void SpawnCone()
    {
		availableCones.Clear();
        for (int i =0; i<coneSpawners.Length; i++)
        {
            if (!coneSpawners[i].HasCone)
            {
                availableCones.Add(coneSpawners[i]);
            }
        }

		if (availableCones.Count >= 1)
		{
			int rng = Random.Range(0, availableCones.Count - 1);
			GameObject coneClone = Instantiate(Resources.Load("Cone"), availableCones[rng].transform.position, Quaternion.identity) as GameObject;
			coneClone.GetComponent<Cone>().spawner = availableCones[rng];
			availableCones[rng].HasCone = true;
			coneInPlay++;
			totalObstacle++;
		}
    }

    public void SpawnChicken()
    {
        availableChickens.Clear();
		for (int o = 0; o < chickenSpawners.Length; o++)
        {
            if (!chickenSpawners[o].hasChicken)
            {
				availableChickens.Add(chickenSpawners[o]);
            }

        }

        if (availableChickens.Count >= 1)
        {
            int rng1 = Random.Range(0, availableChickens.Count - 1);
            GameObject chickenClone = Instantiate(Resources.Load("Poulet"), availableChickens[rng1].transform.position, Quaternion.identity) as GameObject;
            chickenClone.GetComponentInChildren<Chicken>().spawner = availableChickens[rng1];
            availableChickens[rng1].hasChicken = true;
            chickenInPlay++;
            totalObstacle++;
        }
    }
    public void PowerUpDown(bool upDown)
    {
 
        if (upDown)
        {
            speedPowerUpDown = speedPowerUpDown* 1.02f;
 
        }
        else
       {
            speedPowerUpDown= speedPowerUpDown* 0.98f;
        }
    }

}
