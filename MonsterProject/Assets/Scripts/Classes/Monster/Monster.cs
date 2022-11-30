using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Monsters")]
public class Monster : ScriptableObject
{

    //BASIC DETAILS
    private int monsterID;
    private string monsterName;
    private int combatPower;


    // SPRITE DETAILS
    private SpriteRenderer spriteRenderer;
    public Sprite sprite;


    //SPAWN DETAILS
    public float baseSpawnRate;
    public float adjustedSpawnRate;

    






}
