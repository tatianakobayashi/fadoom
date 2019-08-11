using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public Sprite deadBody;
    public int maxHealth;
    float health;

    EnemyStates es;
    NavMeshAgent nma;
    SpriteRenderer sr;
    BoxCollider bc;
    SelfDestruct sd;
    Floor floor;
    bool notUpdated;

    private void Start()
    {
        health = maxHealth;
        es = GetComponent<EnemyStates>();
        nma = GetComponent<NavMeshAgent>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider>();
        sd = GetComponent<SelfDestruct>();

        sd.enabled = false;

        GameObject gameControllerObjext = GameObject.FindWithTag("GameController");

        if (gameControllerObjext != null)
        {
            floor = gameControllerObjext.GetComponent<Floor>();
        }
        if (floor == null)
        {
            Debug.Log("Cannot find 'Floor' script");
        }
        notUpdated = true;
    }

    private void Update()
    {
        if (health <= 0 && notUpdated)
        {
            es.enabled = false;
            nma.enabled = false;
            sr.sprite = deadBody;
            bc.center = new Vector3(0, -0.8f, 0);
            bc.size = new Vector3(1.05f, 0.43f, 0.2f);

            sd.enabled = true;

            floor.EnemyKilled();
            notUpdated = false;
        }
    }

    public void PistolHit(float damage)
    {
        health -= damage;
        Debug.Log("Current health: " + health);
    }
}
