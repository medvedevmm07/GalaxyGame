using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamEnemyGroup : GroupBase
{
    public RamShip firstShip;
    public RamShip secondShip;
    void Update()
    {
        if(firstShip==null && secondShip==null)
        {
            isAlive=false;
        }
    }
}
