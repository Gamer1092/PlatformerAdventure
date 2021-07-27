using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour {

    public GameObject extraLifeParticles;
    public PlayerController player;
    private PlayerLifeManager lifeSystem;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        lifeSystem = FindObjectOfType<PlayerLifeManager>();
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") {
            lifeSystem.ExtraLife();
            Instantiate(extraLifeParticles, player.transform.position, player.transform.rotation);
            Destroy(gameObject);
        }
    }
}
