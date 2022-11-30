using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;
using UnityEngine.UI;
public class SpawnManager : MonoBehaviour
{

    // HARD CODE METHOD
    public WeatherManager weatherData; 
    public List<Monster> spawnList = new List<Monster>(); // List of spawnable monsters
    public float expeditionLength = 300.0f;               // Length of expedition
    public float spawnCheck = 30.0f;                      // Length of time to spawn creatures
    public float time = 0.0f;                             // Current time
    public List<Monster> spawnedMonsters = new List<Monster>();
    public float rng;
    public ExcelManager spawnRateList;
    private int  morningStart = 10800; // 
    private int middayStart = 32400;
    private int eveningStart = 54000;
    private int midnightStart = 75600;
    public int currentTime;
    public GameObject spawnedSprites;



    // Start is called before the first frame update
    public void Start()
    {

        for(int o = 0; o < spawnList.Count; o++){
            spawnList[o].adjustedSpawnRate = spawnList[o].baseSpawnRate;
        }

        ApplySpawnConditions();
            
    }

    // Update is called once per frame
    void Update()
    {

        if(expeditionLength > 0.0f){
            time += Time.deltaTime;
        }

        if(time >= spawnCheck){
            Spawn();
            time = 0.0f; 
            expeditionLength -= spawnCheck;
        }  

        else {
            spawnedMonsters.Sort(delegate(Monster a, Monster b){
                return((a.name).CompareTo(b.name));
            });

        } 
    }



    void Spawn(){

        float totalSpawnRate = 0.0f; 
        for(int i = 0; i < spawnList.Count; i++){
            totalSpawnRate += spawnList[i].adjustedSpawnRate;
        }

        rng = Random.Range(0, totalSpawnRate);

        for(int j = 0; j < spawnList.Count; j++){
            if(rng <= spawnList[j].adjustedSpawnRate){
                spawnedMonsters.Add(spawnList[j]);
                for(int i = 0; i < spawnedSprites.transform.childCount; i++){
                    if(spawnedSprites.transform.GetChild(i).GetComponent<Image>().sprite == null){
                        spawnedSprites.transform.GetChild(i).GetComponent<Image>().sprite = spawnList[j].sprite;
                        break;
                    }

                }

                break;
            }

            else{
                rng -= spawnList[j].adjustedSpawnRate;
            }
        }}



    void ApplySpawnConditions(){                                                                                                                                   
        for(int o = 0; o < weatherData.conditionsConverted.Count; o++){
            Debug.Log(weatherData.conditionsConverted.Count);
            
            switch(weatherData.conditionsConverted[o])
            {
                case "Clear":
                    for(int j = 0; j < spawnList.Count; j++){
                        spawnList[j].adjustedSpawnRate *= spawnRateList.currentMonsterSpawnRates.monsterSpawnRateList[j].clearSpawnRate;
                    }
                    break;
                
                case "Partially cloudy":
                    for(int j = 0; j < spawnList.Count; j++){
                        spawnList[j].adjustedSpawnRate *= spawnRateList.currentMonsterSpawnRates.monsterSpawnRateList[j].cloudySpawnRate;
                    }
                    break;

                case "Rain":
                    for(int j = 0; j < spawnList.Count; j++){
                        spawnList[j].adjustedSpawnRate *= spawnRateList.currentMonsterSpawnRates.monsterSpawnRateList[j].rainSpawnRate;
                    }
                    break;
            }
        }

        Debug.Log(weatherData.data.currentConditions.temp);
        if(weatherData.data.currentConditions.temp <= 18){
            Debug.Log("Cold");
            for(int j = 0; j < spawnList.Count; j++){
                spawnList[j].adjustedSpawnRate *= spawnRateList.currentMonsterSpawnRates.monsterSpawnRateList[j].coldSpawnRate;
            }
        }

        if(weatherData.data.currentConditions.temp > 18 && weatherData.data.currentConditions.temp <= 28 ){
            Debug.Log("Warm");
            for(int j = 0; j < spawnList.Count; j++){
                spawnList[j].adjustedSpawnRate *= spawnRateList.currentMonsterSpawnRates.monsterSpawnRateList[j].warmSpawnRate;
            }
        }

        if(weatherData.data.currentConditions.temp > 28){
            Debug.Log("Hot");
            for(int j = 0; j < spawnList.Count; j++){
                spawnList[j].adjustedSpawnRate *= spawnRateList.currentMonsterSpawnRates.monsterSpawnRateList[j].hotSpawnRate;
            }
        }
        if(weatherData.morningTest == true){
            currentTime = morningStart;
        }

        else if(weatherData.middayTest == true){
            currentTime = middayStart;
        }

        else if(weatherData.eveningTest == true){
            currentTime = eveningStart;
        }

        else if(weatherData.nightTest == true){
            currentTime = midnightStart;
        }

        else{
            currentTime = (((System.DateTime.Now.Hour)*60)*60) + (System.DateTime.Now.Minute * 60) + System.DateTime.Now.Second;
        }

        Debug.Log(currentTime);

        if(currentTime >= morningStart && currentTime < middayStart){
            for(int j = 0; j < spawnList.Count; j++){
                spawnList[j].adjustedSpawnRate *= spawnRateList.currentMonsterSpawnRates.monsterSpawnRateList[j].morningSpawnRate;
            }

            Debug.Log("Morning");
        }

        if(currentTime >= middayStart && currentTime < eveningStart){
            for(int j = 0; j < spawnList.Count; j++){
                spawnList[j].adjustedSpawnRate *= spawnRateList.currentMonsterSpawnRates.monsterSpawnRateList[j].middaySpawnRate;
            }

            Debug.Log("Midday");
        }

        if(currentTime >= eveningStart && currentTime < midnightStart){
            for(int j = 0; j < spawnList.Count; j++){
                spawnList[j].adjustedSpawnRate *= spawnRateList.currentMonsterSpawnRates.monsterSpawnRateList[j].eveningSpawnRate;
            }
            Debug.Log("Evening");
        }

        if(currentTime >= midnightStart){
            for(int j = 0; j < spawnList.Count; j++){
                spawnList[j].adjustedSpawnRate *= spawnRateList.currentMonsterSpawnRates.monsterSpawnRateList[j].midnightSpawnRate;
            }
            Debug.Log("Midnight");
        }



       

        for(int i = 0; i < spawnList.Count; i++){
            spawnList.Sort(delegate(Monster a, Monster b){
                return((b.adjustedSpawnRate).CompareTo(a.adjustedSpawnRate));
            });
        }




    }
}
