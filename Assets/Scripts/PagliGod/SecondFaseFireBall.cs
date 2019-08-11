using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFaseFireBall : MonoBehaviour
{
    public float damage;
    public float speed;
    public float spread;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(player);
        transform.Rotate(Random.Range(2.0f, 10.0f), Random.Range(2.0f, 10.0f), Random.Range(2.0f, 10.0f), Space.Self);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().EnemyHit(damage);
        }
        if (!other.CompareTag("Missile"))
        {
            Destroy(this.gameObject);
        }
    }
}
