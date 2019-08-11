using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallShooter : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject fireBall;
    public float fireDelay;
    private float nextFire;
    
    // Start is called before the first frame update
    private void Start()
    {
        nextFire = Time.time + fireDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextFire <= Time.time)
        {
            foreach (Transform loc in spawnPoints)
            {
                GameObject.Instantiate(fireBall, loc.position, Quaternion.identity);
            }
            nextFire += fireDelay;
        }
    }
}
