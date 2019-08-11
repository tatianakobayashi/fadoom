using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : IEnemyAI
{
    EnemyStates enemy;
    float timer = 0;

    public AlertState(EnemyStates enemy)
    {
        this.enemy = enemy;
    }

    public void UpdateActions()
    {
        Search();
        Watch();
        if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance)
            LookAround();
    }
  
    void Watch()
    {
        RaycastHit hit;
        if (Physics.Raycast(enemy.transform.position, enemy.vision.forward, out hit, enemy.patrolRange)
            && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            enemy.navMeshAgent.destination = hit.transform.position;
            ToChaseState();
        }
    }
     
    void LookAround()
    {
        timer += Time.deltaTime;
        if (timer >= enemy.stayAlertTime)
        {
            timer = 0;
            ToPatrolState();
        }
    }
    // Funkcja ustawia ostatnie znane miejsce bohatera jako cel
    void Search()
    {
        enemy.navMeshAgent.destination = enemy.lastKnownPosition;
        enemy.navMeshAgent.isStopped = false;
    }


    public void OnTriggerEnter(Collider enemy)
    {

    }

    public void ToPatrolState()
    {
        enemy.currentState = enemy.patrolState;
    }

    public void ToAttackState()
    {
        Debug.Log("I'm alert already!");
    }

    public void ToAlertState()
    {
        Debug.Log("I'm alert already!");
    }

    public void ToChaseState()
    {
        enemy.currentState = enemy.chaseState;
    }
}
