using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float damage);
}

public class StudyDecoupling2 : MonoBehaviour
{
    public class Player
    {
        public Enemy enemy;

        public void AttackEnemy(IDamageable target , float damage)
        {
            target.TakeDamage(damage);
        }
    }

    public class Enemy : MonoBehaviour , IDamageable
    {
        private float hp = 10;

        public void TakeDamage(float param_dmg)
        {
            this.hp -= param_dmg;
            Debug.Log($"{param_dmg}만큼 공격 받음");
        }
    }
}
