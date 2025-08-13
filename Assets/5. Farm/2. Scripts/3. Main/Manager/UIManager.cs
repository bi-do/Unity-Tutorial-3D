using UnityEngine;
using UnityEngine.UI;

namespace Farm
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject out_side_UI;
        [SerializeField] private GameObject field_UI;
        [SerializeField] private GameObject house_UI;
        [SerializeField] private GameObject animal_UI;
        [SerializeField] private GameObject seed_UI;
        [SerializeField] private GameObject inventory_UI;

        [SerializeField] private Button seed_btn;
        [SerializeField] private Button harvest_btn;
        [SerializeField] private Button[] plant_btns;

        void Awake()
        {
            this.seed_btn.onClick.AddListener(OnSeedBtn);
            this.harvest_btn.onClick.AddListener(OnHarvestBtn);


            int cnt = 0;
            foreach (Button element in this.plant_btns)
            {
                // 클로저 오류 배제
                int temp = cnt;
                element.onClick.AddListener(() => GameManager.Instance.field.SetPlant(temp));
                cnt++;
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                this.inventory_UI.SetActive(!this.inventory_UI.activeSelf);
            }
        }

        void OnSeedBtn()
        {
            GameManager.Instance.field.SetState(FieldManager.FieldState.Seed);
            seed_UI.SetActive(true);
        }

        void OnHarvestBtn()
        {
            GameManager.Instance.field.SetState(FieldManager.FieldState.Harvest);
            seed_UI.SetActive(false);
        }

        public void ActivateFieldUI(bool isActive)
        {
            field_UI.SetActive(isActive);
        }
    }
}
