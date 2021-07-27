using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckPoint;
    public GameObject deathParticles;
    public GameObject spawnParticles;

    public float respawnDelay;
    public int pointPenalty;

    private PlayerController player;
    private CameraController cam;
    private float gravityStore;

    public HealthManager healthManager;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        cam = FindObjectOfType<CameraController>();
        healthManager = FindObjectOfType<HealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPlayer() {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo() {
        Instantiate(deathParticles, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        cam.isFollowing = false;
        ScoreManager.AddPoints(-pointPenalty);

        yield return new WaitForSeconds(respawnDelay);
        player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        player.transform.position = currentCheckPoint.transform.position;
        player.knockBackCount = 0;
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        Instantiate(spawnParticles, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);

        healthManager.FullHealth();
        healthManager.isDead = false;
        cam.isFollowing = true;
    }
}
