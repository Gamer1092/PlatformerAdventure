using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour {

    public string[] levelTags;
    public GameObject[] locks;
    public bool[] levelUnlocked;
    public string[] levelName;

    public int positionSelector;
    public float distanceBelowLock;
    public float moveSpeed;
    public bool isPressed;
    public bool touchMode;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < levelTags.Length; i++) {
            if(PlayerPrefs.GetInt(levelTags[i]) != 0) {
                levelUnlocked[i] = false;
            }
            if(PlayerPrefs.GetInt(levelTags[i]) == 0) {
                levelUnlocked[i] = false;
            }
            else {
                levelUnlocked[i] = true;
            }

            if(levelUnlocked[i]) {
                locks[i].SetActive(false);
            }
        }

        PlayerPrefs.GetInt("PlayerLevelSelectPosition");
        transform.position = locks[positionSelector].transform.position + new Vector3(0, distanceBelowLock, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if(!isPressed) {
            if(Input.GetAxis("Horizontal") > 0.25f) {
                positionSelector += 1;
                isPressed = true;
            }

            if (Input.GetAxis("Horizontal") < -0.25f) {
                positionSelector -= 1;
                isPressed = true;
            }

            if(positionSelector >= levelTags.Length) {
                positionSelector = levelTags.Length - 1;
            }

            if(positionSelector < 0) {
                positionSelector = 0;
            }
        }

        if(isPressed) {
            if(Input.GetAxis("Horizontal") < 0.25f && Input.GetAxis("Horizontal") > -0.25f) {
                isPressed = false;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, locks[positionSelector].transform.position + new Vector3(0, distanceBelowLock, 0), 
                                                 moveSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump")) {
            if(levelUnlocked[positionSelector] && !touchMode) {
                PlayerPrefs.SetInt("PlayerLevelSelectPosition", positionSelector);
                SceneManager.LoadScene(levelName[positionSelector]);
            }
        }
	}
}
