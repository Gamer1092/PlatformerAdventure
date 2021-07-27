using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string startLevel;
    public string levelSelect;

    public int playerLives;
    public int playerHealth;

    public string level1Tag;

    public void PlayGame() {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
        PlayerPrefs.SetInt("CurrentScore", 0);
        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
        PlayerPrefs.SetInt("PlayerMaxHealth", playerHealth);

        PlayerPrefs.SetInt(level1Tag, 1);
        PlayerPrefs.SetInt("PlayerLevelSelectPosition", 0);
        SceneManager.LoadScene(startLevel);
    }

    public void LevelSelect() {
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
        PlayerPrefs.SetInt("CurrentScore", 0);
        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
        PlayerPrefs.SetInt("PlayerMaxHealth", playerHealth);

        PlayerPrefs.SetInt(level1Tag, 1);
        if (!PlayerPrefs.HasKey("PlayerLevelSelectPosition")) {
            PlayerPrefs.SetInt("PlayerLevelSelectPosition", 0);
        }
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
