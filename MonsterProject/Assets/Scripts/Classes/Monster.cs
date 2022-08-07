using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    public int MID;
    public string Name;
    public int Level;
    public int Experience;

    public int MaxHealth;
    public int Health;

    public int Attack;
    public int Defense;
    public int Mana;


    public Monster(int ID, string Name, int lv, int exp, int power)
    {
        MID = ID;
        this.Name = Name;
        Level = lv;
        Experience = exp;
    }

    public Monster()
    {
        MID = 0;
        Name = "nullMonster";
        Level = 1;
        Experience = 0;
        MaxHealth = 10;
        Health = 10;
        Attack = 1;
        Defense = 1;
        Mana = 10;

    }

    public void levelup(int over)
    {
        this.Level++;
        Experience = over; //leftover exp after levelup
    }

    public void checkEXP()
    {
        if (this.Level <= 0)
        {
            this.levelup(0);
        }

        if (this.Experience >= 10)
        {
            this.levelup(0);
        }


    }
}
