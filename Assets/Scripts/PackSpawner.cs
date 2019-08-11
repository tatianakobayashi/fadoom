using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackSpawner : MonoBehaviour
{
    public GameObject pack;
    public float cooldown;

    float timer;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= cooldown)
        {
            Instantiate(pack, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
