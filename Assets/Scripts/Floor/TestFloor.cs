using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFloor : Floor
{
    public override bool CanGoIn(int roomNumber, bool entrance)
    {
        return false;
    }

    public override void EnemyKilled()
    {
        Debug.Log("Inimigo derrotado");
    }

    public override void FoundKey(int roomNumber)
    {
        Debug.Log("Chave encontrada"); 
    }

    public override bool LevelCleared()
    {
        return false;
    }

    public override void RoomCleared(int roomNumber)
    {
        Debug.Log("Inimigos derrotados");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
