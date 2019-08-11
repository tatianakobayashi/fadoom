using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFloor : Floor
{
    

    public override bool CanGoIn(int roomNumber, bool entrance)
    {
        Debug.Log("There shouldn't be any room doors in this level");
        return false;
    }

    public override void EnemyKilled()
    {
        numberOfEnemies--;

        if(numberOfEnemies == 0)
        {
            GetComponent<GameController>().Victory();
        }
    }

    public override void FoundKey(int roomNumber)
    {
        // do nothing
        Debug.Log("There shouldn't be any keys in this level");
    }

    public override bool LevelCleared()
    {
        return numberOfEnemies == 0;
    }

    public override void RoomCleared(int roomNumber)
    {
        Debug.Log("There shouldn't be any rooms in this level");
    }
}
