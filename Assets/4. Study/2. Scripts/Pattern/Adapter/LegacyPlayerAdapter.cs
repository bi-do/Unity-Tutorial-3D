using UnityEngine;

public class LegacyPlayerAdapter : MonoBehaviour, ICharacter
{
    private LegacyPlayer legacy_player;

    void Awake()
    {
        this.legacy_player = new LegacyPlayer();
    }

    public void Attack()
    {
        legacy_player.LegacyAttack();
    }

    public void Move(Vector3 dir)
    {
        this.legacy_player.LegacyMove(dir.x, dir.y, dir.z);
    }

    public void Move2(Vector2 dir)
    {
        
    }
}