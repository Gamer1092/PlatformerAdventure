using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMove : MonoBehaviour {

    private PlayerController player;

    public float moveSpeed;
    public float playerRange;

    public LayerMask playerLayer;
    public bool playerInRange;

    public bool facingAway;
    public bool followOnLookAway;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);

        if(!followOnLookAway) {
            if(playerInRange) {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                return;
            }
        }

        if((player.transform.position.x < transform.position.x && player.transform.localScale.x < 0) ||
            (player.transform.position.x > transform.position.x && player.transform.localScale.x > 0)) {
            facingAway = true;
        }
        else {
            facingAway = false;
        }

        if (playerInRange && facingAway) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawSphere(transform.position, playerRange);
    }
}
