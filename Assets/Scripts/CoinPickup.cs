using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public int points;
    public GameObject coinParticles;

    private PlayerController player;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerController>()  == null)
            return;

        ScoreManager.AddPoints(points);
        Instantiate(coinParticles, player.transform.position, player.transform.rotation);
        Destroy(gameObject);
    }
}
