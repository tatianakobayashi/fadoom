using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PagliGodController : MonoBehaviour
{
    public Transform[] waypoints;
    int nextWayPoint = 0;
    public float MaxHealth;

    private GameObject thirdEye;
    private float health;
    bool secondFase = false;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponentInParent<NavMeshAgent>();
        health = MaxHealth;
        thirdEye = transform.Find("ThirdEye").gameObject;
        thirdEye.GetComponent<ParticleSystem>().Stop();
        thirdEye.GetComponent<SecondFaseShooter>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        // Make Pagliosa Navigate
        navMeshAgent.destination = waypoints[nextWayPoint].position;
        navMeshAgent.isStopped = false;
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending)
        {
            nextWayPoint = (nextWayPoint + 1) % waypoints.Length;
        }
        // Verificar Pagligod's health
        if(health <= 0)
        {
            GameObject gameControllerObjext = GameObject.FindWithTag("GameController");
            Floor f = null;

            if (gameControllerObjext != null)
            {
                f = gameControllerObjext.GetComponent<Floor>();
            }
            if (f == null)
            {
                Debug.Log("Cannot find 'Floor' script");
            }
            f.EnemyKilled();

            Destroy(this.gameObject);
        }
        // Se estiver com menos de um terço da vida inicia segunda fase
        else if (health <= MaxHealth / 3.0 && !secondFase)
        {
            thirdEye.GetComponent<ParticleSystem>().Play();
            thirdEye.GetComponent<SecondFaseShooter>().enabled = true;
            secondFase = true;
        }

    }

    public void PistolHit(float pistolDamage)
    {
        health -= pistolDamage;
    }
}
