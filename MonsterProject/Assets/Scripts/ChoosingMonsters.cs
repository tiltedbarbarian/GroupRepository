using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingMonsters : MonoBehaviour
{
    List<Monster> monsters = new List<Monster>();
    List<Monster> playerMonsters = new List<Monster>();
    List<Monster> enemyMonsters = new List<Monster>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ChooseMonster(Monster chosenMonster){
        if(playerMonsters.Count > 3){
            playerMonsters.Add(chosenMonster);
        }
        
        else {
            enemyMonsters.Add(chosenMonster);
        }
    }
}
