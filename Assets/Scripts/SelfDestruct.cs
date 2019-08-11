using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float timeToLive;

    private float timer;

    void Start()
    {
        timer = 0;
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeToLive)
        {
            //Debug.Log("Dying");
            Destroy(this.gameObject);
        }
    }
}
