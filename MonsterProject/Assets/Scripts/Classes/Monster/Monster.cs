using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Monsters")]
public class Monster : ScriptableObject
{
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    public Vector3 spawnPoint;
    public int combatPower;
    public string mName;
    public int mID;

}
