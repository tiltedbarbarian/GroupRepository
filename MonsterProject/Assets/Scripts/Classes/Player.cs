using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Player : MonoBehaviour
{
    public string playerName;
    public string playerId;

    void Start()
    {
        string readFromFilePath = Application.streamingAssetsPath + "/PlayerData/" + "PlayerData.txt";
        string[] readLines = File.ReadAllLines(readFromFilePath);
        playerName = readLines[0];
        playerId = readLines[1];
        
        
    }

    
    void Update()
    {
        
    }
}
