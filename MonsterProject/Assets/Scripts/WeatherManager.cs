using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class WeatherManager : MonoBehaviour
{
    public WeatherData data;
    public GameObject spawnManager;
    private float latitude;
    private float longitude;
    public string API_key;
    public GameObject UI;
    public LocationManager locationManager;
    public List<string> conditionsConverted = new List<string>();
    public bool morningTest;
    public bool middayTest;
    public bool eveningTest;
    public bool nightTest;
    public bool coldTest;
    public bool warmTest;
    public bool hotTest;
    public bool clearTest;
    public bool cloudyTest;
    public bool rainTest;

    
    

    // Start is called before the first frame update
    public void Begin(){
    //  Debug.Log("reached1");
        latitude = locationManager.latitude;
        longitude = locationManager.longitude;
        StartCoroutine(GetWeatherInfo());
    }

    // Update is called once per frame
    // void Update()
    // {

    //     if(locationFound){
    //         StartCoroutine(GetWeatherInfo());

    //     }
        
    // }

    private IEnumerator GetWeatherInfo(){

        var www = new UnityWebRequest("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/" + latitude + "%2C%20" + longitude + "?unitGroup=metric&include=current&key=" + API_key + "&contentType=json&lang=en"){

            downloadHandler = new DownloadHandlerBuffer()
        };
        Debug.Log("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/" + latitude + "%2C%20" + longitude + "?unitGroup=metric&include=current&key=" + API_key + "&contentType=json&lang=en");
        yield return www.SendWebRequest();

        if(www.result == UnityWebRequest.Result.ConnectionError) {
            Debug.Log("connection error");
            yield break;
        }

       if(www.result == UnityWebRequest.Result.ProtocolError){
            Debug.Log("protocol error");
            yield break;
       }

        data = JsonUtility.FromJson<WeatherData>(www.downloadHandler.text);
       // Debug.Log("reached2");
       // Debug.Log(data);
        if(coldTest){
            data.currentConditions.temp = 18;
        }

        if(warmTest){
            data.currentConditions.temp = 28;
        }

        if(hotTest){
            data.currentConditions.temp = 29;
        }

        if(clearTest){
            data.currentConditions.conditions = "Clear";
        }

        if(cloudyTest){
            data.currentConditions.conditions = "Partially cloudy";
        }

        if(rainTest){
            data.currentConditions.conditions = "Rain";
        }

        Display();
      //  currentWeather.text = "Current Weather: " + data.currently.summary;


    }

    public void Display(){

        for(int i = 0; i < UI.transform.childCount; i++){
            string tmp = UI.transform.GetChild(i).name;

            if(tmp.CompareTo("City") == 0){
                UI.transform.GetChild(i).GetComponent<TMP_Text>().text = "City: " + locationManager.city;
            }

            if(tmp.CompareTo("Country") == 0){
                UI.transform.GetChild(i).GetComponent<TMP_Text>().text = "Country: " + locationManager.country;
            }

            if(tmp.CompareTo("Latitude") == 0){
                UI.transform.GetChild(i).GetComponent<TMP_Text>().text = "Latitude: " + locationManager.latitude;
            }

            if(tmp.CompareTo("Longitude") == 0){
                UI.transform.GetChild(i).GetComponent<TMP_Text>().text = "Longitude: " + locationManager.longitude;
            }

            if(tmp.CompareTo("Temperature") == 0){
                UI.transform.GetChild(i).GetComponent<TMP_Text>().text = "Temperature: " + data.currentConditions.temp + " °C";
            }

            if(tmp.CompareTo("Weather Conditions") == 0){
                UI.transform.GetChild(i).GetComponent<TMP_Text>().text = "Weather Conditions: " + data.currentConditions.conditions;
            }



           // Debug.Log(tmp);

          //  Debug.Log(System.DateTime.Now);

        }
        conditionConverter();
        
    }

    public void conditionConverter(){
        string s = data.currentConditions.conditions;
        string holder = "";
        bool multiType = false;
        for(int i = 0; i < s.Length; i++){
            if(s[i].Equals(',')){
                multiType = true;
                for(int o = 0; o < i; o++){
                    holder += s[o].ToString();
                }

                    conditionsConverted.Add(holder);
                    holder = "";

                for(int u = i+2; u < s.Length; u++){
                    holder += s[u].ToString();
                }

                conditionsConverted.Add(holder);
            }
        }

        if(multiType == false){
            for(int v = 0; v < s.Length; v++){
                holder += s[v].ToString();
            }
            conditionsConverted.Add(holder);
        }


        // for(int q = 0; q < conditionsConverted.Count; q++){
        //     Debug.Log(conditionsConverted[q]);
        // }

        spawnManager.SetActive(true);

    }
}

[System.Serializable]

public class WeatherData
{   
    public int cost;
	public float latitude;
	public float longitude;
    public string resolvedAddress;
    public string address;
	public string timezone;
    public int offset;
    public string description;
    public currentConditions currentConditions;
}

[System.Serializable]
public class currentConditions
{
	public string datetime;
    public int dateTimeEpoch;
    public float temp;
    public float feelslike;
    public float humidity;
    public float dew;
    public float precip;
    public float precipprob;
    public float snow;
    public float snowdepth;
    public float preciptype;
    public float windgust;
    public float windspeed;
    public float winddir;
    public float pressure;
    public float visibility;
    public float cloudcover;
    public float solarradiation;
    public float solarenergy;
    public float uvindex;
    public string conditions;
    public string icon;
    public List<string> stations;
    public string sunrise;
    public int sunriseEpoch;
    public string sunset;
    public int sunsetEpoch;
    public float moonphase;


}


