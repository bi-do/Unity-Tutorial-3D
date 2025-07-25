using UnityEngine;

public class BombAction : MonoBehaviour
{
    /// <summary> 폭탄 이펙트 프리팹 </summary>
    public GameObject bomb_effect;

    /// <summary> 수류탄 데미지 </summary>
    public int atk_power = 10;

    /// <summary> 폭발효과 반경 </summary>
    public float explosion_radius = 5f;



    void OnCollisionEnter(Collision collision)
    {
        // 폭발 시 ( 내 포지션에서 , 폭발 효과 반경내에 , 9번 레이어 게임 오브젝트들의 콜라이더 전부 반환 )
        Collider[] cols = Physics.OverlapSphere(this.transform.position, this.explosion_radius, 1 << 9);

        foreach (Collider element in cols)
        {
            element.GetComponent<EnemyFSM>().HitEnemy(this.atk_power);
        }

        GameObject eff_tem = Instantiate(this.bomb_effect, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
