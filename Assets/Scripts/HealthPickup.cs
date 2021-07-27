using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    public int health;
    public GameObject healthParticles;

    private PlayerController player;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.GetComponent<PlayerController>() == null) {
            return;
        }

        HealthManager.HealPlayer(health);
        Instantiate(healthParticles, player.transform.position, player.transform.rotation);
        Destroy(gameObject);
    }
}
