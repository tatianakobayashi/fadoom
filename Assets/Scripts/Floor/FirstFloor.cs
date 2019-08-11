using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloor : Floor
{
    int enemies1 = 2;

    int enemiesKilled;

    bool auditorium2Key;
    bool room1Clear;
    bool room2Clear;

    public override bool CanGoIn(int roomNumber, bool entrance)
    {
        switch (roomNumber)
        {
            case 1:
                if (entrance)
                {
                    return true;
                }
                else
                {
                    return room1Clear;
                }
            case 2:
                if (entrance)
                {
                    return auditorium2Key;
                }
                else
                {
                    return room1Clear;
                }
            default:
                return false;
        }
    }

    public override void FoundKey(int roomNumber)
    {
        if (roomNumber == 2)
        {
            auditorium2Key = true;
        }
    }

    public override bool LevelCleared()
    {
        return clear;
    }

    public override void RoomCleared(int roomNumber)
    {
        switch (roomNumber)
        {
            case 1:
                room1Clear = true;
                break;
            case 2:
                room2Clear = true;
                break;
            default:
                break;
        }
    }

    public override void EnemyKilled()
    {
        enemiesKilled++;

        if(enemiesKilled >= enemies1)
        {
            room1Clear = true;
        }

        if(enemiesKilled == numberOfEnemies)
        {
            room2Clear = true;
        }
    }

    private void Start()
    {
        canGoToTheNext = false;
        auditorium2Key = false;
        clear = false;
        enemiesKilled = 0;

        ApplicationModel.cutscene = false;
        ApplicationModel.currentFloor = 0;
    }

    private void Update()
    {
        if(room1Clear && room2Clear && !clear)
        {
            Debug.Log("Level clear");
            clear = true;
        }
    }
}
