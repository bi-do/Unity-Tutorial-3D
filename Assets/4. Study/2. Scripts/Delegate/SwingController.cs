using System;
using System.Collections;
using UnityEngine;

public class SwingController : MonoBehaviour
{
    private Animator anim;

    private bool isSwing;

    public Action swing_start;
    public Action swing_end;

    void Start()
    {
        this.anim = this.GetComponent<Animator>();
        this.swing_start += SwingStart;
        this.swing_end += SwingEnd;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isSwing)
            {
                StartCoroutine(SwingRoutine());
            }
        }
    }

    IEnumerator SwingRoutine()
    {
        this.isSwing = true;
        this.anim.SetTrigger("Swing");
        this.swing_start?.Invoke();

        // float anim_length = anim.GetCurrentAnimatorClipInfo(0).Length;
        yield return new WaitForSeconds(0.5f);
        this.isSwing = false;

        this.swing_end?.Invoke();
    }

    private void SwingStart()
    {
        Debug.Log("스윙 시작");
    }

    private void SwingEnd()
    {
        Debug.Log("스윙 시작");
    }
}
