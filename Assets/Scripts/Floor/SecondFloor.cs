using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFloor : Floor
{
    private bool[] keys;
    private bool[] roomClear;

    private int enemiesLeft;
    // Lab1 = roomNumber 5
    // Lab 2 = roomNumber 6

    private int currentRoom;

    public int[] enemiesPerRoom;

    private void Awake()
    {
        keys = new bool[6];
        keys[0] = true;

        roomClear = new bool[6];

        enemiesLeft = enemiesPerRoom[0];
        currentRoom = 0;

        ApplicationModel.cutscene = false;
        ApplicationModel.currentFloor = 1;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override bool CanGoIn(int roomNumber, bool entrance)
    {
        roomNumber--;
        if(keys[roomNumber] && entrance)
        {
            return true;
        }
        else if (roomClear[roomNumber] && !entrance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void EnemyKilled()
    {
        enemiesLeft--;

        if(enemiesLeft == 0 && currentRoom-1 < 5)
        {
            RoomCleared(currentRoom + 1);
        }

        if(currentRoom >= 5 && enemiesLeft == 0)
        {
            clear = true;
        }
    }

    public override void FoundKey(int roomNumber)
    {
        keys[roomNumber-1] = true;
    }

    public override bool LevelCleared()
    {
        return clear;
    }

    public override void RoomCleared(int roomNumber)
    {
        roomClear[roomNumber - 1] = true;
        currentRoom = roomNumber;
        if (roomNumber < 6)
            enemiesLeft = enemiesPerRoom[currentRoom];
        else
            enemiesLeft = 0;
    }
}
