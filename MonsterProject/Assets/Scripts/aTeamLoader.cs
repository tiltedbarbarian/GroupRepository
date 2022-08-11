using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aTeamLoader : MonoBehaviour
{
    public Player playerData;
    private List<MonsterData> activeTeam;

    void Start()
    {
        activeTeam = playerData.ActiveTeam;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
