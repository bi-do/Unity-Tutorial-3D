using UnityEngine;

public class StudyParameter : MonoBehaviour
{
    private int num = 0;
    private int[] arr = { 10, 20, 30 };

    void Start()
    {
        #region 파라미터 호출
        NomalParameter(3);

        DefaultParameter(5);

        ReferenceParameter(ref num);

        OutParameter(out num);

        ArrayParameter(this.arr);

        ParamsParameter(10, 20, 30);
        #endregion
    }

    #region 매개 변수
    /// <summary> 일반적인 매개변수 </summary>
    private void NomalParameter(int param_num)
    {
        this.num = param_num;
    }


    /// <summary> 디폴트 매개변수 </summary>
    private void DefaultParameter(int param_num = 0)
    {
        this.num = param_num;
    }

    // 오버로딩 : 같은 함수 이름을 매개변수를 다르게 하여 다른 기능 구현 ( C#은 네임 맹글링 시스템이 아닌 다른 방법인 듯 ? )
    private void DefaultParameter(int param_num = 0, int a = 3)
    {
        this.num = param_num;
    }

    // 값 타입을 참조 형식으로 넘김 ( int* 를 넘긴것과 같음. Call by Reference . 참조 타입이라면 포인터가 가리키는 값도 변경 가능 .)
    private void ReferenceParameter(ref int param_num)
    {
        param_num = 10;
    }

    // 값 타입을 참조 형식으로 넘기나 , 반환값을 넣어준다고 명시적으로 표현하는것에 가까움. 그리고 무조건 함수 내에서 값을 초기화해야함. 
    private void OutParameter(out int param_num)
    {
        param_num = 30;
    }

    // 컨테이너를 매개변수로 넣은 경우
    private void ArrayParameter(int[] param_numbers)
    {
        foreach (int element in param_numbers)
        {
            Debug.Log(element);
        }
    }

    // params를 활용한 매개변수
    private void ParamsParameter(params int[] param_numbers)
    {
        foreach (int element in param_numbers)
        {
            Debug.Log(element);
        }
    }
    #endregion


}
