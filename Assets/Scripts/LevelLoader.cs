using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public bool playerInZone;
    private AudioSource levelComplete;

    public string levelToLoad;
    public string levelTag;

	// Use this for initialization
	void Start () {
        playerInZone = false;
        levelComplete = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerInZone && Input.GetAxisRaw("Vertical") > 0) {
            LoadLevel();
            levelComplete.Play();
        }
	}

    public void LoadLevel() {
        PlayerPrefs.SetInt(levelTag, 1);
        SceneManager.LoadScene(levelToLoad);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.name == "Player") {
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.name == "Player") {
            playerInZone = false;
        }
    }
}
