﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    public float moveSpeed;
    public bool moveRight;

    public float wallCheckRadius;
    public Transform wallCheck;
    public LayerMask whatIsWall;
    private bool hitWall;

    private bool notAtEdge;
    public Transform edgeCheck;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        hitWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (hitWall || !notAtEdge)
            moveRight = !moveRight;

        if (moveRight) {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        else {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }
    }
}
