using System;
using System.Collections;
using UnityEngine;

public class StudyCallback : MonoBehaviour
{
    public Action bomt_act;

    void OnEnable()
    {
        this.bomt_act += () =>
        {
            BombDamage();
            BombEffect();
            BombExplosition();
        };
    }

    IEnumerator Start()
    {
        Debug.Log("폭탄 타이머 시작");
        yield return new WaitForSeconds(5f);

        this.bomt_act?.Invoke();
    }

    private void BombExplosition()
    {
        Debug.Log("폭발 실행");
    }

    private void BombDamage()
    {
        Debug.Log("폭발 데미지 적용");
    }

    private void BombEffect()
    {
        Debug.Log("폭발 이펙트 실행");
    }
}
