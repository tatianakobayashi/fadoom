using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [HideInInspector]
    public float damage;
    [HideInInspector]
    public float speed;
    Transform player;
    //int missileLife;
    //float timer;

    void Start()
    {
        //missileLife = 15;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(player);

        //Debug.Log("I live...");
    }

    void Update()
    {
        //timer += Time.deltaTime;
        //if (timer > missileLife)
        //{
            //Debug.Log("Dying");
        //    Destroy(this.gameObject);
        //}
            
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //other.SendMessage("EnemyHit", damage, SendMessageOptions.DontRequireReceiver);
            other.GetComponent<PlayerHealth>().EnemyHit(damage);
        }
        Destroy(this.gameObject);
    }
}
