using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : MonoBehaviour
{

    public int roomNumber;
    public bool entrance;
    public Transform otherSide;
    //public Floor floor;

    private Floor floor;
    private GameController gameController;

    void Start()
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
        if (other.CompareTag("Player") && floor.CanGoIn(roomNumber, entrance))
        {
            Vector3 otherSidePosition = new Vector3(otherSide.localPosition.x, other.transform.position.y, otherSide.localPosition.z);
            other.gameObject.transform.position = otherSidePosition;
        }
        else if (other.CompareTag("Player"))
        {
            gameController.setMessage("Esta porta está trancada");
        }
    }
}
