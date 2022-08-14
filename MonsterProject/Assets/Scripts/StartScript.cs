using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public int[] yourTeam = new int[3];
    public int[] enemyTeam = new int[3];
    public int mapType = 0;
    public GameObject panelLeft;
    public GameObject panelRight;
    

    public void startPressed()
    {
        int counter = 0;
        bool isOn;
        isOn = panelLeft.GetComponentInChildren<Toggle>.isOn();
        

    }
}
