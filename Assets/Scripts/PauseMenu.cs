using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public string levelSelect;
    public string mainMenu;

    public bool isPaused;
    public GameObject pauseMenu;
	
	// Update is called once per frame
	void Update () {
		if (isPaused) {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseUnpause();
        }
	}

    public void PauseUnpause()
    {
        isPaused = !isPaused;
    }

    public void Resume() {
        isPaused = false;
    }

    public void LevelSelect() {
        SceneManager.LoadScene(levelSelect);
    }

    public void MainMenu() {
        SceneManager.LoadScene(mainMenu);
    }
}
