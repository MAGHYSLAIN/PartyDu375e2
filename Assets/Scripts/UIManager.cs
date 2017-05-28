using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField] private Text textTimer;
	[SerializeField] private Text textArrived;
	[SerializeField] private Text textCone;
    [SerializeField] private Text textInstruction;


    void Start()
    {
        Destroy(textInstruction, 5f);
    }

    void Update() {
        //Get timer float from car score manager and put it in the ui text
		textTimer.text = "Timer: "+CarScoreManager.Instance.timer.ToString("F");

        //Get arrived user float from car score manager and put it in the ui text
		textArrived.text = "Arrived: " + CarScoreManager.arrivedUser.ToString();

        //Get coneremoved float from car score manager and put it in the ui text
		textCone.text = "Score: " + CarScoreManager.Instance.score.ToString();
    }
}
