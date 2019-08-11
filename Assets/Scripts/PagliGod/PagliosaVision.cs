using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagliosaVision : MonoBehaviour
{
    Transform playerPosition;
    public float YAxisRotation = -80f;

    private void Start()
    {
        playerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.LookAt(playerPosition.position);
        Quaternion originalRot = transform.rotation;
        transform.rotation = originalRot * Quaternion.Euler(YAxisRotation, 0, 0);
    }
}
