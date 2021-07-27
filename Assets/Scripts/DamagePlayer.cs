using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    public int damage;
    public LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") {
            HealthManager.DamagePlayer(damage);
            collision.GetComponent<AudioSource>().Play();

            var player = collision.GetComponent<PlayerController>();
            player.knockBackCount = player.knockBackLength;

            if(collision.transform.position.x < transform.position.x) {
                player.knockFromRight = true;
            }
            else {
                player.knockFromRight = false;
            }
        }
    }
}
