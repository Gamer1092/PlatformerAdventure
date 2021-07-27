using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public float startingTime;
    private float countingTime;

    private HealthManager healthManager;
    private Text time;
    private PauseMenu pauseMenu;

    // Use this for initialization
	void Start () {
        countingTime = startingTime;
        healthManager = FindObjectOfType<HealthManager>();
        time = GetComponent<Text>();
        pauseMenu = FindObjectOfType<PauseMenu>();
	}
	
	// Update is called once per frame
	void Update () {
        if (pauseMenu.isPaused) {
            return;
        }

        countingTime -= Time.deltaTime;
        if (countingTime <= 0) {
            healthManager.KillPlayer();
        }

        time.text = "" + Mathf.Round(countingTime);
	}

    public void ResetTime() {
        countingTime = startingTime;
    }
}
