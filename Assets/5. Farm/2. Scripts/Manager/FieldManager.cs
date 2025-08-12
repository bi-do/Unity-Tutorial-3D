using UnityEngine;
using UnityEngine.InputSystem;

public class FieldManager : MonoBehaviour
{
    public enum FieldState { Seed, Harvest }
    public FieldState field_state;

    [SerializeField] private GameObject tile_prefab;
    [SerializeField] private Vector2 field_size = new Vector2(9, 9);
    [SerializeField] private float tiie_size = 2f;

    [SerializeField] private GameObject plant_prefab;

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
        if (Farm.GameManager.Instance.cam_state == CamState.Field)
        {
            switch (this.field_state)
            {
                case FieldState.Seed:
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
                    GameObject plant = Instantiate(this.plant_prefab, this.transform.GetChild(1));
                    plant.transform.position = hit.transform.position;

                    tile_arr[tile.arr_pos.x, tile.arr_pos.y] = plant;
                }
            }
        }
    }

    private void OnHarvest()
    {

    }
}
