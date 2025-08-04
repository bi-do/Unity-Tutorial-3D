using UnityEngine;

public class StudyDelegate : MonoBehaviour
{
    public delegate void MyDelegate();
    public MyDelegate del;
    public MyDelegate on_key_down;

    public delegate void TimeStart();
    public TimeStart on_time_start;

    public delegate void TimeEnd();
    public TimeEnd on_time_end;

    public KeyCode keyCode = KeyCode.Space;

    public float timer_bomb;
    public float timer_time = 10f;

    public bool isTimer = true;
    public bool isTimeOver = false;

    void OnEnable()
    {
        this.on_time_start += startEvent;
        this.on_time_end += EndEvent;
    }

    void OnDisable()
    {
        this.on_time_start -= startEvent;
        this.on_time_end -= EndEvent;
    }


    void Start()
    {
        BombInit();
        this.on_time_start?.Invoke();
    }

    void Update()
    {
        BombUpdate();

        this.timer_time -= Time.deltaTime;
        if (this.timer_time <= 0 && !this.isTimeOver)
        {
            this.on_time_end?.Invoke();
            this.isTimeOver = true;
        }

    }

    private void startEvent()
    {
        Debug.Log("타이머 시작");
    }

    private void EndEvent()
    {
        Debug.Log("타이머 종료");
    }

    #region 폭탄 정지 예제

    public void BombInit()
    {
        AddMethod(this.Respond);
        AddMethod(this.StopBomb);
        AddMethod(this.StopTimer);
    }

    public void BombUpdate()
    {
        if (this.isTimer)
        {
            this.timer_bomb += Time.deltaTime;
        }

        if (Input.GetKeyDown(this.keyCode))
        {
            on_key_down?.Invoke();
        }
    }

    // 델리게이트는 하나의 타입처럼 작동. 매개변수로도 가능
    public void AddMethod(MyDelegate param_del)
    {
        this.on_key_down += param_del;
    }

    private void Respond()
    {
        Debug.Log("키가 눌렸습니다.");
    }

    private void StopTimer()
    {
        this.isTimer = false;
    }

    private void StopBomb()
    {
        Debug.Log("폭탄 기능 정지");
    }
    #endregion

    #region 델리게이트 형식
    public void Call()
    {
        // 옛날 방식 델리게이트 할당
        this.del = new MyDelegate(Remove);

        // 함수포인터 방식 델리게이트 할당
        this.del = Add;


        // delegate Chain ( 호출시 더해진 모든 함수 호출 )
        this.del += Remove;
        this.del += Delete;

        // delegate Chain substract ( Delete 함수 빼기 )
        this.del -= Delete;

        // // 일반 호출
        // this.del();

        // // Invoke 호출
        // this.del.Invoke();

        // null 확인 Invoke 호출 ( null 일 시 호출 X )
        this.del?.Invoke();
    }

    public void Add()
    {
        Debug.Log("Add");
    }

    public void Remove()
    {
        Debug.Log("Remove");
    }

    public void Delete()
    {
        Debug.Log("Delete");
    }
    #endregion

}
