using UnityEngine;

public class StudyDecoupling : MonoBehaviour
{
    public class Player
    {
        public Enemy enemy;

        public void AttackEnemy()
        {
            enemy.TakeDamage(10);
        }
    }

    public class Enemy
    {
        public float hp = 10;

        public void TakeDamage(float param_dmg)
        {
            this.hp -= param_dmg;
            Debug.Log($"{param_dmg}만큼 공격 받음");
        }
    }
}