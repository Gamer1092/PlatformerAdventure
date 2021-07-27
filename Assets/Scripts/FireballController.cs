using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour {

    public float speed;
    public float rotationSpeed;
    public int pointsForKill;
    public int damage;

    private bool attacked;
    private PlayerController player;
    private Rigidbody2D rb2d;

    public GameObject fireBallParticles;
    public GameObject enemyDeathParticles;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        rb2d = GetComponent<Rigidbody2D>();
        attacked = false;

        if(player.transform.localScale.x < 0) {
            speed = -speed;
            rotationSpeed = -rotationSpeed;
        }
	}
	
	// Update is called once per frame
	void Update () {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        rb2d.angularVelocity = rotationSpeed;
	}


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Enemy" && attacked == false) {
            attacked = true;
            collision.GetComponent<EnemyHealthManager>().TakeDamage(damage);
        }

        if (collision.tag == "Boss" && attacked == false) {
            attacked = true;
            collision.GetComponent<BossHealthManager>().TakeDamage(damage);
        }
        Instantiate(fireBallParticles, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
