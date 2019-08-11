using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStates : MonoBehaviour
{
    public Transform[] waypoints;
    public int patrolRange;
    public int shootRange;
    public int attackRange;
    public Transform vision;
    public float stayAlertTime;

    public GameObject missile;
    public float missileDamage;
    public float missileSpeed;

    public bool onlyMelee = false;
    public float meleeDamage;
    public float attackDelay;

    public LayerMask raycastMask;

    [HideInInspector]
    public AttackState attackState;
    [HideInInspector]
    public AlertState alertState;
    [HideInInspector]
    public ChaseState chaseState;
    [HideInInspector]
    public PatrolState patrolState;
    [HideInInspector]
    public IEnemyAI currentState;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;
    [HideInInspector]
    public Transform chaseTarget;
    [HideInInspector]
    public Vector3 lastKnownPosition;

    void Awake()
    {
        attackState = new AttackState(this);
        alertState = new AlertState(this);
        chaseState = new ChaseState(this);
        patrolState = new PatrolState(this);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = patrolState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateActions();
    }

    void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    // The function responsible for capturing hero shots
    // The position from which the hero shot was placed as the last known position of his stay
    void HiddenShot(Vector3 shotPosition)
    {
        Debug.Log("Someone scored");
        lastKnownPosition = shotPosition;
        currentState = alertState;
    }
}
