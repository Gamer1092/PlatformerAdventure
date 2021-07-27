using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour {

    public int damage;
    public float bounceOnEnemy;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = transform.parent.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Enemy") {
            collision.GetComponent<EnemyHealthManager>().TakeDamage(damage);
            rb2d.velocity = new Vector2(rb2d.velocity.x, bounceOnEnemy);
        }
    }
}
