using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    IEnumerator Start(){

        if (!Input.location.isEnabledByUser){
            yield break;
        }

        Input.location.Start();

        int maxWait = 20;

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0){
            yield 
        }
    }
        
    
}
