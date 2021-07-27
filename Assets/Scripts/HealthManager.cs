using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public static int health;
    public int maxHealth;
    public Slider healthBar;

    private LevelManager levelManager;
    private PlayerLifeManager lifeSystem;
    private TimeManager time;

    public bool isDead;

    // Use this for initialization
    void Start () {
        healthBar = GetComponent<Slider>();
        health = PlayerPrefs.GetInt("PlayerCurrentHealth");
        levelManager = FindObjectOfType<LevelManager>();
        lifeSystem = FindObjectOfType<PlayerLifeManager>();
        time = FindObjectOfType<TimeManager>();
        isDead = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(health <= 0 && !isDead) {
            health = 0;
            levelManager.RespawnPlayer();
            isDead = true;
            lifeSystem.LoseALife();
            time.ResetTime();
        }

        if(health > maxHealth) {
            health = maxHealth;
        }

        healthBar.value = health;
	}

    public static void DamagePlayer (int damage) {
        health -= damage;
        PlayerPrefs.SetInt("PlayerCurrentHealth", health);
    }

    public static void HealPlayer(int extraHealth)
    {
        health += extraHealth;
        PlayerPrefs.SetInt("PlayerCurrentHealth", health);
    }

    public void FullHealth () {
        health = PlayerPrefs.GetInt("PlayerMaxHealth");
        PlayerPrefs.SetInt("PlayerCurrentHealth", health);
    }

    public void KillPlayer() {
        health = 0;
    }
}
