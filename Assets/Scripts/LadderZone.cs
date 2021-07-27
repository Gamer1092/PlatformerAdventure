using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderZone : MonoBehaviour {

    private PlayerController player;

    // Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.name == "Player") {
            player.onLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.name == "Player") {
            player.onLadder = false;
        }
    }
}
