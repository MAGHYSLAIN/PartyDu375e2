using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour {
	public ChickenSpawner spawner;

    void OnTriggerEnter(Collider other)
    {
        //When the player car collides with a cone, enter the IF
        if (other.gameObject.tag == "Player")
        {
            CarScoreManager.chickenInPlay--;
            CarScoreManager.totalObstacle--;
            CarScoreManager.Instance.score++;
            spawner.GetComponent<ChickenSpawner>().hasChicken = false;
            Destroy(this.gameObject);
        }
    }
}
