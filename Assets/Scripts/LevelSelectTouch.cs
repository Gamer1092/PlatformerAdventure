using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectTouch : MonoBehaviour {

    public LevelSelectManager levelSelect;

	// Use this for initialization
	void Start () {
        levelSelect = FindObjectOfType<LevelSelectManager>();
        levelSelect.touchMode = true;
	}

    public void MoveLeft() {
        levelSelect.positionSelector -= 1;

        if(levelSelect.positionSelector < 0) {
            levelSelect.positionSelector = 0;
        }
    }

    public void MoveRight() {
        levelSelect.positionSelector += 1;

        if(levelSelect.positionSelector > levelSelect.levelTags.Length) {
            levelSelect.positionSelector = levelSelect.levelTags.Length;
        }
    }

    public void LoadLevel() {
        PlayerPrefs.SetInt("PlayerLevelSelectPosition", levelSelect.positionSelector);
        SceneManager.LoadScene(levelSelect.levelName[levelSelect.positionSelector]);
    }
}
