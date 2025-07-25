using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LodingNextScene : MonoBehaviour
{
    public int Scene_num = 2;
    public Slider loading_slider_UI;
    public TextMeshProUGUI loding_text_UI;

    void Start()
    {
        Debug.Log("로딩씬 나옴");
        StartCoroutine(TransitionNextScene(this.Scene_num));
        
    }

    IEnumerator TransitionNextScene(int param_num)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(param_num);

        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            loading_slider_UI.value = ao.progress;
            this.loding_text_UI.text = $"{ao.progress * 100f}%";

            if (ao.progress >= 0.9f)
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
