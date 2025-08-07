using Unity.VisualScripting;
using UnityEngine;

public class GameFacade : Singleton<GameFacade>
{
    private InventorySystem inventory_system;
    private QuestSystem quest_system;
    private SoundSystem sound_system;

    protected override void Awake()
    {
        base.Awake();

        this.inventory_system = this.GetComponent<InventorySystem>();
        this.quest_system = this.GetComponent<QuestSystem>();
        this.sound_system = this.GetComponent<SoundSystem>();

        if (inventory_system == null)
        {
            this.inventory_system = this.AddComponent<InventorySystem>();
        }
        if (inventory_system == null)
        {
            this.quest_system = this.AddComponent<QuestSystem>();
        }
        if (inventory_system == null)
        {
            this.sound_system = this.AddComponent<SoundSystem>();
        }
    }

    public void ItemEvent(int param_index, string item_name)
    {
        if (param_index == 0)
        {
            this.inventory_system.AddItem(item_name);
        }
        else if (param_index == 1)
        {
            this.inventory_system.AddItem(item_name);
        }
        else if (param_index == 2)
        {
            this.inventory_system.AddItem(item_name);
        }
    }

    public void QuestEvent(int param_index, string quest_name)
    {
        if (param_index == 0)
        {
            this.inventory_system.AddItem(quest_name);
        }
        else if (param_index == 1)
        {
            this.inventory_system.AddItem(quest_name);
        }
        else if (param_index == 2)
        {
            this.inventory_system.AddItem(quest_name);
        }
    }

    public void SoundEvent(int param_index, string sound_name)
    {
        if (param_index == 0)
        {
            this.inventory_system.AddItem(sound_name);
        }
        else if (param_index == 1)
        {
            this.inventory_system.AddItem(sound_name);
        }
        else if (param_index == 2)
        {
            this.inventory_system.AddItem(sound_name);
        }
    }
}