using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    public int[] yourTeam = new int[3];
    public int[] enemyTeam = new int[3];
    public int mapType = 0;

    public ToggleGroup toggleGroupLeft;
    public ToggleGroup toggleGroupRight;
    private int countLeft = 0;
    private int countRight = 0;

    public void Start()
    {
        toggleGroupLeft.SetAllTogglesOff();
        toggleGroupRight.SetAllTogglesOff();
    }
    public void startPressed()
    {
        




        
        
        

    }
}
