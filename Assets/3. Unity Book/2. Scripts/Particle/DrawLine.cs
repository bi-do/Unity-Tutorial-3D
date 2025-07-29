using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer line_rend;
    private int line_cnt = 0;
    private int line_obj_cnt = 1;

    public Color color;
    public float line_width = 0.05f;

    public List<GameObject> line_objs = new List<GameObject>(); // 생성된 line을 담을 컨테이너

    void Start()
    {
        this.color = new Color(1, 1, 1, 1);
    }

    void Update()
    {
        // 선 시작
        if (Input.GetMouseButtonDown(0))
        {
            GameObject line_temp = new GameObject("line Object"); // 새로운 빈 게임 오브젝트 생성
            line_obj_cnt++;

            this.line_rend = line_temp.AddComponent<LineRenderer>(); // 빈 게임 오브젝트에 LineRenderer 컴포넌트 설정
            this.line_rend.useWorldSpace = false;
            this.line_rend.startWidth = this.line_width;
            this.line_rend.endWidth = this.line_width;

            this.line_rend.startColor = this.color;
            this.line_rend.endColor = this.color;

            this.line_rend.material = new Material(Shader.Find("Universal Render Pipeline/Particles/Unlit"));

            this.line_objs.Add(line_temp);
        }

        // 선 그리는 중
        if (Input.GetMouseButton(0))
        {
            Vector3 screen_pos = Input.mousePosition;
            screen_pos.z = 10f;
            Vector3 world_pos = Camera.main.ScreenToWorldPoint(screen_pos);
            this.line_rend.positionCount = ++this.line_cnt;
            this.line_rend.SetPosition(this.line_cnt - 1, world_pos);
        }

        // 선 종료
        if (Input.GetMouseButtonUp(0))
        {
            this.line_cnt = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (GameObject element in this.line_objs)
            {
                Destroy(element);
            }
            this.line_objs.Clear();
        }
    }
}
