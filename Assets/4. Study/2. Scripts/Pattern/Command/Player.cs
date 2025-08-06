using UnityEngine;

namespace Pattern.Command
{
    public class Player : MonoBehaviour
    {
        public void Attack()
        {
            Debug.Log("Attack");
        }

        public void AttackCancel()
        {
            Debug.Log("Attack Cancel");
        }

        public void Jump()
        {
            Debug.Log("Jump");
        }

        public void JumpCancel()
        {
            Debug.Log("Jump Cancel");
        }

        public void UseSkill(string skill_name)
        {
            Debug.Log($"Use Skill : {skill_name}");
        }

        public void UseSkillCancel(string skill_name)
        {
            Debug.Log($"Use Skill : {skill_name}");
        }

    }
}