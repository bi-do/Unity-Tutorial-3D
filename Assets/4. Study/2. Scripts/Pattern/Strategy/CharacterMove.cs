using UnityEngine;

namespace Pattern
{
    public class CharacterMove : MonoBehaviour
    {
        private IMovement movement;

        void Start()
        {
            movement = new MoveWalk(3f);
        }

        void Update()
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Alpha1)) 
            {
                this.movement = new MoveWalk(3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) 
            {
                this.movement = new MoveRun(7);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) 
            {
                this.movement = new MoveFly(1);
            }
        }

        private void Move()
        {
            this.movement.Move(this.transform);
        }
    }
}