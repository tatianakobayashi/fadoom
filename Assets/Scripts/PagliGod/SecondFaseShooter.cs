using System.Collections;
using UnityEngine;

public class SecondFaseShooter : MonoBehaviour
{
    public GameObject fireBall;
    public float fireDelay;
    public int shotsPerWave;
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
            StartCoroutine("fire");
            nextFire += fireDelay;
        }
    }

    IEnumerator fire()
    {
        for (int i = 0; i < shotsPerWave; i++)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject.Instantiate(fireBall, transform.position, Quaternion.identity);
        }
    }

}

