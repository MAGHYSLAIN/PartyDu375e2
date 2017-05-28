using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;

<<<<<<< HEAD
<<<<<<< HEAD
=======

[RequireComponent(typeof(AudioSource))]
>>>>>>> cccad5437ab569db478c21cb988509cc826bd50d
=======
[RequireComponent(typeof(AudioSource))]
>>>>>>> cccad5437ab569db478c21cb988509cc826bd50d
=======
[RequireComponent(typeof(AudioSource))]
>>>>>>> cccad5437ab569db478c21cb988509cc826bd50d
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
    public float arrivedScore;
    public float coneScore;
    public float chickenScore;
    public string retroCone="Cone Removed!!!";
    public string retroChicken= "Nid de poule covered!!!";
    public string retroArrived= "A Partier arrived!!!";
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

	private AudioSource audio;

	void Awake () {
		if (Instance != null && Instance != this) {
			Destroy(this.gameObject);
		} else {
			Instance = this;
		}

		anim = GetComponent<Animator>();
		audio = GetComponent<AudioSource>();
	}

    void Start () {
        timer = 375;
		coneSpawners = FindObjectsOfType<ConeSpawner>();
		chickenSpawners = FindObjectsOfType<ChickenSpawner>();
        coneFrequencyTimer = 0.5f;
        chickenFrequencyTimer = 5;
        arrivedScore = 500;
        coneScore = 350;
        chickenScore = 350;
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
    

    public void AddScore(string type)
    {
        
        switch (type)
        {
    case "cone":
                score += coneScore;
                GameObject coneRetro = Instantiate(Resources.Load("RetroactionArrived")) as GameObject;
                coneRetro.GetComponentInChildren<Text>().text =retroCone;
                Destroy(coneRetro, 2f);
                break;
    case "chicken":
                score += chickenScore;
                GameObject chickenRetro = Instantiate(Resources.Load("RetroactionArrived")) as GameObject;
                chickenRetro.GetComponentInChildren<Text>().text = retroChicken;  
                Destroy(chickenRetro, 2f); 
                break;
    case "arrived":
                score += arrivedScore;
                GameObject arrivedRetro = Instantiate(Resources.Load("RetroactionArrived")) as GameObject;
                print(arrivedRetro.GetComponentInChildren<Text>());
                arrivedRetro.GetComponentInChildren<Text>().text = retroArrived;
                Destroy(arrivedRetro, 2f);
                break;
        }
    }

	void OnCollisionEnter (Collision other) {
		// Don't make a crash sound for partier collision
		if (other.collider.GetComponent<Partier>() != null)
			return;
		
		audio.volume = Mathf.InverseLerp(0f, 40f, other.relativeVelocity.magnitude);
		audio.Play();
	}
}
