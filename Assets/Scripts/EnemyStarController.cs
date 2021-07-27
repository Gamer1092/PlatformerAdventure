using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStarController : MonoBehaviour {

    public float speed;
    public float rotationSpeed;
    public int damage;

    private bool attacked;
    private PlayerController player;
    private Rigidbody2D rb2d;

    public GameObject enemyStarParticles;

    // Use this for initialization
    void Start() {
        player = FindObjectOfType<PlayerController>();
        if(player == null) {
            return;
        }

        rb2d = GetComponent<Rigidbody2D>();

        if (player.transform.position.x < transform.position.x) {
            speed = -speed;
            rotationSpeed = -rotationSpeed;
        }
    }

    // Update is called once per frame
    void Update() {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        rb2d.angularVelocity = rotationSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            HealthManager.DamagePlayer(damage);
        }
        Instantiate(enemyStarParticles, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
