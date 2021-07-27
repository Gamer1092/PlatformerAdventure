using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public GameObject platform;
    public float moveSpeed;

    private Transform currentPoint;
    public Transform[] points;

    public int pointSelection;

	// Use this for initialization
	void Start () {
        currentPoint = points[pointSelection];
	}
	
	// Update is called once per frame
	void Update () {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, moveSpeed * Time.deltaTime);
        if(platform.transform.position == currentPoint.position) {
            pointSelection++;
            if(pointSelection == points.Length) {
                pointSelection = 0;
            }
            currentPoint = points[pointSelection];
        }
	}
}
