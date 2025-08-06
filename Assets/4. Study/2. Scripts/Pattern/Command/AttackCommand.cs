using Pattern.Command;
using UnityEngine;

public class AttackCommand : ICommand
{
    private Player player;

    public AttackCommand(Player player)
    {
        this.player = player;
    }

    public void Cancel()
    {
        this.player.AttackCancel();
    }

    public void Excute()
    {
        this.player.Attack();
    }
}