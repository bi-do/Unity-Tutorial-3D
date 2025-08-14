using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalEvent : MonoBehaviour
{
    [SerializeField] private GameObject flag;
    [SerializeField] private GameObject follow_target;

    private BoxCollider box_col;

    private float timer;
    private bool isTimer;

    public static Action fail_act;

    void Start()
    {
        this.box_col = GetComponent<BoxCollider>();
        fail_act += SetRandomPos;
    }

    void Update()
    {
        if (!isTimer)
            return;

        this.timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.isTimer = true;
            SetRandomPos();

            follow_target.SetActive(true);
            Farm.GameManager.Instance.SetCamState(CamState.Animal);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"깃발을 찾는데 걸린 시간은 {this.timer:F1}초 입니다");
            this.isTimer = false;
            this.timer = 0;

            SetFlag(Vector3.zero, false);
            follow_target.SetActive(false);
            Farm.GameManager.Instance.SetCamState(CamState.Outside);
        }
    }

    private void SetRandomPos()
    {
        float random_x = Random.Range(box_col.bounds.min.x, box_col.bounds.max.x);
        float random_z = Random.Range(box_col.bounds.min.z, box_col.bounds.max.z);

        Vector3 random_pos = new Vector3(random_x, 0, random_z);

        SetFlag(random_pos , true);
    }

    private void SetFlag(Vector3 param_pos, bool isActive)
    {
        flag.transform.SetParent(transform);
        flag.SetActive(isActive);
        this.flag.transform.position = param_pos;
    }
}
