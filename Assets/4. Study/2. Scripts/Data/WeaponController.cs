using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject[] weapon_objs;
    public WeaponDataGroup w_data_group;
    
    public WData cur_weapon_data;

    public int cur_weapon_idx;


    void Start()
    {
        // foreach (WeaponData element in weapon_datas)
        // {
        //     Debug.Log($"{element.weapon_name} / {element.attack_dmg} / {element.attack_range}");
        // }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwapWeapon(2);
        }
    }

    private void SwapWeapon(int param_index)
    {
        weapon_objs[cur_weapon_idx].SetActive(false);

        this.cur_weapon_idx = param_index;

        weapon_objs[this.cur_weapon_idx].SetActive(true);

        this.cur_weapon_data = this.w_data_group.w_data[cur_weapon_idx];

        
    }
}
