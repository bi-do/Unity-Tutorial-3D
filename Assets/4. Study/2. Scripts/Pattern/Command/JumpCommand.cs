using UnityEngine;
using Pattern.Command;

public class JumpCommand : ICommand
{
    private Player player;
    public JumpCommand(Player player)
    {
        this.player = player;
    }

    public void Cancel()
    {
        this.player.JumpCancel();
    }

    public void Excute()
    {
        this.player.Jump();
    }
}