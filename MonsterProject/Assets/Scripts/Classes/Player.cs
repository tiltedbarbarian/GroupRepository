using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Player : MonoBehaviour
{
    public string playerName;
    public string playerId;
    public List<Monster> activeTeam;
    public List<Monster> monsterStorage;

    void Start()
    {
        try
        {
            using (StreamReader sr = new StreamReader("TestFile.txt"))
            {
                playerName = sr.ReadLine();
                playerId = sr.ReadLine();
                


                
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The File could not be read:");
            Console.WriteLine(e.Message);
        }
        
    }

    
    void Update()
    {
        
    }
}
