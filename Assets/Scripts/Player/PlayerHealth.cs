using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public AudioClip hit;
    public FlashScreen flash;

    AudioSource source;
    float health;
    
    GameController controller;

    void Start()
    {
        health = maxHealth;
        source = GetComponent<AudioSource>();


        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        controller = null;

        if (gameControllerObject != null)
        {
            controller = gameControllerObject.GetComponent<GameController>();
        }
        if (controller == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        updateHealth();
    }

    private void Update()
    {
        if(health <= 0)
        {
            flash.PlayerDied();
            controller.PlayerDied();
        }

        if (controller.hasWon())
        {
            flash.hasWon();
        }
        
    }

    public void EnemyHit(float damage)
    {
        if (health > 0)
        {
            source.PlayOneShot(hit);
            health -= damage;
            flash.TookDamage();
        }

        updateHealth();
    }

    public bool IsAlive()
    {
        return health > 0;
    }

    public void Heal(int healValue)
    {
        float newHealth = health + healValue;
        if(newHealth > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health = newHealth;
        }
        flash.TakeHeal();
        updateHealth();
    }

    private void updateHealth()
    {
        controller.setHealth("Health: " + health.ToString());
    }
}
