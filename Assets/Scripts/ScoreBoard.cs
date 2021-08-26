using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    

    int Score;
    Text ScoreText;
	
	void Start () {
        ScoreText=GetComponent<Text>();
        ScoreText.text = Score.ToString();
		
	}
    
    public void ScoreHit(int EnemyScoreHit)
    {
        Score = Score + EnemyScoreHit;
        ScoreText.text = Score.ToString();
    }
	
	
}
