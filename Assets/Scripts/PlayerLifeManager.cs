using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLifeManager : MonoBehaviour {

    private int lifeCounter;
    private Text lifeText;

    public GameObject gameOver;
    public PlayerController player;

    public string mainMenu;
    public float waitTime;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        lifeText = GetComponent<Text>();
        lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");
	}
	
	// Update is called once per frame
	void Update () {
        if (lifeCounter < 0) {
            gameOver.SetActive(true);
            player.gameObject.SetActive(false);
        }
        lifeText.text = "x " + lifeCounter;

        if (gameOver.activeSelf) {
            waitTime -= Time.deltaTime;
        }

        if (waitTime < 0) {
            SceneManager.LoadScene(mainMenu);
        }
    }

    public void ExtraLife() {
        lifeCounter++;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }

    public void LoseALife() {
        lifeCounter--;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }

    public void GameOver() {
        if (lifeCounter < 0) {
            gameOver.SetActive(true);
        }
    }
}
