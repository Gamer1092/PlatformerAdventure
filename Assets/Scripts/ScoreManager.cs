using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;
    Text scoreText;

    private void Start() {
        scoreText = GetComponent<Text>();
        score = PlayerPrefs.GetInt("CurrentScore");
    }

    private void Update() {
        if (score < 0)
            score = 0;

        scoreText.text = "" + score;
    }

    public static void AddPoints(int points) {
        score += points;
        PlayerPrefs.SetInt("CurrentScore", score);
    }

    public static void Reset() {
        score = 0;
        PlayerPrefs.SetInt("CurrentScore", score);
    }
}
