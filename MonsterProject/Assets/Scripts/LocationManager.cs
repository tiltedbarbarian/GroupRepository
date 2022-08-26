using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class LocationManager : MonoBehaviour
{

    private string IPAddress;
    public LocationInfo Info;
    public float latitude;
    public float longitude; 
    public string city;
    public string country;
    public WeatherManager weatherManager;
    public GameObject UI;

    void Start() {

       StartCoroutine(GetIP());
    }

    public IEnumerator GetIP(){
        var www = new UnityWebRequest("https://api64.ipify.org/") {
            downloadHandler = new DownloadHandlerBuffer()
        }; 

        yield return www.SendWebRequest();

        if(www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError) {
            yield break;
        }

        IPAddress = www.downloadHandler.text;
        StartCoroutine(GetCoordinates());
    }

    public IEnumerator GetCoordinates(){
        var www = new UnityWebRequest("http://ip-api.com/json/" + IPAddress)
        
        {
            downloadHandler = new DownloadHandlerBuffer()
        };

        yield return www.SendWebRequest();

        if(www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError) {
            yield break;
        }

        Info = JsonUtility.FromJson<LocationInfo>(www.downloadHandler.text);
        latitude = Info.lat;
        longitude = Info.lon;
        city = Info.city;
        country = Info.country;

        weatherManager.Begin();

    }
           
}

[System.Serializable]
public class LocationInfo{
    public string status;
    public string country;
    public string countryCode;
    public string region;
    public string regionName;
    public string city;
    public string zip;
    public float lat;
    public float lon;
    public string timezone;
    public string isp;
    public string org;
    public string @as;
    public string query;
}

