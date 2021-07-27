using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour {

    public float playerRange;
    public GameObject enemyStar;
    public PlayerController player;
    public Transform launchPoint;

    public float shotDelay;
    private float shotCounter;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        shotCounter = shotDelay;
	}
	
	// Update is called once per frame
	void Update () {

        if(!FindObjectOfType<PlayerController>()) {
            return;
        }

        shotCounter -= Time.deltaTime;

        // Attack the player when he is on the left
		if(transform.localScale.x < 0 && player.transform.position.x > transform.position.x 
            && player.transform.position.x < transform.position.x + playerRange && shotCounter < 0) {
            Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);
            shotCounter = shotDelay; 
        }

        // Attack the player when he is on the right  
        if(transform.localScale.x > 0 && player.transform.position.x < transform.position.x
            && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0) {
            Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);
            shotCounter = shotDelay;
        }
	}
}
