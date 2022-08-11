using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData
{
    public int MonsterID;
    public string Name;
    public int combatPower;

    public MonsterData(int monID, string name, int cP)
    {
        MonsterID = monID;
        Name = name;
        combatPower = cP;

    }
}
