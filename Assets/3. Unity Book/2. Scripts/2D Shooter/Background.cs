using UnityEngine;

public class Background : MonoBehaviour
{
    public Material bg_material;

    public float speed = 0.2f;

    public Vector2 dir = Vector2.up;

    void Update()
    {
        this.bg_material.mainTextureOffset += dir * speed * Time.deltaTime;
    }
}
