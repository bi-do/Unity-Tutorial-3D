using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bomb_effect;

    void OnCollisionEnter(Collision collision)
    {
        GameObject eff_tem = Instantiate(this.bomb_effect,this.transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
}
