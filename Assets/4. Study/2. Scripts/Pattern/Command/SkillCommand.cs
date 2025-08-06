using UnityEngine;
using Pattern.Command;

public class SkillCommand : ICommand
{
    private Player player;
    private string skill_name;

    public SkillCommand(Player player, string skill_name)
    {
        this.player = player; 
        this.skill_name = skill_name;
    }

    public void Cancel()
    {
        this.player.UseSkillCancel(this.skill_name);
    }

    public void Excute()
    {
        this.player.UseSkill(this.skill_name);
    }
}