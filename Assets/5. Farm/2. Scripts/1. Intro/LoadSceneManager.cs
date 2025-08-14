using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : Singleton<LoadSceneManager>
{
    private int scene_idx = 0;
    public int character_idx = 0;

    protected override void Awake()
    {
        if (instance == null)
        {
            instance = this as LoadSceneManager;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    public void OnLoadScene()
    {
        this.scene_idx++;
        Fade.on_fade_act(3f, Color.white, true, () => SceneManager.LoadScene(this.scene_idx));
    }

    public void SetCharacterIndex(int param_index)
    {
        this.character_idx = param_index;
    }
}
