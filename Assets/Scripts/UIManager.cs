using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text textTimer;
    public Text textArrived;
    public Text textCone;
    public GameObject car;
    public float timer;
    public float arrived;
    public float score;

    // Use this for initialization
    void Start () {
        car = FindObjectOfType<UnityStandardAssets.Vehicles.Car.CarController>().gameObject;
    }

    // Update is called once per frame
    void Update() {

        //Get timer float from car score manager and put it in the ui text
        timer = car.GetComponent<CarScoreManager>().timer;
        textTimer.text = ""+ timer;

        //Get arrived user float from car score manager and put it in the ui text
        arrived = CarScoreManager.arrivedUser;
        textArrived.text = "" + arrived;

        //Get coneremoved float from car score manager and put it in the ui text
        score= CarScoreManager.score;
        textCone.text = "" + score;

    }
}
