using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Monsters")]
public class Monster : ScriptableObject
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public int monsterID;
    public string monsterName;
    public int combatPower;

}
