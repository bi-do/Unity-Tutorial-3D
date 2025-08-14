using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image Fade_Image_UI;

    private bool isFade;

    public static Action<float, Color, bool,Action> on_fade_act;

    void OnEnable()
    {
        on_fade_act += OnFade;
    }

    void OnDisable()
    {
        on_fade_act -= OnFade;
    }

    void Awake()
    {
        this.Fade_Image_UI = this.GetComponent<Image>();
    }

    private void OnFade(float fade_time, Color color, bool isFadein, Action fade_complete_act)
    {
        StartCoroutine(FadeRoutine(fade_time, color, isFadein,fade_complete_act));
    }

    IEnumerator FadeRoutine(float fade_time, Color color, bool isFadein, Action fade_complete_act)
    {
        Fade_Image_UI.raycastTarget = true;
        float timer = 0f;
        float percent = 0f;
        Debug.Log("Fade 중");

        while (percent < 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fade_time;

            float value = isFadein ? percent : 1 - percent;
            this.Fade_Image_UI.color = new Color(color.r, color.g, color.b, value);
            yield return null;
        }
        Fade_Image_UI.raycastTarget = false;
        fade_complete_act?.Invoke();
    }
}
