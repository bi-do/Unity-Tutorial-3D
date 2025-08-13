using System;
using System.Collections;
using UnityEngine;

public enum WeatherType { Sun, Rain, Snow }

public class WeatherSystem : MonoBehaviour
{
    public WeatherType weather_type;

    [SerializeField] private GameObject[] weather_particles;

    /// <summary> 날씨가 변경될 때마다 호출되는 액션 </summary>
    public static event Action<WeatherType> weather_act;

    void Start()
    {
        StartCoroutine(WeatherRoutine());
    }

    /// <summary> 15초마다 날씨 상태 변경 및 Weather에 다른 액션 호출 </summary>
    IEnumerator WeatherRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);

            int weather_cnt = Enum.GetValues(typeof(WeatherType)).Length;


            int ran_index = UnityEngine.Random.Range(0, weather_cnt);

            weather_type = (WeatherType)ran_index;

            foreach (GameObject element in weather_particles)
            {
                element.SetActive(false);
            }

            weather_particles[ran_index].SetActive(true);

            weather_act?.Invoke(weather_type);
        }
    }
}
