using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour {

	private int score = 0;
	TextMeshProUGUI scoreText;

	public void Awake(){
		scoreText = GetComponent<TextMeshProUGUI> ();
		Dot.OnEaten += UpdateScore;

	}

	void OnDisable(){
		Dot.OnEaten -= UpdateScore;
	}

	public void UpdateScore(int addValue){
		score += addValue;
//		print (score);
		scoreText.SetText ("{0}", score);
//		scoreText.SetText("{0}",score);
	}




}
