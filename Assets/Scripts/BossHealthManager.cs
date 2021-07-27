using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour {

    public int bossHealth;
    public GameObject deathEffect;
    public int pointsOnDeath;
    public AudioSource bossHurt;
    public GameObject bossPrefab;

    public float minSize;

    // Use this for initialization
    void Start() {
        bossHurt = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (bossHealth <= 0) {
            if (transform.localScale.y > minSize) {
                GameObject clone1 = (GameObject) Instantiate(bossPrefab, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z),
                                                transform.rotation);
                GameObject clone2 = (GameObject) Instantiate(bossPrefab, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z),
                                                transform.rotation);

                clone1.transform.localScale = new Vector3(transform.localScale.x - 0.25f, transform.localScale.y - 0.25f, transform.localScale.z);
                clone1.GetComponent<BossHealthManager>().bossHealth = 10;

                clone2.transform.localScale = new Vector3(transform.localScale.x - 0.25f, transform.localScale.y - 0.25f, transform.localScale.z);
                clone2.GetComponent<BossHealthManager>().bossHealth = 10;

                Instantiate(deathEffect, transform.position, transform.rotation);
                Destroy(gameObject);
                ScoreManager.AddPoints(pointsOnDeath);
            }

            else {
                Instantiate(deathEffect, transform.position, transform.rotation);
                Destroy(gameObject);
                ScoreManager.AddPoints(pointsOnDeath);
            }
        }
    }

    public void TakeDamage(int damage) {
        bossHealth -= damage;
        bossHurt.Play();
    }
}
