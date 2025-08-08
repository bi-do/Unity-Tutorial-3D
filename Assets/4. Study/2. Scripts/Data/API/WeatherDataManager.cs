using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherDataManager : MonoBehaviour
{
    public enum WeatherType { Sun, Clound, Rain, Snow }
    public WeatherType weather_type;

    public string URL = "https://apis.data.go.kr/1360000/VilageFcstInfoService_2.0/getVilageFcst?";

    public string key;
    public string num_of_rows;
    public string page_num;
    public string data_type;
    public string base_date;
    public string base_time;
    public string nx;
    public string ny;

    public WeatherData.Root weather_data;
    private int cur_pty;
    private int cur_sky;

    void Start()
    {
        StartCoroutine(GetRoutine());
    }

    IEnumerator GetRoutine()
    {
        this.URL += $"serviceKey={this.key}&numOfRows={this.num_of_rows}&pageNo={this.page_num}&dataType={this.data_type}&base_date={this.base_date}&base_time={this.base_time}&nx={this.nx}&ny={this.ny}";

        Debug.Log(URL);
        UnityWebRequest www = UnityWebRequest.Get(this.URL);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log($"Faild Error : {www.error}");
        }
        else
        {
            string data = www.downloadHandler.text;
            Debug.Log(data);

            WeatherData.Root weather_temp = JsonUtility.FromJson<WeatherData.Root>(data);
            foreach (WeatherData.Item element in weather_temp.response.body.items.item)
            {
                if (element.category == "PTY")
                {
                    Debug.Log($"강수 형태 : {element.fcstValue}");
                    this.cur_pty = int.Parse(element.fcstValue);
                }
                else if (element.category == "SKY")
                {
                    Debug.Log($"강수 형태 : {element.fcstValue}");
                    this.cur_sky = int.Parse(element.fcstValue);
                }
            }
            weather_data = weather_temp;
        }
        SetWeatherType();
    }

    private void SetWeatherType()
    {

        if (cur_sky == 1)
        {
            weather_type = WeatherType.Sun;
        }
        else if (cur_sky == 3)
        {
            weather_type = WeatherType.Clound;
        }else if (cur_pty == 1 || cur_pty == 2 || cur_pty == 4)
        {
            this.weather_type = WeatherType.Rain;
        }
        else if (cur_pty == 3)
        {
            this.weather_type = WeatherType.Snow;
        }
        Debug.Log($"현재 날씨는 {this.weather_type} 입니다.");
    }

    
}
