using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ExcelManager : MonoBehaviour {
    // Start is called before the first frame update

    public TextAsset spawnRateData;
    public int dataAmount = 11;

    [System.Serializable]

    public class MonsterSpawnRate{
        public string monsterName;
        public float morningSpawnRate;
        public float middaySpawnRate;
        public float eveningSpawnRate;
        public float midnightSpawnRate;
        public float coldSpawnRate;
        public float warmSpawnRate;
        public float hotSpawnRate;
        public float clearSpawnRate;
        public float cloudySpawnRate;
        public float rainSpawnRate;
    }

    [System.Serializable]

    public class MonsterSpawnRateList{
        public MonsterSpawnRate[] monsterSpawnRateList;
    }


    public MonsterSpawnRateList currentMonsterSpawnRates = new MonsterSpawnRateList();

    void Start()
    {
        ReadCSV();
        
    }


    public void ReadCSV(){
        
        string[] data = spawnRateData.text.Split(new string[] {",","\n"}, StringSplitOptions.None); 
        int tableSize = data.Length / dataAmount - 1;
        currentMonsterSpawnRates.monsterSpawnRateList = new MonsterSpawnRate[tableSize];
        for(int i = 0; i < tableSize; i++){

            currentMonsterSpawnRates.monsterSpawnRateList[i] = new MonsterSpawnRate();
            currentMonsterSpawnRates.monsterSpawnRateList[i].monsterName = data[dataAmount * (i + 1)];
            currentMonsterSpawnRates.monsterSpawnRateList[i].morningSpawnRate = float.Parse(data[dataAmount * (i + 1) + 1]);
            currentMonsterSpawnRates.monsterSpawnRateList[i].middaySpawnRate = float.Parse(data[dataAmount * (i + 1) + 2]);
            currentMonsterSpawnRates.monsterSpawnRateList[i].eveningSpawnRate = float.Parse(data[dataAmount * (i + 1) + 3]);
            currentMonsterSpawnRates.monsterSpawnRateList[i].midnightSpawnRate = float.Parse(data[dataAmount * (i + 1) + 4]);
            currentMonsterSpawnRates.monsterSpawnRateList[i].coldSpawnRate = float.Parse(data[dataAmount * (i + 1) + 5]);
            currentMonsterSpawnRates.monsterSpawnRateList[i].warmSpawnRate = float.Parse(data[dataAmount * (i + 1) + 6]);
            currentMonsterSpawnRates.monsterSpawnRateList[i].hotSpawnRate = float.Parse(data[dataAmount * (i + 1) + 7]);
            currentMonsterSpawnRates.monsterSpawnRateList[i].clearSpawnRate = float.Parse(data[dataAmount * (i + 1) + 8]);
            currentMonsterSpawnRates.monsterSpawnRateList[i].cloudySpawnRate = float.Parse(data[dataAmount * (i + 1) + 9]);
            currentMonsterSpawnRates.monsterSpawnRateList[i].rainSpawnRate = float.Parse(data[dataAmount * (i + 1) + 10]);
        }

    }

}


