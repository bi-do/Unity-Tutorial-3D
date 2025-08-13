using System.Collections;
using Farm;
using UnityEngine;


public class FieldManager : MonoBehaviour
{
    public enum FieldState { None, Seed, Harvest }
    public FieldState field_state;

    [SerializeField] private GameObject tile_prefab;
    [SerializeField] private Vector2 field_size = new Vector2(9, 9);
    [SerializeField] private float tiie_size = 2f;

    [SerializeField] private int cur_plant_index = -1;
    [SerializeField] private GameObject[] plants;
    [SerializeField] private GameObject[] crops;

    private GameObject[,] tile_arr;
    private Camera main_cam;
    [SerializeField] private LayerMask field_layer_mask;

    void Awake()
    {
        this.main_cam = Camera.main;

        this.tile_arr = new GameObject[(int)field_size.x, (int)field_size.y];
        CreateField();

        field_layer_mask = 1 << 17;  // 17번 레이어 Field
    }

    void Update()
    {
        if (field_state != FieldState.None)
        {
            switch (this.field_state)
            {
                case FieldState.Seed:
                    if (cur_plant_index >= 0)
                        OnSeed();
                    break;

                case FieldState.Harvest:
                    OnHarvest();
                    break;
            }
        }
    }

    /// <summary> 격자 타일 생성 </summary>
    private void CreateField()
    {
        float offset_x = (field_size.x - 1) * tiie_size / 2;
        float offset_y = (field_size.y - 1) * tiie_size / 2;

        for (int i = 0; i < field_size.x; i++)
        {
            for (int j = 0; j < field_size.y; j++)
            {
                float pox_x = transform.position.x + i * tiie_size - offset_x;
                float pox_z = transform.position.z + j * tiie_size - offset_y;

                GameObject tile_obj = Instantiate(this.tile_prefab, this.transform.GetChild(0));
                tile_obj.name = $"Tile_{i}_{j}";
                tile_obj.transform.position = new Vector3(pox_x, 0, pox_z);
                // this.tile_arr[i, j] = tile_obj;
                tile_obj.GetComponent<Tile>().arr_pos = new Vector2Int(i, j);
            }
        }
    }

    /// <summary> 씨앗 심기 </summary>
    private void OnSeed()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = main_cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, this.field_layer_mask))
            {
                Tile tile = hit.collider.GetComponent<Tile>();

                if (tile_arr[tile.arr_pos.x, tile.arr_pos.y] == null)
                {
                    GameObject plant = Instantiate(this.plants[cur_plant_index], this.transform.GetChild(1));
                    plant.GetComponent<Plant>().plant_index = cur_plant_index;
                    plant.transform.position = hit.transform.position;

                    tile_arr[tile.arr_pos.x, tile.arr_pos.y] = plant;
                }
            }
        }
    }

    /// <summary> 수확 </summary>
    private void OnHarvest()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = main_cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, this.field_layer_mask))
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                int tile_x = tile.arr_pos.x;
                int tile_y = tile.arr_pos.y;


                Plant temp_plant = tile_arr[tile_x, tile_y]?.GetComponent<Plant>();

                if (temp_plant != null && temp_plant.is_harvest)
                {
                    temp_plant.gameObject.SetActive(false);
                    tile_arr[tile_x, tile_y] = null;

                    StartCoroutine(ItemDropRoutine(temp_plant.plant_index, tile.transform.position));
                }
            }
        }
    }

    /// <summary> 아이템 드랍 루틴 ( 드랍할 아이템 Index , 드랍 시 적용될 Pos ) </summary>
    IEnumerator ItemDropRoutine(int index, Vector3 param_pos)
    {
        int ran_amount = Random.Range(1, 4);

        for (int i = 0; i < ran_amount; i++)
        {
            GameObject obj_temp = Instantiate(crops[index], param_pos + Vector3.up * 0.5f, Quaternion.identity);
            Rigidbody crop_rb = obj_temp.GetComponent<Rigidbody>();

            float ran_x = Random.Range(-2f, 2f);
            float ran_y = Random.Range(-2f, 2f);
            Vector3 dir = new Vector3(ran_x, 5f, ran_y);

            crop_rb.AddForce(dir, ForceMode.Impulse);

            yield return new WaitForSeconds(0.15f);
        }
    }

    /// <summary> 현재 들고있는 씨앗 변경 함수 </summary>
    public void SetPlant(int index)
    {
        this.cur_plant_index = index;
    }

    /// <summary> 현재 플레이어의 Action 상태 변경 ( 씨앗 심기 or 수확하기 ) </summary>
    public void SetState(FieldState param_state)
    {
        if (this.field_state != param_state)
        {
            this.field_state = param_state;
        }
    }
}
