using System.Collections.Generic;
using UnityEngine;

namespace Pattern.Command
{
    public class PlayerController : MonoBehaviour
    {
        public Player player;

        private ICommand attack_command, jump_command, skill_command;

        private Queue<ICommand> command_q = new Queue<ICommand>();
        private Stack<ICommand> Excute_stack = new Stack<ICommand>();

        void Awake()
        {
            this.attack_command = new AttackCommand(player);
            this.jump_command = new JumpCommand(player);
            this.skill_command = new SkillCommand(player, "Fire ball");
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) // 공격 즉시 실행
            {
                attack_command.Excute();
                Excute_stack.Push(attack_command);
            }
            else if (Input.GetKeyDown(KeyCode.W)) // 점프 즉시 실행
            {
                jump_command.Excute();
                Excute_stack.Push(jump_command);
            }
            else if (Input.GetKeyDown(KeyCode.E)) // 스킬 즉시 실행
            {
                skill_command.Excute();
                Excute_stack.Push(skill_command);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1)) // 큐에 공격 저장
            {
                command_q.Enqueue(attack_command);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1)) // 큐에 점프 저장
            {
                command_q.Enqueue(jump_command);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1)) // 큐에 스킬 저장
            {
                command_q.Enqueue(skill_command);
            }

            if (Input.GetKeyDown(KeyCode.Space)) // 큐에 저장된 항목 순차 실행
            {
                while (this.command_q.Count > 0)
                {
                    ICommand temp = this.command_q.Dequeue();
                    temp.Excute();
                    this.Excute_stack.Push(temp);
                }
            }

            if (Input.GetKeyDown(KeyCode.Z)) // 스택에 쌓인 행동 취소
            {
                if (this.Excute_stack.Count > 0)
                {
                    ICommand last_command = this.Excute_stack.Pop();
                    Debug.Log($"명령 취소 : {last_command.GetType().Name}");

                    last_command.Cancel();
                }
                else
                {
                    Debug.Log("명령 컨테이너에 명령이 없습니다.");
                }
            }
        }
    }
}