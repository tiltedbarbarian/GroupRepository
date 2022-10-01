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
    private Sprite[] sprites;


    //SPAWN DETAILS
    public float baseSpawnRate;
    public float adjustedSpawnRate;
    public List<string> spawnWeatherConditions = new List<string>();
    public List<System.DateTime> spawnTimeConditions = new List<System.DateTime>();
    public List<float> spawnTemperatureConditions = new List<float>();
    






}
