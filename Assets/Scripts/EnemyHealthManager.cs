using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyHealth;
    public GameObject deathEffect;
    public int pointsOnDeath;
    public AudioSource enemyHurt;

	// Use this for initialization
	void Start () {
        enemyHurt = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyHealth <= 0) {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            ScoreManager.AddPoints(pointsOnDeath);
        }
	}

    public void TakeDamage(int damage) {
        enemyHealth -= damage;
        enemyHurt.Play();
    }
}
