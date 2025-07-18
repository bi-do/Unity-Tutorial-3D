using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float destroy_time = 2f;

    private float cur_time = 0f;

    void Update()
    {
        cur_time += Time.deltaTime;

        if (cur_time > destroy_time)
        {
            Destroy(this.gameObject);
        }
    }
}
