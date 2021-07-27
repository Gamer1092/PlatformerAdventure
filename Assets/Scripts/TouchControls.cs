using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {

    private PlayerController player;
    private LevelLoader levelExit;
    private PauseMenu pauseMenu;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        levelExit = FindObjectOfType<LevelLoader>();
        pauseMenu = FindObjectOfType<PauseMenu>();
	}
	
	public void LeftArrow() {
        player.Move(-1);
    }

    public void RightArrow() {
        player.Move(1);
    }

    public void UnpressedArrow() {
        player.Move(0);
    }

    public void Sword() {
        player.Sword();
    }

    public void ResetSword(){
        player.ResetSword();
    }

    public void Fire() {
        player.Fire();
    }

    public void Jump() {
        player.Jump();
        if(levelExit.playerInZone) {
            levelExit.LoadLevel();
        }
    }

    public void Pause() {
        pauseMenu.PauseUnpause();
    }
}
