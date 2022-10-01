using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;
public class SpawnManager : MonoBehaviour
{

    public WeatherManager weatherData; 
    public List<Monster> spawnList = new List<Monster>(); // List of spawnable monsters
    public List<float> spawnRates = new List<float>();    // List of monster spawn rates
    private float expeditionLength = 1800.0f;             // Length of expedition
    private float spawnCheck = 180.0f;                    // Length of time to spawn creatures
    private float time = 0.0f;                            // Current time
    private float totalSpawnRate;                         // Total spawn rates
    private float unfavourableConditions = 0.5f;
    private float extremelyUnfavourableConditions = 0.25f;
    private float favourableConditions = 2.0f;
    private float extremelyFavourableConditions = 3.0f;
    public List<Monster> spawnedMonsters = new List<Monster>();
    public float rng;



    // Start is called before the first frame update
    void Start()
    {

        for(int o = 0; o < spawnList.Count; o++){
            spawnList[o].adjustedSpawnRate = 0.0f;
        }

        ApplySpawnConditions();
        

        for(int i = 0; i < spawnList.Count; i++){
            spawnList.Sort(delegate(Monster a, Monster b){
                return((a.adjustedSpawnRate).CompareTo(b.adjustedSpawnRate));
            });
        }

        
  
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
    }


    void Spawn(){

        for(int i = 0; i < spawnList.Count; i++){
            totalSpawnRate += spawnList[i].baseSpawnRate;
        }

        rng = Random.Range(0, totalSpawnRate);

        for(int j = 0; j < spawnList.Count; j++){
            if(rng <= spawnList[j].adjustedSpawnRate){
                spawnedMonsters.Add(spawnList[j]);
                break;
            }

            else{
                rng -= spawnList[j].adjustedSpawnRate;
            }
        }}



    void ApplySpawnConditions(){                                 // CALCULATION FOR SPAWN RATES: 
        bool isConditionsFavourable = false;
        bool isConditionsVeryFavourable = false;
        for(int i = 0; i < spawnList.Count; i++){
            for(int j = 0; j < spawnList[i].spawnWeatherConditions.Count; j++){   // Applying spawn rate weather conditions to base spawn rate
                for(int k = 0; k < weatherData.conditionsConverted.Count; k++){
                        if(spawnList[i].spawnWeatherConditions[j] == weatherData.conditionsConverted[k] && isConditionsFavourable == true){
                            isConditionsVeryFavourable = true;
                        }

                        if(spawnList[i].spawnWeatherConditions[j] == weatherData.conditionsConverted[k]){
                            isConditionsFavourable = true;
                        }
                        
                }
            }

            if(isConditionsFavourable == true && isConditionsVeryFavourable == true){
                spawnList[i].adjustedSpawnRate *= extremelyFavourableConditions;
            }

            if(isConditionsVeryFavourable == true && isConditionsVeryFavourable == false){
                spawnList[i].adjustedSpawnRate *= favourableConditions;            
            }

            else {
              spawnList[i].adjustedSpawnRate *= unfavourableConditions;    
            }

            isConditionsFavourable = false;
            isConditionsVeryFavourable = false;

            if(weatherData.data.currentConditions.temp >= spawnList[i].spawnTemperatureConditions[0] && weatherData.data.currentConditions.temp <= spawnList[i].spawnTemperatureConditions[1]){
                spawnList[i].adjustedSpawnRate *= favourableConditions;  
            }

            int tmp1 = DateTime.Compare(System.DateTime.Now, spawnList[i].spawnTimeConditions[0]);
            int tmp2 = DateTime.Compare(System.DateTime.Now, spawnList[i].spawnTimeConditions[1]);

            if(tmp1 >= 0 && tmp2 <= 0){
                spawnList[i].adjustedSpawnRate *= favourableConditions;  
            }

            if(tmp1 < 0 || tmp2 > 0){
                spawnList[i].adjustedSpawnRate *= unfavourableConditions;  

            }

        }
    }
}
