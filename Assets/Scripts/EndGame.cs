using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {
    [SerializeField] private Text score;

	void Update () {
		score.text = CarScoreManager.Instance.score.ToString();
    }
}
