using System;
using System.Collections;
using UnityEngine;

namespace Farm
{
    public class Plant : MonoBehaviour
    {
        private enum PlantState { LV1, LV2, LV3 }
        private PlantState plane_state;

        private DateTime start_time, growth_time, harvest_tiem;

        public int plant_index;
        public bool is_harvest = false;

        void Awake()
        {
            start_time = DateTime.Now;
            this.growth_time = start_time.AddSeconds(5);
            this.harvest_tiem = start_time.AddSeconds(10);
        }

        void Start()
        {
            StartCoroutine(StateUpdateRoutine());
        }

        // 날씨 시스템 액션 추가 / 삭제
        void OnEnable()
        {
            WeatherSystem.weather_act += SetGrowth;
        }

        void OnDisable()
        {
            WeatherSystem.weather_act -= SetGrowth;
        }

        /// <summary> 1초마다 식물의 성장 확인  </summary>
        IEnumerator StateUpdateRoutine()
        {
            SetState(PlantState.LV1);

            while (plane_state != PlantState.LV3)
            {
                if (DateTime.Now >= harvest_tiem)
                {
                    Debug.Log("LV3");
                    SetState(PlantState.LV3);
                    is_harvest = true;
                }
                else if (DateTime.Now >= growth_time)
                {
                    Debug.Log("LV2");
                    SetState(PlantState.LV2);
                }
                yield return new WaitForSeconds(1f);
            }
        }

        /// <summary> 식물 성장 상태 변경 </summary>
        private void SetState(PlantState param_state)
        {
            if (this.plane_state != param_state || this.plane_state == PlantState.LV1)
            {
                this.plane_state = param_state;
                for (int i = 0; i < 3; i++)
                {
                    this.transform.GetChild(i).gameObject.SetActive(false);
                }

                transform.GetChild((int)this.plane_state).gameObject.SetActive(true);
            }
        }

        private void SetGrowth(WeatherType weather)
        {
            switch (weather)
            {
                case WeatherType.Sun:
                    // 성장 촉진
                    break;
                case WeatherType.Snow:
                    // 성장 저하
                    break;
                case WeatherType.Rain:
                    // 성장 중간
                    break;
            }
        }
    }
}
