using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Floor : MonoBehaviour
{

    protected bool canGoToTheNext;
    protected bool clear;
    public int numberOfEnemies;

    public abstract bool CanGoIn(int roomNumber, bool entrance);
    public abstract void FoundKey(int roomNumber);
    public abstract bool LevelCleared();
    public abstract void RoomCleared(int roomNumber);

    public abstract void EnemyKilled();
}
