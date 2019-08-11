using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDoors : MonoBehaviour
{

    private Floor floor;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObjext = GameObject.FindWithTag("GameController");

        if (gameControllerObjext != null)
        {
            floor = gameControllerObjext.GetComponent<Floor>();
            gameController = gameControllerObjext.GetComponent<GameController>();
        }
        if (floor == null)
        {
            Debug.Log("Cannot find 'Floor' script");
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("door Collided with: " + other.name);
        if (other.CompareTag("Player") && floor.LevelCleared())
        {
            gameController.NextScene();
        }
        else if (other.CompareTag("Player")){
            gameController.setMessage("Você ainda não pode subir");
        }
    }
}
