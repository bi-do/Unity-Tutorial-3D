using UnityEngine;

namespace Pattern.Decorator
{
    public class Player : MonoBehaviour
    {
        IAttack attack;
        void Start()
        {
            this.attack = new BasicAttack();
            this.attack.Excute();

            this.attack = new FireAttack(this.attack);
            this.attack.Excute();

            this.attack = new IceAttack(this.attack);
            this.attack.Excute();
            
        }
    }

}